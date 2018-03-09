using System;

namespace TheWnNumber
{
    class TheWinNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guess the number:");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int n);
                if (n == 5)
                {
                    Console.WriteLine($"Win! Your code number is {n + 5}!");
                    break;
                }
                else
                {
                    Console.WriteLine($"I need the number. Try again:");
                }
            }

            Console.WriteLine($"The program has finished.");

        }
    }
}
