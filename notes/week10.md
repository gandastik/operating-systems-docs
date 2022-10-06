## Synchronization

### Recap
- การทำงานแยก Thread จะมีการเข้าถึง Shared Resource ไว้ให้แต่ละ Thread เข้าถึงได้
- ถ้าเกิดมี Thread นึงทำการ write ไปที่ Shared Resource แล้วมี Thread อื่นมา Read ในที่ๆเดียวกัน -> **Race Condition**
- Solution -> **Synchronization** ทำให้แต่ละ Thread รู้จังหวะสำหรับการอ่านและเขียนใน Shared Resource

### Synchronization Motivation
- When threads cocurrently read/write shared memory, program behaviour is undefined
  - Two threads write to the same varialbe; which one should win?
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

