/*
VERSION: 3
Made by:
63010035 กฤษฎาง แสวงศิริผล
63010082 กิตติภณ สิงห์ชม
63010183 ชนน กุลกัตติมาส
63010229 ชินกฤต ปิ่นคล้าย
63010283 ณภัทร มูลพินิจ
63011013 สุเมธ สวนสำราญ
*/

using System;
using System.Threading;

namespace Program
{
    class Thread_safe_buffer
    {
        static private int BUFFER_SIZE = 10;
        static int[] TSBuffer = new int[BUFFER_SIZE];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;

        private static Semaphore s = new Semaphore(1, 1);

        private static int exitflag = 0;

        private static bool canEnqueue = true;
        static void EnQueue(int eq)
        {
            TSBuffer[Back] = eq;
            Back++;
            Back %= 10;
            Count += 1;
        }

        static int DeQueue()
        {
            int x = 0;
            x = TSBuffer[Front];
            Front++;
            if(Front>=BUFFER_SIZE){  // signal to enqueing thread that it can the dequeing thread are done
                canEnqueue = true; 
            }
            Front %= 10;
            Count -= 1;
            return x;
        }

        static void th01()
        {
            int j = 0;
            while(j < 5 && exitflag == 0){ // divide into 5 iteration (because the problem need to enqueue until 50)
                if(canEnqueue){
                    s.WaitOne();
                    for (int i = (10*j)+1; i < ((j+1)*10)+1; i++) // can only enqueue 10 at a times limitation by the buffer's size
                    {
                        EnQueue(i);
                        Thread.Sleep(5);
                    }
                    canEnqueue = false;
                    j+=1;
                    s.Release();
                }
            }
        }

        static void th011()
        {
            // can be done by creating another buffer -> conditional state in func th02
            int j = 0;
            while(j < 5 && exitflag == 2){
                if(canEnqueue){
                    s.WaitOne();
                    for (int i = (10*j)+100; i < ((j+1)*100)+1; i++)
                    {
                        EnQueue(i);
                        Thread.Sleep(5);
                    }
                    canEnqueue = false;
                    j+=1;
                    s.Release();
                }
            }
        }


        static void th02(object t)
        {
            int j;
            while(exitflag == 0 || exitflag == 2) {
                s.WaitOne(); // queueing the thread
                    if(!canEnqueue){ // the dequeuing thread need to dequeue 10 elements from the buffer
                        j = DeQueue();
                        if(j != 0) {
                            Thread.Sleep(100);
                            Console.WriteLine("j={0}, thread:{1}", j, t);
                        } 
                        if (j == 50){ // check if dequeued element met the requirement
                            exitflag = 1;
                        }
                    }
                s.Release();
            }
        }
        public static void Solution()
        {
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            /* DESC:
            using Semaphore to acheive concurrency by implementing Sychronization
            example thread workflow: 
            t1(enqueued 10 elements) -> t2(dequeued one element) -> t21 -> t22 -> t1(do nothing) -> t2..t22 (dequeue upto 10 elements) -> t1(enqueued another 10 elements) -> ..
            */
            t1.Start();
            // t11.Start();
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);
        }
    }
}
