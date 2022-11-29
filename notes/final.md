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

### Hardware Support Dula-Mode Operation
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
- **Transparent restarable execution**:
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
- per-processor,
	- kernel, user stack
- case study: x86 Interrupt
  1. Save current stack pointer
  2. Save current program counter
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
- HW may have multiple leves of interrupts
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
- **Adress Space**: POV of program's view of memory is distinc from physical machine
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

### Activity #3 Can these UNIX syscall return error ?
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
- open the file, return file descriptor
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

