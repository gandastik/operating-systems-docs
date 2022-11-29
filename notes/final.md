## Introduction

### Roles of the OS

- **Referee**
	- **resources allocation** ระหว่าง users, application
	- **isolation** of different users, applications from each other
	- **communication** between users, application
- **Illusionist**
	- แต่ละ application จะถูกมองเหมือนมี entire machine เป็นของตัวเอง -> **process** 
	- infinite number of processors, (near) infinite amount of memory, reliable storage, reliable network transport
- **Glue**
	- Libraries, User Interface, widgets, ...

### What is an Operating Systems?
- A set of software that manage computer's resources for its users and their application
	- maybe visible or invisible to its users
	- 2 ชนิดใหญ่ๆ
		- General Purpose OS
		- Specific Purpos OS

### Operating System Evaluation (การประเมิณ  OS)
- **Reliability and Availability**
- **Security** -> พิจารณาแค่ภายใน OS ยกตัวอย่างเช่น the priviledge user authentication
- **Portability** -> AVM (Abstract Virtual Machine), API, HAL
- **Performance**: วัดภายใต้ control environment
	- overhead (ยิ่งน้อยยิ่งดี), efficiency
	- fairness, response time, throughput
	- performance predictability
- **Adoption**: การที่ OS ถูกยอมรับภายใต้ high level company

### Design Tradeoffs
- การออกแบบอะไรมันก็ย่อมมี tradeoffs -> must balance between the "5s"
- example
	- preserves legacy API -> Portability (up), Reliability (down), Security (down)
	- breaking an abstraction -> Performance (up), Portability (down), Reliability (down)

### Early OS
- ในยุคที่ไม่มี keyboard, mouse, display monitor -> มีการใช้ punched card สำหรับ I/O
- ทำให้ computer -> **very expensive**
- **one application at a time**
	- ทำให้สามารถควบคุม hardware ได้ทั้งหมด hence **"one application"**
	- OS ในสมัยนั้นจะเป็น runtime library (or system library eg. <stdio.h>) คือ **"no OS"**
	- ผู้ใช้งานจะต้องต่อแถวเพื่อที่จะใช้งานคอมพิวเตอร์ -> **Queue**
- **batch system**: automatically load the new input (program) after the program terminal detected
	- ทำให้  CPU busy by having queue of jobs
	- OS จะทำหน้าที่โหลด next job ขณะที่ current one runs
	- Users would submit jobs (analogy: in the "tray" of printer I/P), and wait, and wait, and wait...

