/*
VERSION: 2
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
    class Thread_safe_2
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;

        private static Semaphore s = new Semaphore(1, 1);

        private static int exitflag = 0;

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
            for(int j=0;j<5;j++) {
                s.WaitOne();
                for (int i = (10*j)+1; i < ((j+1)*10)+1; i++)
                {
                    EnQueue(i);
                    Thread.Sleep(5);
                }
                s.Release();
            }
            exitflag = 1;
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

            while(exitflag == 0) {
                s.WaitOne();
                for(i=0;i<5;i++){ // knowing that theres 2 thread that is doing dequeing so need to divide the work in to two pieces
                    j = DeQueue();
                    if(j != 0) {
                        Thread.Sleep(100);
                        Console.WriteLine("j={0}, thread:{1}", j, t);
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

            t1.Start();
            // t11.Start();
            t2.Start(1);
            t21.Start(2);
            // t22.Start(3);
        }
    }
}