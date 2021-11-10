using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello Async World!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DoStuffAsync ds = new DoStuffAsync();
            //await ds.process(10, '1',true,false);
            //await ds.process(10, '2', true, false);
            //await ds.process(10, '3', true, false);
            //await ds.process(10, '4', true, false);
            //await ds.process(10, '5', true, false);
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => ds.process(10, '1', false, true)));
            tasks.Add(Task.Run(() => ds.process(10, '2', false, true)));
            tasks.Add(Task.Run(() => ds.process(10, '3', false, true)));
            tasks.Add(Task.Run(() => ds.process(10, '4', false, true)));
            tasks.Add(Task.Run(() => ds.process(10, '5', false, true)));
            Task.WaitAll(tasks.ToArray());

            //tasks.Add(ds.process(10, '1', false, true));
            //tasks.Add(ds.process(10, '2', false, true));
            //tasks.Add(ds.process(10, '3', false, true));
            //tasks.Add(ds.process(10, '4', false, true));
            //tasks.Add(ds.process(10, '5', false, true));
            //Task.WaitAll(tasks.ToArray());

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}
