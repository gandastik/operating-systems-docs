using System;
using System.Diagnostics;
using System.Threading;

namespace Program {
    class Ex_00_Solution {
        private static int sum = 0;

        static void plus() {
            int i;
            for(i = 1; i < 1000001; i++ ){ 
                sum += i;
            }
        }

        static void minus () {
            int i;
            for (i = 0; i < 1000000; i ++ ){
                sum -= i;
            }
        }
    
        public static void Solution() {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start....");
            sw.Start();
            plus();
            minus();
            sw.Stop();
            Console.WriteLine("sum = {0}", sum);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + " ms");
        }
    }

}