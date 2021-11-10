using System;
using System.Diagnostics;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Threaded World!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DoStuffThread ds = new DoStuffThread();           
            Thread t1 = new Thread(()=>ds.calculating(10,'1'));
            t1.Start();
           
            Thread t2 = new Thread(() => ds.calculating(10, '2'));
            t2.Start();

            Thread t3 = new Thread(() => ds.calculating(10, '3'));
            t3.Start();

            Thread t4 = new Thread(() => ds.calculating(10, '4'));
            t4.Start();

            Thread t5 = new Thread(() => ds.calculating(10, '5'));
            t5.Start();           

            t3.Join();
            t1.Join();
            t2.Join();
            t4.Join();
            t5.Join();
           
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}
