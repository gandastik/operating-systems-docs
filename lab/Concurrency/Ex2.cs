namespace Concurrency{
  class Ex2 {
    static int resource = 10000;

    static void TestThread1(){
      Console.WriteLine("Thread#1 i={0}", resource);
    }

    static void TestThread2(){
      Console.WriteLine("Thread#2 i={0}", resource);
    }


    public static void Solution() {
      Thread th1 = new Thread(TestThread1);
      Thread th2 = new Thread(TestThread2);
      th1.Start();
      th2.Start();
    }
  }
}

