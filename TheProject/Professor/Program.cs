using System;
using System.Linq;
using System.Collections.Generic;

namespace Professor
{
    class Program
    {
        static void Main(string[] args)
        {

            int tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                int[] students = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                int allStudents = students[0];
                int minStudents = students[1];

                if (minStudents <= allStudents)
                {
                    int[] studentsTime = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                    int allInTimeStudents = studentsTime
                        .Where(a => a <= 0)
                        .ToArray()
                        .Length;

                    if (allInTimeStudents >= minStudents)
                    {
                        Console.WriteLine($"NO");
                    }
                    else
                    {
                        Console.WriteLine($"YES");
                    }
                }
            }
        }
    }
}
