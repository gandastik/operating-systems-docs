using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Pleum
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int G_index = 0;
        static int thread_num = 64;


        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Data_Global = (byte[])bf.Deserialize(fs);
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
        static void sum_all(int i, ref long sum)
        {
            if (Data_Global[i] % 2 == 0)
            {
                sum -= Data_Global[i];
            }
            else if (Data_Global[i] % 3 == 0)
            {
                sum += (Data_Global[i] * 2);
            }
            else if (Data_Global[i] % 5 == 0)
            {
                sum += (Data_Global[i] / 2);
            }
            else if (Data_Global[i] % 7 == 0)
            {
                sum += (Data_Global[i] / 3);
            }
            Data_Global[i] = 0;
            // G_index++;
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
            static void TestThread(int no, ref long sum)
            {
                int i;
                for (i = no * (1000000000 / thread_num); i < (1000000000 / thread_num) * (no + 1); i++)
                {
                    sum_all(i, ref sum);
                }
            }
            /* Start */
            Thread[] threads = new Thread[thread_num];

            Console.Write("\n\nWorking...");
            long[] sum = new long[thread_num];
            for (int z = 0; z < thread_num; ++z)
            {
                int k = z;
                sum[k] = 0;
                threads[k] = new Thread(() => TestThread(k, ref sum[k]));
            }
            sw.Start();
            for (i = 0; i < thread_num; i++)
            {
                threads[i].Start();
            }
            for (i = 0; i < thread_num; i++)
            {
                threads[i].Join();
                Sum_Global += sum[i];
            }

            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
