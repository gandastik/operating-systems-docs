## Synchronization Case Study 2

### Summary after presentation
- อาจารย์ต้องการให้ประยุกต์ใช้ Lock + Condition Variable (Monitor.Wait(), Monitor.Pulse(), ...)
- มันจะทำให้โปรแกรมมีความ Thread safe มากกว่า version 5 ของเรา
- ใน Csharp อาจจะมีการประยุกต์ใช้ Queue ได้เลยแต่อาจจะจำเป็นต้องใช้ Queue.Synchonize เพื่อให้
โปรแกรมมีความ Thread safe ได้
- `Queue TS = Queue.Synchronize(new Queue())` <- ทำให้ Queue เป็น Thread safe

- Shared resource => เกิดปัญหา race condition
- race condition -> แก้ได้ด้วย Lock (Synchronization)
- การใช้ Lock -> Starvation, Deadlock
