## Four Fundamental OS Concepts

### Process
> recap from last week
- **Process** : คือนามธรรมของ OS สำหรับการ executing โปรแกรมด้วย limited priviledge
- **Dual-mode Operation**
  - User : execute with fewer priviledge
  - Kernal  execute with complete priviledge
- **Safe control transfer**
  - วิธีในการที่จะเปลี่ยนจาก mode นึงไปยังอีก mode นึงอย่างปลอดภัย

### Mode Switch
- User -> Kernal
  - **Interrupts** : ถูก trigger ด้วย timer และ I/O devices
    - โดยจะมีการส่ง Interrupt พร้อมกับหมายเลข โดย kernel จะมี function สำหรับการตอบกลับในแต่ละเลขของ Interrupt อยู่
    โดยใน kernel จะมีการเก็บ array of pointer ที่เรียกว่า INT Vector สำหรับเก็บ addrs. ของ response function กลับไปยัง user mode
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
  - Polling: kernel รอ I/O เสร็จก่อน
  - **Interrupts**: kernel สามารถทำงานอื่นได้ในเวลาเดียวกัน
- Device access to memory
  - I/O: CPU reads and writes to device
  - Direct memory access (DMA) by device
  - Buffer desciprtor: sequence of DMA's
    - e.g. packet header and packet body
  - Queue of buffer desciprtor

### How does Interrupt works?
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

### The Kernel Stack
- Interrupt handlers want a stack
- System call handlers want a stack
- Can't just use the user stack?
  - เพราะว่าความปลอดภัยและความเสถียรของระบบ
- Solution: **two-stack model**
  - each OS thread has kernel stack plus user stack
  - place to save user registers during interrupt

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

### Interrupt Masking
- OS kernel สามารถเปิด ปิด Interrupt ได้
  - on x86:
    - CLI: disable interrupts
    - STI: enable interrupts

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
**user mode**
  - code[syscall] -> microProc[fn(x,y)]
  - command SYSENT
**kernel mode**
  - store PC, SP, ... in kernel stack
  - fn(x,y) -> check params
  - valid store in stack + call the wanted func

### Today: Four Fundamental OS Concepts
- **Thread** (virtual microprocessor): PC, register, Execution Flags, Stack
- **Adress Space**: POV of program's view of memory is distinc from physical machine
- **Process** (an instance of a running program): Address Space + One or more Threads
- **Dual mode operation / protection**
  - only the "system" can access certain resources
  - combined with translation, isolates programs from each other
