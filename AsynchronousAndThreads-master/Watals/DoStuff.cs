using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Watals
{
    public class DoStuff
    {
        public async Task working(string msg,int n)
        {
            Console.WriteLine("start working");
            for(int i=0;i<n;i++)
            {
                await Task.Delay(100);
                Console.WriteLine($"working {msg},{i}");
            }
        }
    }
}
