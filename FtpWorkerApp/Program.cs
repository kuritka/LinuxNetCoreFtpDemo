using System;
using FtpWorkerLib;


namespace FtpWorkerApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Running process....");
            new FtpWorker().Process();
        }
    }
}
