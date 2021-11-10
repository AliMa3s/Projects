using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    public class DoStuffAsync
    {
        private async Task simulateCPUOperation()
        {           
            for (int i = 0; i < 1000000; i++)
            {
                Math.Sqrt(Math.Cos(i) + Math.Sin(i));
            }
        }
        private async Task simulateIOOperation()
        {
            await Task.Delay(500);
        }
        public async Task process(int n, char token, bool IO, bool CPU)
        {
            for (int i = 0; i < n; i++)
            {
                if (CPU) await simulateCPUOperation();
                if (IO) await simulateIOOperation();
                Console.Write(token);
            }
        }
    }
    //public class DoStuffAsync
    //{
    //    private async Task simulateCPUOperation(char token)
    //    {
    //        Console.Write($"(cpu{token}-start)");
    //        for (int i = 0; i < 1000000; i++)
    //        {
    //            Math.Sqrt(Math.Cos(i) + Math.Sin(i));
    //        }
    //        Console.Write($"(cpu{token}-stop)");
    //    }
    //    private async Task simulateIOOperation(char token)
    //    {
    //        Console.Write($"(io{token}-start)");
    //        await Task.Delay(500);
    //        Console.Write($"(io{token}-stop)");
    //    }
    //    public async Task process(int n, char token, bool IO, bool CPU)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            if (CPU) await simulateCPUOperation(token);
    //            if (IO) await simulateIOOperation(token);
    //            Console.Write(token);
    //        }
    //    }
    //}
}
