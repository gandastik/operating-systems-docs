/*
VERSION: 5
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
    class Thread_safe_5
    {
        static private int BUFFER_SIZE = 10;
        static int[] TSBuffer = new int[BUFFER_SIZE];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;

        private static Object _Lock = new Object();
        private static int exitflag = 0;

        private static bool enqueueDone1 = false;
        private static bool enqueueDone2 = false;
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
            int i = 1;
            while(!enqueueDone1){ 
                lock (_Lock) { // implementing Lock
                    if(Count == 0){
                        EnQueue(i);
                        Thread.Sleep(5);
                        i++;
                    }
                }
                if(i == 51) enqueueDone1 = true;
            }
        }

        static void th011()
        {
            int i = 101;
            while(!enqueueDone2){
                lock (_Lock) {
                    if(Count == 0){
                        EnQueue(i);
                        Thread.Sleep(5);
                        i++;
                    }
                }
                if(i==151) enqueueDone2 = true;
            }
        }


        static void th02(object t)
        {
            int j;
            while(exitflag == 0) {
                lock (_Lock) {
                    if(Count > 0){  // if the buffer have element to dequeue
                        j = DeQueue();
                        Thread.Sleep(100);
                        Console.WriteLine("j={0},\tthread:{1}", j, t);
                        if (enqueueDone1 && enqueueDone2){  // when the task are done
                            exitflag = 1;
                        }
                    }
                }
            }
        }
        public static void Solution()
        {
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            /** DESC:
            * each thread are schedule to work randomly -> so we need to implement synchronization by using Lock
            * the enqueuing thread need to have limit (10 -> Buffer's size) of how much they can enqueue in a row
            * also the dequeuing thread can not dequeue more than limit (Count > 0)
            **/
            t1.Start();
            t11.Start();
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);
        }
    }
}
