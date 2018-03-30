using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryNumbers
{
    class BinaryNumbers
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<int> binaryDigits = new List<int>();

            if (n >= 1 && n <= 1000000)
            {
                while (n > 0)
                {
                    int remainder = n % 2;
                    binaryDigits.Insert(0, remainder);
                    n = n / 2;
                }

                int maxCount = 0;
                int currentCount = 0;
                int length = binaryDigits.Count;

                for (int i = 0; i < length; i++)
                {
                    if (binaryDigits[i] == 1)
                    {
                        currentCount++;
                        if ((i == length - 1) && (currentCount > maxCount))
                        {
                            maxCount = currentCount;
                        }
                    }
                    else if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        currentCount = 0;
                    }
                    else
                    {
                        currentCount = 0;
                    }
                }

                Console.WriteLine($"{maxCount}");
            }
        }
    }
}
