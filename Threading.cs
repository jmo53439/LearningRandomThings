using System;
using System.Threading;

namespace ThreadsRecursionCall
{
    class Program
    {
        static int deep;
        
        static public void Recursion()
        {
            // Threads.CurrentThread.Name
            Console.WriteLine("{0} say \"Hello!\"", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Thread thread = new Thread(Recursion);
            deep++;
            thread.Name = "Thread " + deep;
            thread.Start();
        }
        
        static void Main()
        {
            Thread thread = new Thread(Recursion) { Name = "Thread " + deep };
            thread.Start();
        }
    }
}
