using System;
using System.Threading;

namespace ThreadsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoStuff ds = new DoStuff();
            
            Thread t = new Thread(ds.printX);
            t.Start();

            Thread t2 = new Thread(() => ds.print('+', 500));
            t2.Start();
            
            //t.Join();
            t2.Join();
            Console.WriteLine("Done!");

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write('M');
            //}          

        }
    }
}
