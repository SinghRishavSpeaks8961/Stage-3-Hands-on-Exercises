using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStartSample
{
    class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("-> {0} is executing Printnumbers()",Thread.CurrentThread.Name);

            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}, ",i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
