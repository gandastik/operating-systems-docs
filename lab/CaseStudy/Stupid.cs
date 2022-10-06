using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Stupid
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int G_index = 0;
        static long sum1 = 0;
        static long sum2 = 0;
        static long sum3 = 0;
        static long sum4 = 0;
        static long sum5 = 0;
        static long sum6 = 0;
        static long sum7 = 0;
        static long sum8 = 0;
        static long sum9 = 0;
        static long sum10 = 0;
        static long sum11 = 0;
        static long sum12 = 0;
        static long sum13 = 0;
        static long sum14 = 0;
        static long sum15 = 0;
        static long sum16 = 0;

        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Data_Global = (byte[]) bf.Deserialize(fs);
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Read Failed:" + se.Message);
                returnData = 1;
            }
            finally
            {
                fs.Close();
            }

            return returnData;
        }
        static void sum(int i, ref long sum)
        {
            if (Data_Global[i] % 2 == 0)
            {
                sum -= Data_Global[i];
            }
            else if (Data_Global[i] % 3 == 0)
            {
                sum += (Data_Global[i]*2);
            }
            else if (Data_Global[i] % 5 == 0)
            {
                sum += (Data_Global[i] / 2);
            }
            else if (Data_Global[i] %7 == 0)
            {
                sum += (Data_Global[i] / 3);
            }
            Data_Global[i] = 0;
            // G_index++;
        }

        static void TestThread1()
        {
            int i;
            for (i=0; i<62500000; i++){
                sum(i, ref sum1);
            }
        }

        static void TestThread2()
        {
            int i;
            for (i=62500000; i<125000000; i++){
                sum(i, ref sum2);
            }
        }

        static void TestThread3()
        {
            int i;
            for (i=125000000; i<187500000; i++){
                sum(i, ref sum3);
            }
        }

        static void TestThread4()
        {
            int i;
            for (i=187500000; i<250000000; i++){
                sum(i, ref sum4);
            }
        }

        static void TestThread5()
        {
            int i;
            for (i=250000000; i<312500000; i++){
                sum(i, ref sum5);
            }
        }

        static void TestThread6()
        {
            int i;
            for (i=312500000; i<375000000; i++){
                sum(i, ref sum6);
            }
        }

        static void TestThread7()
        {
            int i;
            for (i=375000000; i<437500000; i++){
                sum(i, ref sum7);
            }
        }

        static void TestThread8()
        {
            int i;
            for (i=437500000; i<500000000; i++){
                sum(i, ref sum8);
            }
        }

        static void TestThread9()
        {
            int i;
            for (i=500000000; i<562500000; i++){
                sum(i, ref sum9);
            }
        }

        static void TestThread10()
        {
            int i;
            for (i=562500000; i<625000000; i++){
                sum(i, ref sum10);
            }
        }

        static void TestThread11()
        {
            int i;
            for (i=625000000; i<687500000; i++){
                sum(i, ref sum11);
            }
        }

        static void TestThread12()
        {
            int i;
            for (i=687500000; i<750000000; i++){
                sum(i, ref sum12);
            }
        }

        static void TestThread13()
        {
            int i;
            for (i=750000000; i<812500000; i++){
                sum(i, ref sum13);
            }
        }

        static void TestThread14()
        {
            int i;
            for (i=812500000; i<875000000; i++){
                sum(i, ref sum14);
            }
        }

        static void TestThread15()
        {
            int i;
            for (i=875000000; i<937500000; i++){
                sum(i, ref sum15);
            }
        }

        static void TestThread16()
        {
            int i;
            for (i=937500000; i<1000000000; i++){
                sum(i, ref sum16);
            }
        }

        public static void Solution()
        {
            Stopwatch sw = new Stopwatch();
            int i, y;

            /* Read data from file */
            Console.Write("Data read...");
            y = ReadData();
            if (y == 0)
            {
                Console.WriteLine("Complete.");
            }
            else
            {
                Console.WriteLine("Read Failed!");
            }

            /* Start */
            Console.Write("\n\nWorking...");

            // Build thread
            Thread th1 = new Thread(TestThread1);
            Thread th2 = new Thread(TestThread2);
            Thread th3 = new Thread(TestThread3);
            Thread th4 = new Thread(TestThread4);
            Thread th5 = new Thread(TestThread5);
            Thread th6 = new Thread(TestThread6);
            Thread th7 = new Thread(TestThread7);
            Thread th8 = new Thread(TestThread8);
            Thread th9 = new Thread(TestThread9);
            Thread th10 = new Thread(TestThread10);
            Thread th11 = new Thread(TestThread11);
            Thread th12 = new Thread(TestThread12);
            Thread th13 = new Thread(TestThread13);
            Thread th14 = new Thread(TestThread14);
            Thread th15 = new Thread(TestThread15);
            Thread th16 = new Thread(TestThread16);

            // start watch
            sw.Start();

            // Working
            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
            th6.Start();
            th7.Start();
            th8.Start();
            th9.Start();
            th10.Start();
            th11.Start();
            th12.Start();
            th13.Start();
            th14.Start();
            th15.Start();
            th16.Start();
            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();
            th5.Join();
            th6.Join();
            th7.Join();
            th8.Join();
            th9.Join();
            th10.Join();
            th11.Join();
            th12.Join();
            th13.Join();
            th14.Join();
            th15.Join();
            th16.Join();

            // stop watch
            sw.Stop();

            // Sum
            Sum_Global =
            sum1+
            sum2+
            sum3+
            sum4+
            sum5+
            sum6+
            sum7+
            sum8+
            sum9+
            sum10+
            sum11+
            sum12+
            sum13+
            sum14+
            sum16;
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
