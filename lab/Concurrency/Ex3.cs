namespace Concurrency{
  class Ex3 {
    static int resource = 10000;

    static void TestThread1() {
      //resource = 55555;
      for(int i=0;i<45555;i++){
        resource++;
        Console.Write(".");
      }
    }

    public static void Solution(){
      Thread th1 = new Thread(TestThread1);
      th1.Start();
      Thread.Sleep(100);
      Console.WriteLine("resources={0}", resource);
    }

    public static void Solution1() {
      Thread th1 = new Thread(TestThread1);
      th1.Start();
      Thread.Sleep(200);
      Console.WriteLine("Resource = {0}", resource);
    }

    public static void Solution2() {
      Thread th1 = new Thread(TestThread1);
      th1.Start();
      //Thread.Sleep(200);
      th1.Join();
      Console.WriteLine("Resource = {0}", resource);
    }
  }
}
