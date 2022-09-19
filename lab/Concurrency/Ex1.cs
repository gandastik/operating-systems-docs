namespace Concurrency{
  class Ex1 {
    static void TestThread1(){
      int i;
      for(i=0;i<100000;i++){
        Console.WriteLine("Thread #1 i={0}", i);
      }
    }

    static void TestThread2(){
      int i;
      for(i=0;i<100000;i++){
        Console.WriteLine("Thread #2 i={0}", i);
      }
    }

    public static void Solution() {
      Thread th1 = new Thread(TestThread1);
      Thread th2 = new Thread(TestThread2);
      th1.Start();
      th2.Start();
    }

  }
}
