using System;

namespace FtpWorkerLib.Extensions
{

    public static class ConsoleExtensions
    {

        public static void Message(this string text, ConsoleColor consoleColor = ConsoleColor.Magenta){
            Console.ForegroundColor = consoleColor;
            System.Console.WriteLine(text);
            Console.ResetColor();
        }


        public static void Warn(this string text ){
            text.Message(ConsoleColor.Red);
        }
         


    }
}