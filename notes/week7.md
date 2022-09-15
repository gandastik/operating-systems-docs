## Concurrency

### Previously on last Chapter
- **1 Process / 1 Thread**
- มีกระบวนการที่ Overhead มาก (การโยกย้ายระหว่าง parent - child process etc.) <- boundary of process
- arise the new concept -> **Multithread** (in present time)

### Multithread
- reduced overhead from 1 Process / 1 Thread Concept
- ใน Process ก็จะสร้าง stack ใหม่ขึ้นมา แล้ว copy แค่ค่า PC, SP โดยไม่ต้อง copy code เพิ่มเติม
- **ปัญหา** : ถ้าเกิด Bug ก็จะชิบหายวายวอด เพราะว่า Code แต่ละ thread มันอยู่ใน boundary เดียวกัน
- meanwhile in **KERNEL**
  - PCB (Process Control Block)
  - TCB +[Stack] (Thread Control Block)
  - TCB +[Stack] (Thread Control Block)
- **Scheduler** ทำหน้าที่เป็นตัวจัดการเวลาการทำงานของแต่ละ Thread แต่มนุษย์ไม่สามารถรู้ได้ว่า Thread ไหนจะทำงานลำดับต่อไป

### Motivation
- OS need to be able to handle multiple things happening at the same time (concurrency)
  - Process execution, interrupts, background tasks, system maintenance
- Threads are an abstraction to help bridge this gap

### WHY Concurrency ?
- Servers -> multiple connection handled simultaneously
- Parallel programs -> better performance
- Program with UI -> user responsiveness
- Network and disk bound programs -> hide network/disk latency

### Definitions
- **Thread** -> มองได้ง่ายๆว่า เป็นตัวที่แยกออกมาที่มี PC, SP เป็นของตัวเองอีก
  - Single execution sequence :
  - Seperately schedulable :
- Protection is an orthogonal concept : Thread ของ process เดียวกันก็ access memory ของ thread ที่เป็น process เดียวกันได้
  - can have one or many threads per protection domain

### Threads in the Kernel and at User-Level
- **Multi-threaded kernel**
- **Multiprocess kernel**
- **Multiple mult-threaded user processes**

### Thread Abstraction
- infinite number of processors
- Threads execute with variable speed
  - แต่ละ Thread ทำงานด้วยความเร็วที่ไม่เท่ากัน (ขึ้นอยู่กับการที่ถูกเลือกโดย Scheduler)

![Programmer's view vs Processor View](https://media.discordapp.net/attachments/1014398974649708624/1019803771649400852/unknown.png?width=1028&height=657)

### Thread Operations
- **thread_create(thread, func, args)**
  - สร้าง new thread เพื่อรัน func
- **thread_yield()**
  - Relinquish processor voluntarily
- **thread_join(thread)**
  - ใน parent thread รอจนกว่า child จบการทำงาน
- **thread_exit()**
  - Quit thread and clean up, wake up joiner if any

![Example code of thread](https://media.discordapp.net/attachments/1014398974649708624/1019805704950927360/unknown.png?width=875&height=657)
- results:
- hello from thread 0
- hello from thread 1
- thread 0 returned with 100
- thread 0 returned with 101
- hello from thread 3  ... so on (on particulary order)
- hello from thread 2
- thread 0 returned with 100 (in-order เพราะว่าเราเรียก join เป็นลำดับ)
- ....
- What's the maximum number of threads running when print "Hello from thread 5"
  - assuming thread#5 is the first thread to run
  - **11 Threads** (main thread + 10 other threads (including 5))
- What's the minimum then ?
  - assuming thread#5 is the last thread to run
  - **2 Threads** (main thread + thread#5 (just start to print -> not done yet))

### Fork/Join Concurrency
- Threads can create children, and wait for their completion
- Data only shared before fork/after join
- Examples:
  - Web server
  - Merge sort
  - Parallel memory copy

### Thread Data Structure
![Thread Data Structure](https://media.discordapp.net/attachments/1014398974649708624/1019814186513092608/unknown.png?width=759&height=657)

### Thread LifeCycle
![Thread LifeCycle](https://media.discordapp.net/attachments/1014398974649708624/1019814709509247026/unknown.png?width=1044&height=657)
- **Ready -> Running** : Scheduler ONLY

### Implementing Threads: Roadmap
- Kernel threads
  - only available to kernel
- Multithreaded process using kernel threads(Linux, MacOS)
  - kernel thread operations availabe via **syscall**
- User-level threads
  - thread operations without **syscall**

### Multithread OS Kernal
![](https://media.discordapp.net/attachments/1014398974649708624/1019816609700913152/unknown.png?width=813&height=657)

### Implementing threads
- **thread_fork(func, args)**
  - allocate TCB (Thread Control Block)
  - allocate stack
  - build stack frame for base of stack (**stub**) ทำหน้าที่ในการ call func ที่ส่งมา
  - put func, args on stack
  - put thread on ready list
  - will run sometime later (maybe right away)
- **stub(func, args)**: OS/161 mips_threadstart
  - Call(*func)(args)
  - if return, call thread_exit()

### Thread Stack
- จะเกิดอะไรขึ้นถ้า stack ล้น -> **Stack Overflow**

### Thread Context Switch
- **Voluntary** (ตัวโปรแกรมยินดีที่จะคืนเวลาให้ระบบ)
  - thread_yield
  - thread_join
  - คล้ายๆกับใช้ **syscall**
- **Involuntary**
  - interrupts or exception
  - some other thread is higher priority
  - Timer or I/O interrupt

### Context Switch
- didnt get the single word he just said...

### Multithread User Processes
![](https://media.discordapp.net/attachments/1014398974649708624/1019825355172888576/unknown.png?width=1006&height=657)
- **Green Thread** : early Java (JVM)
  - kernel thread -> user process -> จำลอง thread บน JVM "green thread"
  - ไม่จำเป็นต้อง context switch ระหว่าง user mode, kernel mode
- **Scheduler activation** (windows 8)
  - kernel จะจัดหา processors ไปที่ user-level library
  - thread libarary implement context switch
  - thread library จะเป็นคนตัดสินใจว่าจะรันตัวไหนต่อไป
- **Upcall** -> เกิดการย้ายของ user-level thread เมื่อมีการ block ที่ทาง kernel thread root ของตัวมัน เพื่อยังคงให้ใช้งานได้

