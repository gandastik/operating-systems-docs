## Virtural Memory
- **micro-processor** -> **cache** -> **RAM** -> **virtual memory in storage**
- ใช้บางส่วนของ storage มาเก็บข้อมูล ที่ในขณะนั้นยังไม่ถูกประมวลผลใน RAM 
- ใช้ technique ***"Address Translation"*** -> Memory Mapped File (ใช้การ copy แบบ "Zero Copy")
- Memory Mapped File -> มีการแบ่งส่วนของข้อมูลเป็น block เรียกว่า "frame"  สามารถ copy frame แล้วย้ายไปยัง frame ของ RAM ได้เลย ไม่ต้องผ่าน Buffer
- ข้อจำกัดคือ Hardware ของ ความเร็วของ Storage
- **Cache** -> เป็นเก็บ copy ของข้อมูลที่ทำให้ เข้าถึงได้เร็วขึ้น จะมี **"Cache Policy"** เพื่อเป็นการจัดการ cache ว่าจะ drop หรือจะแก้ข้อมูล frame ไหนไว้ ถ้าหากเกิดว่าพื้นที่ที่จัดเก็บเต็ม

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
- write changes on page back to dis, if necessary

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

### MIN,LRU, LFU
- **MIN**: แทนที่ cache entry that will not be used for the longest time into the future
	- optimality proof based on exchange: if evict an entry used sooner, that will trigger an earlier cache miss
- **Least Recently Used (LRU)
	- replace the cache entry that has not been used for the longest time in the past
	- approximation of MIN
- **Least Frequently Used (LFU)
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