### Time-Sharing OS
- ในยุคที่มี keyboard, display monitory -> สามารถมองเห็น terminal ในการ visualize input and output --> becoming more and more like OS nowadays
- **multiple users at the same time**: eg. remote desktop
	- **multilevelprogramming**: rum multiple program at same time
	- **interactive performance**: try to complete everyone's task quickly
	- as the computers become cheaper -> optimize for user time but not the computer time :(
- early day of RAM
	- CODE: programs
	- DATA: global variables, const
	- HEAP: store array
	- . . . 
	- STACK: LIFO call stack, only contains the address of the initial array

### Today's OS
- ***computer are cheap***

### really cool image to help you understand (?)
![](https://media.discordapp.net/attachments/1014398974649708624/1045691638447620167/image.png?width=734&height=685)

### Tomorrow's OS
- giant-scale data centers
- increasing numbers of processors per computer
- increasing numbers of computers per user
- very large scale storage

### In-Class Activity
1. what is your opinion about operating systems functionality
  - บริหารจัดการการทำงานของโปรแกรมภายในคอมพิวเตอร์
  - บริหารจัดการหน่วยความจำภายในคอมพิวเตอร์
  - ทำหน้าที่ในการเป็นตัวกลางการเชื่อมต่อระหว่างคอมพิวเตอร์และผู้ใช้งาน
  - เป็นตัวกลางในการเชื่อมต่อกันระหว่างซอฟต์แวร์และฮาร์ดแวร์ของคอมพิวเตอร์
  - คอยตรวจสอบข้อผิดพลาดที่เกิดขึ้นได้ภายในคอมพิวเตอร์
  - จัดการกับข้อผิดพลาดที่เกิดขึ้นได้ภายในคอมพิวเตอร์
  - ทำหน้าที่ในการป้องกันการเข้าถึงที่ไม่ได้รับอนุญาต
2. What is an Operating Systems?
  - ระบบปฏิบัติการคือโปรแกรมหรือซอฟต์แวร์ระบบที่ดูแลและจัดการฮาร์ดแวร์และซอฟต์แวร์ของคอมพิวเตอร์ รวมไปยังการจัดการบริการต่างๆให้กับคอมพิวเตอร์ ไม่ว่าจะเป็นเรื่องหน่วยความจำ ลักษณะการทำงานของแต่ละโปรแกรม โดย OS จะเริ่มต้นทำงานหลังจากเริ่มต้นเปิดคอมพิวเตอร์และจะทำหน้าที่ดูแลจัดการต่างๆ และจะทำหน้าที่เป็นตัวกลางระหว่างผู้ใช้งานและคอมพิวเตอร์ผ่านตัว User Interface ได้ อย่างเช่น CLI (Command Line Interface) เป็นต้น
3. What are the Operating System Evaluation?
  - ความเร็ว/เสถียร (Performance) โดยทำการทดลองระหว่าง OS ที่แตกต่างกันโดยจะมีการควบคุม environment ให้เหมือนกัน โดยทำ task เดียวกัน และวัดจากเวลาหรือจำนวน ที่ OS นั้นๆทำได้
  - ความปลอดภัย (Security) สามารถวัดได้จากการที่ทำ Vulnerlability accessment ยกตัวอย่างเช่น การแสกนหาช่องโหว่ที่มีคนค้นพบอยู่แล้ว, แสกนหามัลแวร์, แสกนหาอัพเดทที่ถูกข้ามไป หรือไม่ว่าจะเป็นในหลักที่ OS บางตัวเป็น Opensoure ซึ่งก็จะมีแนวโน้มในการมีความปลอดภัยที่สูงกว่า
  - ความง่ายต่อการใช้งาน (Availability) โดยจะสามารถวัดได้จากความพึงพอใจของผู้ใช้งานของแต่ละ OS นั้นๆ
  - ความสามารถในการทำงานร่วมกับ software ต่างๆ (Integrability) โดยจะสามารถวัดได้จากจำนวนซอฟต์แวร์บางตัวที่แต่ละ OS สามารถทำงานรวมกันได้

## The Kernal Abstraction 

#### THE PAST -> "Single Task System"
- no library -> has to write everything by yourself
- เขียนโปรแกรมเพื่อควบคุม HW อย่างเดียวเลย eg. ตอนเขียนภาษาซีแล้วไม่มี .h มาให้
- few years later...
- **PROGRAM -CALL-> Library -> HW.** (program can still control HW directly) ทำให้เกิดความง่ายกับ dev ในการเขียนโปรแกรม
- few more year later... (~1969)
- add **Queue Manager (Batch System)** ระหว่าง HW กับ Programs คือ เพิ่มการโหลดล่วงหน้าไว้ให้กับโปรแกรมถัดๆไป
#### THE PRESENT -> "Multitasking System"
- ~1970s
-  มีหลายโปรแกรม (P1, P2, P3, ..A) สามารถทำงานพร้อมกันได้บน *something* (ตอนเรียนน่าจะฟังไม่ทัน)

### UNIX Structure
![](https://media.discordapp.net/attachments/1014398974649708624/1045696618374123560/image.png)

### User/Kernel (Priviledge Mode)
![](https://media.discordapp.net/attachments/1014398974649708624/1045696896615862396/image.png)
- เป็นเหตุผลที่ window95 ไม่ประสบความสำเร็จ -> it allows user to directly use the hardware

### GOALS of OS
- **Protecting Process and Kernel**
- การที่ run multiple programs จำเป็นต้อง
	- keep them from interfering with the OS - Kernel
	- keep them from interfering with each other - process
	- ถ้าเกิดการฝ่าฝืนกฏเกณฑ์ Kernel จะพยายามทำการ kill process นั้นทิ้ง ถ้าเกิดไม่สามารถ kill  ได้ก็จะเกิด the famous **BLUE SCREEN**

### Hardware Support Dual-Mode Operation
- **Kernel mode**
	- full priviledge of the hardware
	- R/W any memory, access any I/O devices, R/W any disk sector, Send/Read any packet
- **User mode**
	- limited priviledge
	- need permission
- **Priviledge Instruction**
	- only available to kernel
	- not available to user code
	- if user program attempts to execute a priviledge instruction -> exception happens, blue screen in a worst case
- **System Calls** (Trap): คล้ายๆกับ Interrupt แต่ถูก invoke โดย software
	- trap = ตรวจสอบข้อมูลทุกอย่างก่อนที่จะส่งไปยัง system library เพื่อไม่ให้เกิด error
	- ทำให้เกิดการ transfer from **user mode -> priviledge mode**
- **Limits on memory accesses**
	- prvent user code from overwriting the kernel
- **Timer**
	- regain control from a user program in a loop

![](https://media.discordapp.net/attachments/1014398974649708624/1045699532941439077/image.png?width=988&height=685)

### Virtual Machine (VM)
- Software emulation of an abstract machine
  - give programs illusion they own the machine
  - make it look like HW has feature you want
- 2 types of VM
  - **Process VM**: supports the execution of a single program
  - **System VM**: supports the execution of an entire OS
- GOALs:
  - Provide an isolation to a program
    - processes unable to directly impact other processes : boundary to the usage of a memory
    - fault isolation : bugs cannot crash the computer
  - Portability (Program)

### Process Abstraction
- **Process**: คือ instance ของ program, running with limited rights
- **Thread**: คือ sequence of instructions within a process
	- เปรียบได้กับ microprocessor เสมือน
- address space -> RAM

### Process
![](https://media.discordapp.net/attachments/1014398974649708624/1045700660898828308/image.png)

- **Process Control Block (PCB)** อยู่ใน Kernel ที่จะเก็บ
	- Status
	- Registers
	- Process ID (PID), user, executable, priority
	- Execution time
	- Memory space, translation table
- Kernel Scheduler maintains data structure containing the PCBs
- Scheduling algorithms selects the next process to run

### In-Class Activity
1. การเปลี่ยนแปลงจาก single task -> multitask จะต้องเพิ่มหรือปรับแต่งใน OS ได้แก่
 - **Answer** : **Protection**
	- ***Protection of the resource for each program (ENFORCE)***
	- แต่ละโปรแกรมก็จะทำงานได้เฉพาะ resource ที่ได้รับมอบหมายเท่านั้น
	- Queue -> resource manager, queue manager
	- Library -> system library
	- **Protection of HW** -> Partition
	- Additional -> fully control of hardware (ไม่มีส่วนไหนของ SW ที่ติดกันกับ HW เลย)
2. การ protect process และ kernel ทำให้เกิด impact อะไรกับระบบบ้าง และยังต้อง protect อะไรอีกบ้างเพื่ออะไร
	- **WHY?**
		- Reliability: bugg programs only hurt themselves
		- Security and Privacy: trust programs less
		- Fairness: enforce shares of disk, CPU
	- **HOW?**
	 - HW
	    - Memory address translation
	    - Dual mode operation
	      - Priviledge/non-priviledge mode
	        - ***System calls*** : a way in which a computer program request a service from the kernel
	  - SW
	    - Process
	      - System calls

### Mode Switch
- User -> Kernal
  - **Interrupts** : ถูก trigger ด้วย timer และ I/O devices
	- โดยจะมีการส่ง Interrupt พร้อมกับหมายเลข โดย kernel จะมี function สำหรับการตอบกลับในแต่ละเลขของ Interrupt อยู่
	- โดยใน kernel จะมีการเก็บ array of pointer ที่เรียกว่า INT Vector สำหรับเก็บ addrs. ของ response function กลับไปยัง user mode
  - **Exceptions** : triggered by a unexpected program behavior or malicious behavior
  - **System calls** (protected procedure call) : ถูก request ด้วย program ไปยัง kernel เผื่อขอทำงานภายใต้ kernel priviledge
    - How วิธีใช้ syscall
      - Trap exception : เพื่อที่จะไปใช้ exception handler in kernel
      - x86 : SYSENT(U->K), SYSEXT(K->U)
- Kernel -> User
  - **New process/new thread start**: jump to first instruction in program/thread
  - **Return from interrupt, exception, system call**: resume suspended execution
  - **Process/thread context switch**: resume some other process
  - **User-level upcall (UNIX signal)**: ashychronous notification to user program

### Implementing Safe Kernel Mode Transfers
- **Carefully** จำเป็นต้องเก็บข้อมูลของคำสั่งที่กำลังทำอยู่ (PC, SP)
- Must handle weird/buggy/malicious user state
	- syscalls with null pointers
	- return instruction out of bounds
	- user stack pointer out of bounds
- ไม่ควรที่จะให้ user program ที่ bug, malicious ทำให้ kernel พังไม่ได้
- user program ควรที่จะต้อง **รับรู้** ว่ามีการเกิด interrupt (**Transparency**)

### Device Interrupts
- OS kernel จำเป็นต้องมีการติดต่อสื่อสารกับ physical devices
- Device operate ashychronously from the CPU
	- **Polling**: kernel รอ I/O เสร็จก่อน
	- **Interrupts**: kernel สามารถทำงานอื่นได้ในเวลาเดียวกัน
- Device access to memory
	- I/O: CPU reads and writes to device
	- Direct memory access (DMA) by device
	- Buffer descriptor: sequence of DMA's
		- e.g. packet header and packet body
	- Queue of buffer descriptor

### How does Interrupts works?
- Interrupts signals -> copy PC, SP to Kernel's Stack ของ process ปัจจุบัน
- PC -> Interrupt Handlers -> do interrtups process
- Interrupts finished -> Copy PC, SP from Kernel's Stack back to micro. processor. PC&SP
- Process conitnue

### How do we take interrupts safely
- **Interrupt vector**: จำกัด number of entry points into kernel
- **Kernel interrupt stack**: Handler works regardless of state of user code
- **Interrupt masking**: Handler is non-blocking
	- เก่า: ไม่ยอมให้เกิด interrupt ซ้อน
	- ใหม่: มี priority เกิดซ้อนได้
- **Atomic transfer of control**:
	- **"Single instruction"**: ไม่ให้เกิด interrupt ระหว่างนี้ได้
		- PC, SP, Memory protection, Kernel/user mode
- **Transparent restartable execution**:
	- User program does not know interrupt occurred

![](https://media.discordapp.net/attachments/1014398974649708624/1045711459998519428/image.png?width=1022&height=685)

### The Kernel Stack
- Interrupt handlers want a stack
- System call handlers want a stack
- Can't just use the user stack?
  - เพราะว่าความปลอดภัยและความเสถียรของระบบ
- Solution: **two-stack model**
  - each OS thread has kernel stack plus user stack
  - place to save user registers during interrupt

![](https://media.discordapp.net/attachments/1014398974649708624/1045712263010582538/image.png)

### Interrupt Stack
- per-processor, located in kernel (not user) memory (usually a process/thread has both: kernel and user stack)
- case study: x86 Interrupt
  1. Save current stack pointer (SP)
  2. Save current program counter (PC)
  3. Save current processor staus word (condition codes)
  4. Switch to kernel stack; put SP, PC, PSW on stack
  5. Switch to kernel mode
  6. Vector through interrupt table
  7. Interrupt handler saves registers that it might clobber
  - 1-4. => Automic Transfer Control == 1 Instrcution
  
### Hardware support: Interrupt Control
- interrupt processing **not visible** to the user process
	- occurs between instructions, restarted transparency
	- no change to process state
- Interrupt handler invoked with interrupts `disabled`
	- re-enabled upon conpletion
	- non-blocking
	- ***pack up in a queue and pass off to an OS thread for hard work***
		- ***wake up existing OS thread***
- HW may have multiple levels of interrupts
	- Mask off (disable) lower priority interrupts
	- Certain Non-Maskable-Interrupts (NMI)
		- ไม่สามารถห้ามให้เกิด interrupt ได้

### Kernel System Call Handler
- HOW
- **user mode**
	- code[syscall] -> microProc[fn(x,y)]
	- command SYSENT
- **kernel mode**
	- store PC, SP, ... in kernel stack
	- fn(x,y) -> check params
	- valid store in stack + call the wanted func

### Four Fundamental OS Concepts
- **Thread** (virtual microprocessor): PC, register, Execution Flags, Stack
- **Adress Space**: POV of program's view of memory is distinct from physical machine
- **Process** (an instance of a running program): Address Space + One or more Threads
- **Dual mode operation / protection**
	- only the "system" can access certain resources
	- combined with translation, isolates programs from each other

## The Process and Programming Interface

### Shell
> a shell is a job control system
- เป็นตัวเชื่อมระหว่าง user กับ kernel (system) หรือเป็น UI ให้ user เข้าถึง kernel ได้
- allows programmer to create and manage a set of programs to do some task
- Windows, MacOS, Linux all have shells

### Windows CreateProcess
- shell use this system call to create a new process to run a program (syscall สำหรับการสร้าง new process เพื่อที่จะรันโปรแกรม)

![Windows CreateProcess](https://media.discordapp.net/attachments/1014398974649708624/1017263997382311936/IMG_20220908_094337.jpg?width=767&height=640)
1. สร้างและ initialized **process control block (PCB)** ใน kernel
2. สร้างและ initialized new address space (ฝั่ง user)
3. load program ลงไปที่ address space
4. copy arugments into memory in the address space
5. initialized the hardware context to start execution at **start**
6. แจ้ง scheduler และ register process และรอการรัน

### UNIX Process Management
- **UNIX fork** : syscall to create a copy of the current process, and start running it
	- ***no arguments***
	- สร้าง child process ที่มี PID ต่างกัน
- **UNIX exec** : syscall to change to program being run by the current process
	- run process ใหม่ที่กำหนด ทับ current process (pid เดิม)
- **UNIX wait** : syscall to wait for a process to finish
- **UNIX signal** : syscall to send a notification to another process

![UNIX Process management](https://media.discordapp.net/attachments/1014398974649708624/1017266623477973063/unknown.png)

### Activity #2 What does this code print?
![Statement](https://media.discordapp.net/attachments/1014398974649708624/1017277855077498940/unknown.png)
- Ans: สำหรับ child process จะเกิดการมีการแสดงผล สมมติให้มี pid=101 "I am process 101"
สำหรับ parent process จะเกิดการแสดงผล สมมติให้มี pid=100 "I am parent of process 101"

### Implementing UNIX fork()
- สร้างและ initialized **process control block (PCB)** in the kernel
- create new address space
- ใส่ค่าของ address space ของ parent ไปที่ address space ของ child process
- สืบทอด execution context มาจาก parent
- ส่งข้อมูลไปบอกยัง scheduler และ register process ต่อไป

### Implementing UNIX exec()
- load program into the current address space
- copy args into memory in the address space
- initialize the hardware context to start execution at **start**

### In-Class Activity: Can these UNIX syscall return error ?
- fork() สามารถ return error ได้ ถ้าเกิดพื้นที่ storage มีไม่เพียงพอ
- exec() สามารถ return error ถ้าเกิด pid ที่ระบุไม่มีอยู่จริง, ไม่สามารถเข้าถึงได้, ไม่มี permission หรือ ระบบไม่มี resource เพียงพอที่จะรันได้
- wait() สามารถ return ทันทีเลยได้ ถ้าเกิดว่า state ของ child process เกิดการเปลี่ยนแปลงไปก่อนหน้านี้แล้ว ไม่ว่าจะเป็นการถูก terminated, ถูกหยุดด้วย signal, หรืออื่นๆ

### UNIX I/O
- **Uniformity**
	- all operations on all flies, use the same set of **syscalls** : open, close, read, write
- **Open before use**
	- Open returns a handle (file descriptor) for use in later calls on the file
- **Byte-oriented**
- **Kernel-buffered read/write**
- **Explicit close**

### UNIX File System Interface
- **Swiss Army Knife** : มีดพับ มีเครื่องมือหลายอย่าง
- open the file, return file descriptor -> Options:
	- if file doesn't exist, return err
	- if file doesn't exist, create file and open it
	- if file does exist, return err
	- if file does exist, open file
	- if file exists but isn't empty, nix it then open
	- if file exists but isn't empty, return err

### Why not seperate syscalls for open/create/exists ?
- เพราะว่าในกรณีที่มีอีกโปรแกรมนึงสามารถทำงานซ้ำได้ อาจจะเกิดการสร้างไฟล์ที่ซ้ำซ้อนกันได้ และถ้ารวมทั้งสาม syscall เข้าด้วยกันจะเป็นการทำให้ไม่มีช่องว่างสำหรับการเรียกใช้งาน syscall ตัวอื่นมาแทรกได้

### In UNIX
- a program can be a file of commands (bash script ?)
- a program can send its output to a file (pipe |, stdout)
- a program can read its input from a file (stdin)
- the output of one program can be the input to another program (find . | fzf)

### Interprocess Communication
- **Producer-consumer**
	- Output of one program -> input of another program
		- One-way communication
		- Pipe |
- **Client-server**
	- Two-way communication
- **File system**
	- Write data to a file then read file as an input
	- Reader and writer are not need to running at the same time

### Operating System Structure
- **Monolithic Kernel**
- **Microkernel**

![OS Archictecture](https://media.discordapp.net/attachments/1014398974649708624/1017285038095728650/unknown.png)

## Concurrency

### Previous Chapter
- **1 Process / 1 Thread**
- เป็นกระบวนการที่ Overhead มาก (การโยกย้ายระหว่าง parent - child process etc.) <- boundary of process
- ทำให้เกิด new concept -> **Multithread** (ซึ่งถูกใช้ในปัจจุบัน)

### Multithread
- reduced overhead from 1 Process / 1 Thread concept
- ใน Process ก็จะสร้าง stack ใหม่ขึ้นมา แล้ว copy แค่ค่า PC, SP โดยไม่ต้อง copy code เพิ่มเติม
- **ปัญหา**: ถ้าเกิด Bug ก็จะชิบหายวายวอด เพราะว่า code แต่ละ thread มันอยู่ใน boundary เดียวกัน
- meanwhile in **KERNEL**
	- PCB (Process Control Block)
	- TCB + [Stack] (Thread Control Block)
	- TCB + [Stack] (Thread Control Block)
- **Scheduler** ทำหน้าที่เป็นตัวจัดการเวลาการทำงานของแต่ละ Thread แต่มนุษย์ไม่สามารถรู้ได้ว่า Thread ไหนจะทำงานลำดับต่อไป

### Motivation
- OS need to be able to handle multiple things happening at the same time (concurrency)
	- Process execution, interrupts, background tasks, system maintenance
- Threads are an abstraction to help bridge this gap

### WHY Concurrency ?
- Servers -> multiple connection handled simultaneously
- Parallel programs -> better performance
- Program with UI -> user responsiveness while doing computation
- Network and disk bound programs -> hide network/disk latency

### Definitions
- **Thread** -> มองได้ง่ายๆว่า เป็นตัวที่แยกออกมามี PC, SP เป็นของตัวเองอีก
	- Single execution sequence
	- Seperately schedulable
- Protection is an orthogonal concept: Thread ของ process เดียวกันก็ access memory ของ thread ที่เป็น process เดียวกันได้
	- can have one or many threads per protection domain

### Threads in the Kernel at User-Level
- **Multi-threaded kernel**
- **Multiprocess kernel**
- **Multiple multi-threaded user processes**

### Thread Abstraction
- infinite number of processors
- threads execute with variable speed
	- แต่ละ thread ทำงานด้วยความเร็วที่ไม่เท่ากัน (ขึ้นอยู่กับการที่ถูกเลือกโดย Scheduler)

#### Programer vs. Processor View
![Programmer's view vs Processor View](https://media.discordapp.net/attachments/1014398974649708624/1019803771649400852/unknown.png?width=1028&height=657)

### Thread Operations
- **thread_create(thread, func, args)**
	- สร้าง new thread เพื่อรัน func
- **thread_yield()**
	- relinquish processor voluntarily
- **thread_join(thread)**
	- ใน parent thread รอจนกว่า child จบการทำงาน 
- **thread_exit()**
	- quit thread and clean up, wake up joiner if any

![Example code of thread](https://media.discordapp.net/attachments/1014398974649708624/1019805704950927360/unknown.png?width=875&height=657)
#### results:
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
	- kernel thread operations available vai **syscall**
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

## Synchronization

### Recap
- การทำงานแยก Thread จะมีการเข้าถึง Shared Resource ไว้ให้แต่ละ Thread เข้าถึงได้
- ถ้าเกิดมี Thread นึงทำการ write ไปที่ Shared Resource แล้วมี Thread อื่นมา Read ในที่ๆเดียวกัน -> **Race Condition**
- Solution -> **Synchronization** ทำให้แต่ละ Thread รู้จังหวะสำหรับการอ่านและเขียนใน Shared Resource

### Synchronization Motivation
- When threads cocurrently read/write shared memory, program behaviour is undefined
	- Two threads write to the same variable; which one should win?
- Thread schedule is non-deterministic
- Complier/hardware instruction reordering
	- เปลี่ยนลำดับการประกาศตัวแปร
- Multi-word operations are not atomic (คำสั่งที่ทำงานนานเกินไป)
	- ไม่มีสมบัติความ Atomic คือการทำงานแบบ either completely or none at all

### Definitions
- **Race Condition**: output of concurrent program depends on the order of operations between threads
- **Mutual Exclusion**: Only one thread does a particular thing at time
	- ห้าม 2 or more thread ทำงานในส่วนๆนึงของโค้ดในเวลาเดียวกัน
	- **Critical section**: piece of code that only one thread can execute at once
		- คือในส่วนของ **Shared Resource** ไปโดยปริยาย
- **Lock**: prevent someone from doing something
	- Lock before entering critical section, before accessing shared resource
	- Unlock when leaving, after done accessing shared resource
- **Starvation**: ไม่เกิดการทำงานในส่วนของ shared resource เลย

### TOO MUCH MILK
- Solution is complicated
- Modern copliers/architectures reorder instructions
- Generalizing too many threads/processors

### Activity I
![](https://media.discordapp.net/attachments/1014398974649708624/1027419417597968394/unknown.png)
- **Answer**: สามารถเกิดได้ เพราะว่าอาจจะเกิดปัญหาจากการ reordering instruction ของ ตัว pinitialized = true ก่อนประกาศค่าฟังกชั่นของ p จริงๆ ทำให้สามาถเกิด panic ได้ใน thread ที่ 2

### Locks
- Lock::acquire รอจนกว่า lock จะเปิดจากนั้นก็ทำการ acquire the lock
- Lock::release relase lock, waking up anyone waiting for it
1. At most one lock holder at a time (safety)
2. If no one holding, acquire gets lock (progress)
3. If all lock holders finish and no higher priority waiters, waiter eventually gets lock (progress)
- Locks ทำให้ concurrent code -> much simpler
![](https://media.discordapp.net/attachments/1014398974649708624/1027423608517181461/unknown.png)
- ทำให้เกิดส่วนที่เป็น **Critical Section** และเกิดสภาวะที่เรียกว่า **Mutual Exclusion**

### Rules for using Locks
- Lock is intially free (เริ่มต้นมาจะมีสถานะเป็น ว่าง สามารถถูกนำไปใช้งานได้)
- Always acquire before accessing shared resource structure
	- beginning of procedure
- Always release after finishing with shared resource
	- end of procedure
	- **only the lock holder can release**
- Never access shared resource without lock -> **Danger!**

### Semaphores
- คือ object ชนิดนึงที่มีค่า non-negative integer value
	- P() atomically waits for value to become > 0, then decrement
		- เปรียบได้เหมือน lock::acquire
	- V() atomically increments value (waking up waiter if needed)
		- เปรียนได้เหมือน lock::release
- Semaphores are like integers except:
	- Only operations are P and V
	- Operations are atomic
		- ถ้ามี value = 1; ใช้ P() * 2 จะทำให้ค่าเป็น 0 แล้วจะกลายเป็นตัว waiter
- useful for **Unlocked wait**: interrupt handler, fork/join

### Condition Variables
- Waiting inside a critcal section
	- called only when holding a lock
- **Wait**: atomically relase lock and relinquish processor
	- reaccquire the lock when awake
- **Signal**: wake up a waiter, if any
- **Broadcast**: wake up all waiters, if any

### Atomic
- คือคุณสมบัติที่การทำงานของ operation นึงจะทำงานอย่าง either completely or none at all
- จะไม่มีการ context switch ระหว่าง instruction
- ว่าง่ายๆคือ 1 Operation = 1 Instruction => Atomic

### Summary after presentation
- อาจารย์ต้องการให้ประยุกต์ใช้ Lock + Condition Variable (Monitor.Wait(), Monitor.Pulse(), ...)
- มันจะทำให้โปรแกรมมีความ Thread safe มากกว่า version 5 ของเรา
- ใน Csharp อาจจะมีการประยุกต์ใช้ Queue ได้เลยแต่อาจจะจำเป็นต้องใช้ Queue.Synchonize เพื่อให้ โปรแกรมมีความ Thread safe ได้
- `Queue TS = Queue.Synchronize(new Queue())` <- ทำให้ Queue เป็น Thread safe
- Shared resource => เกิดปัญหา race condition
- race condition -> แก้ได้ด้วย Lock (Synchronization)
- การใช้ Lock -> Starvation, Deadlock

### Deadlocks
- มีปัจจัยในการก่อให้เกิดคือ
1. Limit access to resources (มีการใช้ Lock) *ไม่เสมอไป*
2. Independent request: ยกตัวอย่างเช่น 
	- มีสอง thread ที่ต้องการ acquire resource ตัวเดียวกัน แบบสลับขั้นตอนกัน
##### Thread1
```Thread1
A.acquire()
<-- context switch here
B.acquire()
B.release()
A.release()
```
##### Thread2
```Thread2
B.acquire() <-- this line runs
A.acquire() <-- deadlock happens here
A.release()
B.release()
```
	- **wait while holding**: ในกรณีที่ thread นั้น wait แต่มีการถือ "กุญแจ" ติดไปด้วย
##### Thread1
```Thread1
A.acquire()
t1.wait() ---> มันรอ แต่ thread2 ไม่สามารถทำงานได้เพราะว่า "กุญแจ" ยังอยู่ที่ thread1 อยู่
A.release()
```
##### Thread2
```Thread2
A.acquire() --> cant run this line cause A is still allocated to thread1
t1.signal()
A.release()
```
3. Circular chain of request: มีการขอ requset เข้าเป็นวงกลม ทำให้เกิด deadlock เพราะว่า resource ถูก allocated ไปให้ thread อื่นก่อนแล้ว
t1 -> A , t2 -> b, t3 -> c, t4 -> d, but when t1 -> b "deadlock" happens
4. No Pre-Emption

## Scheduling

### Main points
- Scheduler คือตัวที่ทำหน้าที่ในการจัดการ scheduling policy สำหรับการบอกว่า what to do next, ในตอนที่มีหลาย thread ที่พร้อมจะทำงาน
- definitions: response time, throughput, predictability
- Uniprocessor policies
	- FIFO, round robin, optimal
	- multilevel feedback as approximation of optimal
- Multiprocessor policies
	- Affinity scheduling, gang scheduling
- Queueing theory: can you predict/improve a system's response time?

### Definitions
- **Tasks/Job** : user request eg. mouse click, web request, shell command etc.
- **Latency/response time**: เวลาที่ใช้ในการทำงานสำหรับงานๆหนึ่ง
- **Throughput**: how man tasks can be done per unit of time
- **Overhead**: how much extra work is done by the scheduler
- **Fairness**: how equal is the performance received by different users
- **Predictability**: how consistent is the performance over time
- **Workload**: set of tasks for system to perform
- **Preemptive scheduler**: if we can take resources away from a running task
- **Work-conserving**: resource is used whenever there is a task to run
- **Scheduling algorithm**:
	- รับ workload เป็น input
	- กำหนดว่า tasks ไหนจะทำงานก่อน
	- มี output คือ  performance metric (throughput, latency)
	- only preemptive, work-conserving schedulers to be considered

### First Int First Out (FIFO)
- คือการจัดให้ tasks รันตามลำดับที่เข้ามา
- example: memcahced (facebook cache of friend lists, etc.)

### Shortest Job First (SJF)
- ตามชื่อเลยคือ ทำงานที่มีงานน้อยที่สุดก่อน ส่วนมากจะเรียกว่า **Shortest Remaining Time First (SRTF)**

![](https://media.discordapp.net/attachments/1014398974649708624/1035030643945508914/unknown.png?width=945&height=685)

### QnA
- Claim: SJF is optimal for average response time - Why?
	- A: ในกรณีที่มีงานที่มีขนาดใหญ่ก็จะให้ไปทำงานนั้นๆภายหลัง เพื่อเป็นการลด latency ลง ไม่ให้งานใหญ่ไปทำให้ งานที่เหลือมี latency เพิ่มขึ้น
- SJF Downside?
	- A: เกิด Starvation ของ bigger tasks ถ้าเกิดมี smaller tasks เข้ามาในคิวเรื่อยๆ + irl เราไม่สามารถวัดขนาดของ task อย่างแน่นอนได้
- Is FIFO ever optimal?
	- FIFO จะเป็น alogrithm ที่ optimal ก็ต่อเมื่อ งานที่เข้ามามีขนาดเท่าๆกันทั้งหมด  
	- Pessimal ? : Pessimal case ในกรณีที่มีการเรียงของงานขนาดใหญ่เข้ามาทำก่อน ทำให้เป็นการเพิ่ม latency ของ job อื่นๆที่เกิดในภายหลัง

### Round Robin
-  มีการกำหนดคาบเวลาขึ้นมา เรียกว่า **time quantum**
	- ถึงแม้ว่า tasks นั้นจะยังไม่เสร็จ แต่ถ้าเกิดหมดเวลาแล้ว ก็ต้องไปต่อท้ายแถว วนไป
-  เลือก time quantum อย่างไรให้เหมาะสม
	- ถ้า time quantum ใหญ่ไป -> ก็ไม่ต่างกันกับ FIFO
	- ถ้า time quantum น้อยไป -> one instruction?? -> too much overhead (context switch) -> ถูกมองเป็น SJF 
- RR -> **เป็นการแก้ปัญหา Starvation เนื่องจากมีการเข้าถึงงานทุกๆงานอย่างเท่าๆกัน**

![](https://media.discordapp.net/attachments/1014398974649708624/1035037844508524564/unknown.png?width=824&height=685)

- RR > FIFO : ไม่เสมอไป เพราะว่าในกรณีที่ task ใน workload มีขนาดเท่ากันหมด ใน RR ถ้าเกิดมีการแบ่งเวลาในมี time quantum น้อยๆ ก็จะส่งผลให้เกิด average response time ที่มากขึ้น
- **RR** = Fairness ? in some sense yes, เพราะว่า แต่ละ job จะได้เข้าถึง cpu อย่างเท่าเทียมกัน ก็มาจากที่หลังหมดเวลา time quantum ก็จะต้องไปต่อท้ายคิว

### Mixed Workload
![](https://media.discordapp.net/attachments/1014398974649708624/1035044981456523284/unknown.png?width=1255&height=685)
- เกิดปัญหาจาก job ที่มีการใช้ Lock หรือเสร็จก่อนหมดเวลา time quantum 

### Max-Min Fairness
- เป็น algorithm ที่ balance ระหว่าง repeating tasks:
- one approach: maximize the minimum allocation given to a task
	- if any taskn need less than an equal share, schedule the smallest of these first
	- split the remaining time using max-min
	- if all remaining tasks need at least equal share, split evenly

### Multi-level Feedback Queue (MFQ)
- **Goals**:
	- Responsiveness
	- Low overhead
	- Starvation freedom
	- Some tasks are high/low priority
	- Fairness (among equal priority tasks)
- มีชุดของ Round Robins Queues: แต่ละคิวก็จะมีค่า priority ที่แตกต่างกัน 
- คิวที่มี High Priority จะมี short time slices ก็ตรงข้ามกันกับ Low Priority
- Scheduler จะเลือก thread แรกจาก highest priority queue
- task ที่ทำอยู่บน highest priority queue ถ้าเกิด time slice expired, task จะถูก drop one level
- แต่ละ job จะมี timeout tag ติดไปด้วย ทำให้เป็นการแก้ปัญหา starvation ได้ ถ้าเกิด timeout ก็จะปรับ priority ขึ้นไปที่ละขั้น

![](https://media.discordapp.net/attachments/1014398974649708624/1035048115708903527/unknown.png)

### Uniprocessor Summary
- FIFO is simple and minimizes overhead
- ถ้าแต่ละ task มีขนาดที่แตกต่างกันออกไป -> FIFO can have very poor average response time
- tasks are equal in size -> FIFO is optimal
- SJF ถูกมองว่า optimal ในมุมมองของ processor ในด้านของ average response time
- SJF จะแย่มากๆในมุมมองของ variance in response time
- ถ้า task มีขนาดที่แตกต่างกัน RR จะใกล้เคียงกับ SJF
- ถ้า task ขนาดเท่าๆกัน RR จะมี average time ที่**แย่**มากๆ
- RR and Max-Min Fairness พยายามที่จะหลีกเลี่ยง Starvation
- MFQ achieves responsivesness, low overhead, and fairness

## Address Translation
- ถือว่าเป็น Overhead เพราะเป็นงานที่ user ไม่ได้สั่ง
- Address Translation Concept - จะเปลี่ยนจาก virtual address to a physical address ได้อย่างไร
	- Algorithm ต้องใช้เวลาน้อย
- Flexible Address Translation
	- base and bound
	- segmentation
	- paging
	- multilevel translation
- Efficient Address Translation
	- Translation Lookaside Buffers (TLB)
	- Virtually and physically addressed cahces

### Address Translation Goals
- Memory protection: ป้องกันไม่ให้แต่ละ process ไป "กวน" กันได้
- Memory sharing: ยกตัวอย่างคือ เปิดโปรแกรมเดียวกัน ก็จะมีการ share กันระหว่างส่วน code ของโปรแกรม
- Sparse addresses: การจัดการในส่วนของ heap/stack
- Efficiency
	- memory placement
	- runtime lookup
	- compact translation tables

### Virtually Addressed Base and Bounds
- Base: คือ addr. เริ่มแรกที่ถูกจัดให้ process นั้น (physical addr. แรกที่ถูก assign)
- Bounds: ขนาดของ addr. ที่จองไว้
- **last physical address** = base addr. + bound
- **physical address** = virutal address + base address
- virual address จะถูกเช็คกับค่า bound ว่ายังอยู่ในขอบเขตที่ได้รับมาอยู่หรือป่าว 

![](https://media.discordapp.net/attachments/1014398974649708624/1037557105151975475/image.png?width=1194&height=685)

- **Pros**
	- Simple
	- Fast (2 register, adder, comparator)
	- Safe
	- Can relocate in physical memory without changing process
- **Cons**
	- can't keep program from accidentally overwriting its own code
	- can't share code/data with other processes
	- can't grow stack/heap as needed
	- อาจจะเกิด fragment เป็นช่องว่างๆไว้ จำเป็นอาจจะต้องมีการทำ de-fragment เพื่อเลื่อนให้มีช่องว่างที่มากขึ้น

### Segmentation
- Segmentation is a **contigious region of virtual memory**
	- เป็นวิธีการที่มีพื้นฐานอยู่บน base & bounds
	- จะมี 4 base & bounds -> code, data, heap, stack
- แต่ละ process มี *segment table* (ใน hardware)
- segment จะสามารถถูก located ในตำแหน่งใดก็ได้ใน physical memory
	- แต่ละ segment จะมี start, length, access permission (เป็นการทำ safety)
- process สามารถ share segments ได้
	- มีค่า start, length เท่ากัน access permission จะเหมือนกันหรือไม่ก็ได้

![](https://media.discordapp.net/attachments/1014398974649708624/1037565264981655692/image.png?width=1031&height=685)

#### Example of Segmentation Address Translation
![](https://media.discordapp.net/attachments/1014398974649708624/1037567876011397150/image.png?width=902&height=685)

- Example: จาก Virtual Memory จากโจทย์ 2bit of segment, 12 bit offset
	- main: (0)240 -> (00)00 0010 0100 0000 จะมี segment = 0, offset = 0x(240)
		- physical memory = 0x(4000) + 0x(240) = 0x(4240)
	- x: 1108 -> 0001 0001 0000 1000 -> segment = 1, offset = 0x(108)
		- physical memory = 0 + 0x(108) = 108
- **Pros**
	- can share code/data segments between processes
	- can protect code segment from being overwritten
	- can transparently grow stack/heap as needed
	- can detect if need to copy-on-write
- **Cons**
	- complex memory management
		- มีการหาพท. ว่างที่เพียงพอสำหรับ 4 ชิ้นส่วน (code, data, heap, stack) ทำได้ยาก
	- may need to rearrange memory from time to time to make room for new segment or growing segment
		- external fragmentation: พท.รอบๆ segment ที่ไม่ได้ใช้งาน

###  Paged Translation
- จะมีการแบ่ง physical memory ออกเป็น block ที่มีการ fixed units -> **"Pages"**
- ทำให้การหา page ที่ว่างทำได้อย่างง่าย
	- bitmap allocation: 00111111100001110
	- แต่ละ bit จะแสดงถึง 1 physical page frame
- แต่ละ process จะมี page table เป็นของตัวเอง
	- เก็บใน physical memory
	- pointer to page table start, page table length
-  จะเป็นการ map ระหว่าง virtual page กับ frame ของ page ใน physical memory

![](https://media.discordapp.net/attachments/1014398974649708624/1037575894736322691/image.png?width=748&height=685)

#### Implementation
![](https://media.discordapp.net/attachments/1014398974649708624/1037576360715096094/image.png?width=822&height=685)
- (page#)(offset) -> (frame)(offset)
![](https://media.discordapp.net/attachments/1014398974649708624/1037577177446760509/image.png?width=788&height=685)

- **Pros**
	- แก้ปัญหาของ Segmentation ในการหาพื้นที่ว่าง -> bitmap allocation
	- no external fragmentation -> fixed units "page"
- **Cons**
	- ความ complex
	- การใช้พื้นที่ ที่มีประสิทธิภาพน้อยกว่าวิธีก่อนหน้า
	- Sparse Address Spaces
		- การเพิ่มแต่ละ page เพื่อ รองรับ dynamic segments
		- ทำให้ page table จะมีขนาดใหญ่มากก

### Multi-level Translation
- Tree of translation tables
	- paged segmentation
	- multi-level page tables
	- multi-level paged segmentation
- fixed-size page as lowest level unti of allocation
	- efficient memory allocation 
	- efficient for sparse addresses
	- efficient disk transfer
	- easier to build translation lookaside buffers
	- efficient reverse lookup
	- variable granularity for protection/sharing

### Paged Segmentation
- process memory is segmented
- segment table
- page table สำหรับ code, data, heap, stack

![](https://media.discordapp.net/attachments/1014398974649708624/1037584031358926939/image.png?width=851&height=685)

### Multilevel Paging

![](https://media.discordapp.net/attachments/1014398974649708624/1037585670983655424/image.png?width=775&height=685)
- จากรูปจะมีทั้งหมด 73 table
	- level 1 = 1
	- level 2 = 8
	- level 3 = 64
- **Pros**
	- allocate/fill only page table entries that are in use
	- simple memory allocation
	- share at segment or page level
- **Cons**
	- space overhead: one pointer per virtual page
	- many lookups per memory reference

### Efficient Address Translation
- Translation Lookaside Buffer (TLB)
	- ทำการ cache address ของ virtual page ไว้ สำหรับ address ที่ทำการแปลไปไม่นาน
- cost of translation = cost of TLB lookup + Prob(TLB miss) * cost of page table lookup

### Translation Lookaside Buffers

![](https://media.discordapp.net/attachments/1014398974649708624/1037590190698528778/image.png?width=848&height=685)

#### TLB Lookup
![](https://media.discordapp.net/attachments/1014398974649708624/1037590353949237339/image.png?width=840&height=685)

### Address Translation Uses
- process Isolation: ไม่ให้ process มาใช้ memory ปนกันใน kernel
- efficient Interprocess communication: shared regions of memory between processes
- shared code segments
- program initialization: รันโปรแกรมก่อนที่มันจะไปอยู่ใน memory
- dynamic memory allocation
- cache management
- program debugging
- zero-copy I/O
- memory mapped files
- demand-paged virutal memory

## Virtural Memory
- **micro-processor** -> **cache** -> **RAM** -> **virtual memory in storage**
- ใช้บางส่วนของ storage มาเก็บข้อมูล ที่ในขณะนั้นยังไม่ถูกประมวลผลใน RAM 
- ใช้ technique ***"Address Translation"*** -> Memory Mapped File (ใช้การ copy แบบ "Zero Copy")
- Memory Mapped File -> มีการแบ่งส่วนของข้อมูลเป็น block เรียกว่า "frame"  สามารถ copy frame แล้วย้ายไปยัง frame ของ RAM ได้เลย ไม่ต้องผ่าน Buffer
- ข้อจำกัดคือ Hardware ของ ความเร็วของ Storage
- **Cache** -> เป็นที่เก็บ copy ของข้อมูลที่ทำให้ เข้าถึงได้เร็วขึ้น จะมี **"Cache Policy"** เพื่อเป็นการจัดการ cache ว่าจะ drop หรือจะแก้ข้อมูล frame ไหนไว้ ถ้าหากเกิดว่าพื้นที่ที่จัดเก็บเต็ม

### Premise
- RAM มีช่องเก็บข้อมูล **frame** อยู่ 1000 ช่อง -> เพิ่มช่องเก็บข้อมูลโดยใช้ **Virtual Memory** คือใช้ Storage(hdd, ssd) เก็บข้อมูลเพิ่มได้ โดยใช้ technique ***address translation***
- ใน table ที่ใช้ในการ map ของ address ถ้าเกิดว่ามีการเก็บข้อมูลใน virtual memory สมมติว่าคือช่องที่ 1002 ในช่อง access ต้อง mark ว่าเป็น **invalid** -> ทำให้เมื่อตอนที่จะ access data ในช่องนี้จะเกิด invalid exception -> handle ด้วยการ หาที่ว่างใน RAM แล้ว copy ข้อมูลมาใส่ (1002 -> x) จากนั้น update mapping table โดยเปลี่ยนตัว entry กับ access ให้เป็นปกติ
- ถ้าเกิด invalid exception แต่ RAM เต็ม -> จะหาช่องใน RAM ที่ตรงเงื่อนไข (**cache policy**) copy มาใส่ใน virtual memory แล้วทำการสลับกันกับ frame ที่ต้องการเข้าถึงที่เกิด invalid exception -> update mapping table เปลี่ยน access, frame# ของทั้ง 2 frame ที่ทำการ swap

### Definitions
- **Cache**
- **Cache block**: หน่วยการจัดเก็บแต่ละ block ภายใน cache
- Program tends to reference
	- **Temperal locality**: "loop"
	- **Spatial locality**: "ถัดไป" "nearby"

### Cache Concept
- Read
![](https://media.discordapp.net/attachments/1014398974649708624/1040093328651333704/image.png)
- Write
![](https://media.discordapp.net/attachments/1014398974649708624/1040093400701083728/image.png?width=1127&height=685)
	- **write through**: micro-processor สั่ง write -> เข้า cache -> write update in ram
	- **write back**: micro-processor สั่ง write -> เข้า cache <- รอจนกว่าข้อมูลชุด write ถูกอัพเดท -> write update in ram

### Memory Hiearchy
![](https://media.discordapp.net/attachments/1014398974649708624/1040094021814583316/image.png?width=1138&height=685)

### Main Points
- can we provide the illusion of near infinite memory in limited physical memory?
	- demand-paged virutal memory
	- memory-mapped files
- how do we choose which page to replace?
	- FIFO, MIN, LRU, LFU, CLOCK

### Hardware address translation is a powerful tool
- Kernel trap on read/write to selected address
	- **Copy on write**: ตัวที่ถูก write จะทำการ copy ออกไปใน free space
	- **Fill on reference**: ใน RAM จะโหลดช่องข้อมูลที่ program มีการเรียกใช้
- **Memory mapped files** คือ ไฟล์แบบพิเศษที่สามารถทำ zero copy ได้ ใช้ใน virtual memory in storage

### Demand Paging
![](https://media.discordapp.net/attachments/1014398974649708624/1040101223979827281/image.png?width=1030&height=685)

### Allocating page frame
- เลือก page ที่เข้าเงื่อนไขที่จะถอดออกมาจาก RAM 
- ไปหา page table entries ที่อ้างถึง page ที่จะเอาออก
- set each page table entry to invalid
- remove any TLB entries
- write changes on page back to disk, if necessary

![](https://media.discordapp.net/attachments/1014398974649708624/1040103188159807569/image.png?width=972&height=685)

![](https://media.discordapp.net/attachments/1014398974649708624/1040103621435609178/image.png)

![](https://media.discordapp.net/attachments/1014398974649708624/1040103787798474842/image.png?width=1106&height=685)

### Virtual or Physical Dirty/Use Bits
- most machines keep dirty/use bits in the page table entry
- physical page is
	- modified if _any_ page table entry that points to it is modified
	- recently used if _any_ table entry that points to it is recently used

### Memory-mapped files
- programming simplicity, esp for large flies
- zero-copy I/O
- pipelining
- interprocess communication

### Cache Replacement Policy
- goal: reduce cache miss

### FIFO
- replace the entry that has been in the cache the longest time
- worst case for FIFO is if a program strides through memory that is larger than the cache
- เอาตัวแรกสุดออก
![](https://media.discordapp.net/attachments/1014398974649708624/1047130856172556298/image.png)

### MIN,LRU, LFU
- **MIN**: แทนที่ cache entry that will not be used for the longest time into the future
	- optimality proof based on exchange: if evict an entry used sooner, that will trigger an earlier cache miss
- **Least Recently Used (LRU)** "เอาตัวเก่าสุดออก"
	- replace the cache entry that has not been used for the longest time in the past
	- approximation of MIN
- **Least Frequently Used (LFU)** "เอาตัวที่ใช้น้อยสุดออก"
	- replace the cache entry used the least often (in the recent past)

![](https://media.discordapp.net/attachments/1014398974649708624/1040107357860007956/image.png?width=1048&height=685)

![](https://media.discordapp.net/attachments/1014398974649708624/1040107288209412106/image.png?width=961&height=685)

### Belady/s Anomaly
![](https://media.discordapp.net/attachments/1014398974649708624/1040110983756124222/image.png)

### Recap
- **MIN** is optimal
	- replace the page or cache entry that will be used farthest into the future
- **LRU** is an approximation of MIN
	- for programs that exhibit spatial and temporal locality

### Exams
- choice, เติมคำ
	- choice 1 คำตอบ และบางข้อก็จะมีหลายคำตอบควรจะเลือกคำตอบให้ครบตามที่โจทย์กำหนด
- open -> เอาของที่สถาบันอนุญาติเข้าไปได้ทั้งหมด