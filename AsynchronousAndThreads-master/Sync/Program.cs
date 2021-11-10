using System;
using System.Diagnostics;

namespace Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sync World!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DoStuffSync ds = new DoStuffSync();
            ds.process(10, '1',true,false);
            ds.process(10, '2',true,false);
            ds.process(10, '3', true, false);
            ds.process(10, '4', true, false);
            ds.process(10, '5', true, false);            
            
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}
