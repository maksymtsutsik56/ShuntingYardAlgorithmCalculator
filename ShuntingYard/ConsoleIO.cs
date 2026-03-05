using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYard
{
    static class ConsoleIO
    {
        static string ReadStringInput()
        {
            Console.Write("Your input: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("invalid user console input");

            return input;
        }

        static void PrintStringMessage(string message)
        {
            Console.WriteLine(message); 
        }
    }
}
