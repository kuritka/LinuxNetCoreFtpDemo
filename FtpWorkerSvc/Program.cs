using System;
using FtpWorkerLib;

namespace FtpWorkerSvc
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
