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
    class Ex_04_Solution {
        private static string x = "";
        private static int exitflag = 0;
        private static Semaphore s = new Semaphore(1,1);

        static void ThReadX(){
            while(exitflag == 0){
                s.WaitOne();
                if(exitflag == 0 && x != "") {
                    Console.WriteLine("X = {0}", x);
                } else if (exitflag == 1) {
                    Console.WriteLine("Thread 1 exit");
                }
                s.Release();
            }
        }

        static void ThWriteX(){
            string xx;
            while(exitflag == 0) {
                s.WaitOne();
                Console.Write("Input: ");
                xx = Console.ReadLine();
                if (xx == "exit") {
                    exitflag = 1;
                } else {
                    x = xx;
                }
                s.Release();
            }
        }

        public static void Solution() {
            Thread A = new Thread(ThReadX);
            Thread B = new Thread(ThWriteX);
        
            B.Start();
            A.Start();
        }
    }
}