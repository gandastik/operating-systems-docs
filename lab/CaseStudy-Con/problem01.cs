using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Problem
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int G_index = 0;
        static int n = 8;
        static int interval = 1000000000/n;
        // static long[] sumthread = new long[n];

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
        static int sum(int i)
        {
          int ret = 0;
            if (Data_Global[i] % 2 == 0)
            {
                ret -= Data_Global[i];
            }
            else if (Data_Global[i] % 3 == 0)
            {
                ret += (Data_Global[i]*2);
            }
            else if (Data_Global[i] % 5 == 0)
            {
                ret += (Data_Global[i] / 2);
            }
            else if (Data_Global[i] %7 == 0)
            {
                ret += (Data_Global[i] / 3);
            }
            Data_Global[i] = 0;
            // G_index++
            return ret;
        }

        static long TestThread(int start, int end){
            int i;
            int ret = 0;
            for (i=start; i<end; i++) {

                ret += sum(i);
            }
            return ret;
        }

        static void Solution(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int y;

            long[] keepSumthread = new long[n];

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

            sw.Start();

            // fork threads
            Thread[] threadsArray = new Thread[n];
            for (int i=0; i<n; i++) {
                int start = i*interval;
                int end = start+interval;
                int k = i;
                threadsArray[i] = new Thread(()=> {keepSumthread[k] = TestThread(start, end);});
            }

            // start watch
            // sw.Start();

            // working (threads start)
            for (int i=0; i<n; i++) {
                threadsArray[i].Start();
            }
            for (int i=0; i<n; i++) {
                threadsArray[i].Join();
            }

            // Sum_Global
            for (int i=0; i<n; i++) {
                // Console.WriteLine(sumthread[i]);
                Sum_Global += keepSumthread[i];
            }

            // stop watch
            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
