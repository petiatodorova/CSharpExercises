using System;
using System.Linq;
using System.Collections.Generic;

namespace Multidimensional
{
    class Multidimensional
    {
        static void Main(string[] args)
        {
            int[ , ] arr = new int[6, 6];
            int maxSum = Int32.MinValue;

            for (int row = 0; row < 6; row++)
            {
                int[] temp = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

                for (int col = 0; col < 6; col++)
                {
                    arr[row, col] = temp[col];
                }
            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int currentSum = SumHourGlass(arr, row, col);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }

            }

            Console.WriteLine($"{maxSum}");
        }

        static int SumHourGlass(int[ , ] arr, int x, int y)
        {
            int currentSum = 0;

            for (int j = y; j <= y + 2; j++)
            {
                currentSum += arr[x, j] + arr[x + 2, j];
            }

            currentSum += arr[(x + 1), (y + 1)];

            return currentSum;
        }
    }
}
