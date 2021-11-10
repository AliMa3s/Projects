using System;
using System.Threading.Tasks;

namespace Watals
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoStuff ds = new DoStuff();
            await ds.working("hard", 5);
            await Task.Delay(450);
            Console.WriteLine("I'm done");
        }
    }
}
