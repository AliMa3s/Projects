using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sync
{
    public class DoStuffSync
    {
        private void simulateCPUOperation()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Math.Sqrt(Math.Cos(i) + Math.Sin(i));
            }
        }
        private void simulateIOOperation()
        {
            Thread.Sleep(500);
        }
        public void process(int n, char token,bool IO,bool CPU)
        {
            for (int i = 0; i < n; i++)
            {
                if (CPU) simulateCPUOperation();
                if (IO) simulateIOOperation();
                Console.Write(token);
            }
        }
    }
}
