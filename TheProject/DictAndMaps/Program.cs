using System;
using System.Collections.Generic;
using System.Linq;

namespace DictAndMaps
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string phone = input[1];

                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook.Add(name, phone);
                }
            }

            string whileInput = Console.ReadLine();

            while (true)
            {
                if (whileInput == "")
                {
                    break;
                }
                if (!phoneBook.ContainsKey(whileInput))
                {
                    Console.WriteLine($"Not found");
                }
                else
                {
                    Console.WriteLine($"{whileInput}={phoneBook[whileInput]}");
                }

                whileInput = Console.ReadLine();
            }
        }
    }
}
