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
		-

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
- process Isolation
- efficient Interprocess communication
- shared code segments
- program initialization
- dynamic memory allocation
- cache management
- program debugging
- zero-copy I/O
- memory mapped files
- demand-paged virutal memory
