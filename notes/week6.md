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
