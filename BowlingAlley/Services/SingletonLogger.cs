using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Services
{
    public sealed class SingletonLogger
    {
        // Static variable that holds the single instance of the class.
        private static readonly SingletonLogger _instance = new();

        private SingletonLogger() { }

        // Gives access to the single instance of the class.
        public static SingletonLogger Instance => _instance;


        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[LOG]: {message}");
            Console.ResetColor();
        }
    }
}
