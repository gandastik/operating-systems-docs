using System;
using System.Threading;

/*
MADE BY:
63010035 กฤษฎาง แสวงศิริผล
63010082 กิตติภณ สิงห์ชม
63010183 ชนน กุลกัตติมาส
63010229 ชินกฤต ปิ่นคล้าย
63010283 ณภัทร มูลพินิจ
63011013 สุเมธ สวนสำราญ
*/

namespace Program {
    class Ex_05_Solution {
        private static string x = "";
        private static int exitflag = 0;
        private static int updateFlag = 0;
        private static Semaphore s = new Semaphore(1,1);

        static void ThReadX(object i){
            while (exitflag == 0) {
                s.WaitOne();
                if (x != "exit" && x != "") {
                    Console.WriteLine("***Thread {0} : x = {1}***", i, x);
                    x = "";
                }
                s.Release();
            }
            Console.WriteLine("---Thread {0} exit---", i);
        }

        static void ThWriteX(){
            string xx;
            while(exitflag == 0){
                s.WaitOne();
                Console.Write("Input: ");
                xx = Console.ReadLine();
                if (xx == "exit") {
                    exitflag = 1;
                }
                x = xx;
                s.Release();
            }
        }

        public static void Solution() {
            Thread A = new Thread(ThWriteX);
            Thread B = new Thread(ThReadX);
            Thread C = new Thread(ThReadX);
            Thread D = new Thread(ThReadX);
            
            A.Start();
            B.Start(1);
            C.Start(2);
            D.Start(3);
        }
    }
}