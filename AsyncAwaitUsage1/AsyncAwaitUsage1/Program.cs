using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitUsage1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CONTROL");
            FirstTask().Wait();
            Console.ReadLine();
        }

        public async static Task FirstTask()
        {
            Console.WriteLine("Method 1 -----> Starts ");

            Console.WriteLine("Method 1 -----> Calling Async Method2");
            string x =await SecondTask();
            Console.WriteLine(x);

        }
        public async static Task<string> SecondTask()
        {
            return await Task.Run(() =>
             {
                 Console.WriteLine(Thread.CurrentThread.Name);
                 Console.WriteLine("Method 2 -----> Starting Method 2");
                 Console.WriteLine("Method 2 -----> delay started ");
                 Thread.Sleep(5000);
                 Console.WriteLine("Method 2 -----> Delay Ends");
                 Console.WriteLine("Method 2 ----->  returning from method 2");
                 return ("Hi,Rishav!!");
             });
        }
    }
}
