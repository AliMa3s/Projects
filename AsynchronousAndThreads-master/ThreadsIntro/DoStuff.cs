using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadsIntro
{
    public class DoStuff
    {
        public void print(char token, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(token);
            }
        }
        public void printN(object n)
        {
            for (int i = 0; i < (int)n; i++)
            {
                Console.Write('-');
            }
        }
        public void printX()
        {
            for(int i=0;i<1000;i++)
            {
                Console.Write('x');
            }
        }
    }
}
