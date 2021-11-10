using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    public class DoStuffThread
    {
        private void simulateCPUOperation()
        {
            for(int i = 0; i < 1000000; i++)
            {
                Math.Sqrt(Math.Cos(i)+Math.Sin(i));
            }
        }
        private void simulateIOOperation()
        {
            Thread.Sleep(500);
        }
        public void calculating(int n,char token)
        {
            for(int i=0;i<n;i++)
            {
                simulateCPUOperation();
                simulateIOOperation();
                Console.Write(token);
            }
        }
    }
}
