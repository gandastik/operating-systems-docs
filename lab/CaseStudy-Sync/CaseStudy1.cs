/*
VERSION: 1
MADE BY:
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
    class Thread_safe_1
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;

        private static Semaphore s = new Semaphore(1, 1);

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
            Front %= 10;
            Count -= 1;
            return x;
        }

        static void th01()
        {
            for(int i=1;i<51;i++){
                s.WaitOne();
                EnQueue(i);
                Thread.Sleep(5);
                s.Release();
            }
        }

        static void th011()
        {
            int i;

            for (i = 100; i < 151; i++)
            {
                EnQueue(i);
                Thread.Sleep(5);
            }
        }


        static void th02(object t)
        {
            int i,j;

            for(i=0;i<50;i++){ // change this to 50, 'cause why not
                s.WaitOne();
                j = DeQueue();
                if(j != 0) {
                    Thread.Sleep(100);
                    Console.WriteLine("j={0}, thread:{1}", j, t);
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
            basically just switch between 2 thread accomplish by using Semaphore (implementing Synchronization)
            t1(enqueue) -> t2(dequeue) -> t1 -> t2 -> ...
            */
            t1.Start();
            // t11.Start();
            t2.Start(1);
            // t21.Start(2);
            // t22.Start(3);
        }
    }
}