## The Kernel Abstraction
- ***THE PAST*** -> **Single Task System**:
  - no library -> has to write everything by yourself
  - เขียนโปรแกรมเพื่อควบคุม HW อย่างเดียวเลย ยกตัวอย่างเช่น ถ้าเขียนภาษาซีแล้วไม่มี .h มาให้
  - few years later...
  - [Prog. -CALL-> Library -> HW.] (Program can still control HW directly) ทำให้เกิดความง่ายต่อ dev ในการเขียนโปรแกรม
  - few more years later... ~1969
  - add Queue Manager(Batch system) between HW and Programs : เพ่ิมการโหลดล่วงหน้าไว้ให้โปรแกรมถัดๆไป
- ***THE PRESENT*** -> **Multitasking System**
  - ~1970s
  - มีหลายโปรแกรม (P1, P2, P3, ...)สามารถทำงานพร้อมกันได้บน something

### Activity #1
- **Changing**
  - Queue -> จะมีการเปลี่ยนแปลงเป็นตัวที่ดูแลจัดการด้านการแบ่งทรัพยากรและแบ่งเวลาในการใช้งานให้แต่ละ task (time sharing, resource sharing) โดยรวมๆแล้วก็คือทำหน้าที่ task management
  - Library -> เปลี่ยนเป็น Kernel ซึ่งจะทำหน้าที่ดูแลจัดการ system call ทำหน้าที่ดูแลจัดการไฟล์, CPU Scheduling, Memory management
  - Additional components :
    1. Task Management
    2. Memory Management
    3. Interrupt and Event handling
    4. Synchroniztion and Communication
    5. Timer Management
    6. Device I/O Management

- **Answer** : **Protection**
  - ***Protection of the resource for each program (ENFORCE)***
  - แต่ละโปรแกรมก็จะทำงานได้เฉพาะ resource ที่ได้รับมอบหมายเท่านั้น
  - Queue -> resource manager, queue manager
  - Library -> system library
  - **Protection of HW** -> Partition
  - Additional -> fully control of hardware (ไม่มีส่วนไหนของ SW ที่ติดกันกับ HW เลย)

### UNIx Structure

### User/Kernel (Priviledge) Mode
- the reason why the window95 is so fucking bad because it allow the user to directly use the hardware

### GOALS of OS
- **Protecting** ***Process*** and ***Kernel***
  - Running multiple programs
    - keep them from interfering with the OS - kernel
    - keep them from interfering with each other - process
    - ถ้าเกิดการฝ่าฝืนกฏเกณฑ์ Kernel จะพยายามทำการ kill process นั้นทิ้ง ถ้าเกิดไม่สามารถ kill ได้จะเกิด the famous **"BLUE SCREEN"**

### Activity #2 Protection:
- **WHY?**
  - Reliability: bugg programs only hurt themselves
  - Security and Privacy: trust programs less
  - Fairness: enforce shares of disk, CPU
- **HOW?**
  - HW
    - Memory address translation
    - Dual mode operation
      - Priviledge/non-priviledge mode
      - System calls
  - SW
    - Process
    - System calls

### Hardware Support Dual-Mode Operation
- **Kernel mode**
  - full priviledge of the hardware
  - R/W any memory, access any I/O devices, R/W any disk sector, Send/Read any packet
- **User mode**
  - Limited priviledge
  - need permission
- **Priviledge Instruction**
  - only available to kernel
  - not available to user code
  - if user program attempts to execute a priviledge instruction -> exception happens, blue screen in a worst case
- **System Calls** (Trap) : คล้ายๆ interrupt แต่ถูก invoke โดย software
  - trap = ตรวจสอบข้อมูลทุกอย่างก่อนที่จะส่งไปยัง system library เพื่อไม่ให้เกิด error
   - Transfer from **User mode to Priviledge mode**
- **Limits on memory accesses**
  - preven user code from overwriting the kernel
- **Timer**
  - regain control from a user program in a loop

### Virtual Machine (VM)
- Software emulation of an abstract machine
  - give programs illusion they own the machine
  - Make it look like HW has feature you want
- 2 types of VM
  1. **Process VM** : supports the execution of a single program
  2. System VM : supports the execution of an entire OS
- GOALs:
  - Provide an isolation to a program
    - processes unable to directly impact other processes : boundary to the usage of a memory
    - fault isolation : bugs cannot crash the computer
  - Portability (Program)

### Process Abstraction
- Process : an instance of a program, running with limited rights
- Thread : a sequence of instructions within a process
  - เปรียบได้กับ microprocessor เสมือน
- Address space : RAM
  -

### Process
- **Process Control Block (PCB)** in kernel which store
  1. Status
  2. Registers
  3. Process ID (PID), user, executable, priority
  4. Execution time
  5. Memory space, translation table
- Kernel Scheduler maintains data structure containing the PCBs
- Scheduling algorithm selects the next one to run
- Others in user
