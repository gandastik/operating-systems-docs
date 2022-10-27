### Deadlocks
- มีปัจจัยในการก่อให้เกิดคือ
1. Limit access to resources (มีการใช้ Lock) *ไม่เสมอไป*
2. Independent request: ยกตัวอย่างเช่น 
	- มีสอง thread ที่ต้องการ acquire resource ตัวเดียวกัน แบบสลับขั้นตอนกัน
```Thread1
A.acquire()
<-- context switch here
B.acquire()
B.release()
A.release()
```
```Thread2
B.acquire() <-- this line runs
A.acquire() <-- deadlock happens here
A.release()
B.release()
```
	-  **wait while holding**: ในกรณีที่ thread นั้น wait แต่มีการถือ "กุญแจ" ติดไปด้วย
```Thread1
A.acquire()
t1.wait() ---> มันรอ แต่ thread2 ไม่สามารถทำงานได้เพราะว่า "กุญแจ" ยังอยู่ที่ thread1 อยู่
A.release()
```
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
- **Throughput**: how man tasks can be done per unti of time
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
	- ถ้า time quantum น้อยไป -> one instruction?? -> too much overhead (context switch) -> ถูกมองเป็น SJF **เป็นการแก้ปัญหา Starvation เนื่องจากมีการเข้าถึงงานทุกๆงานอย่างเท่าๆกัน**

![](https://media.discordapp.net/attachments/1014398974649708624/1035037844508524564/unknown.png?width=824&height=685)

- RR > FIFO : ไม่เสมอไป เพราะว่าในกรณีที่ task ใน workload มีขนาดเท่ากันหมด ใน RR ถ้าเกิดมีการแบ่งเวลาในมี time quantum น้อยๆ ก็จะส่งผลให้เกิด average response time ที่มากขึ้น
- **RR** = Fairness ? in some sense yes, เพราะว่า แต่ละ job จะได้เข้าถึง cpu อย่างเท่าเทียมกัน ก็มาจากที่หลังหมดเวลา time quantum ก็จะต้องไปต่อท้ายคิว

### Mixed Workload
![](https://media.discordapp.net/attachments/1014398974649708624/1035044981456523284/unknown.png?width=1255&height=685)
- เกิดปัญหาจาก job ที่มีการใช้ Lock หรือเสร็จก่อนหมดเวลา time quantum 

### Max-Min Fairness
- เป็น algorithm ที่ balance ระหว่าง repeating tasks:
- one approach: maximize the minimum allocation given to a task
	- if any taskn eed less than an equal share, schedule the smallest of these first
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

![](https://media.discordapp.net/attachments/1014398974649708624/1035048115708903527/unknown.png)

### Uniprocessor Summary
- FIFO is simple and minimizes overhead
- ถ้าแต่ละ task มีขนาดที่แตกต่างกันออกไป -> FIFO can have very poor average response time
- tasks are equal in size -> FIFO is optimal