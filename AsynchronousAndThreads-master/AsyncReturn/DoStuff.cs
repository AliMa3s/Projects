using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReturn
{
    public class DoStuff
    {
        public async Task<string> getMessage(string who)
        {
            return $"async message from {who}";
        }
        public async Task<string> getIOoutput(string fakeFileName)
        {
            Console.WriteLine($"start {fakeFileName}");
            await Task.Delay(10);
            for(int i=0;i<100000;i++) 
                { Math.Cos(i); } //fake some action
            Console.WriteLine($"stop {fakeFileName}");
            return $"results from {fakeFileName}";
        }
    }
}
