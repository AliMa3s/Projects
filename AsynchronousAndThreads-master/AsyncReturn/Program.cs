using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncReturn
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoStuff ds = new DoStuff();
            string msg = await ds.getMessage("Tom");
            Console.WriteLine(msg);

            List<Task<string>> tasks = new List<Task<string>>();
            tasks.Add(ds.getIOoutput("file1"));
            tasks.Add(ds.getIOoutput("file2"));
            tasks.Add(ds.getIOoutput("file3"));
            tasks.Add(ds.getIOoutput("file4"));
            tasks.Add(ds.getIOoutput("file5"));
            var res = await Task.WhenAll(tasks.ToArray());
            foreach (var x in res)
            {
                Console.WriteLine(x);
            }
        }
    }
}
