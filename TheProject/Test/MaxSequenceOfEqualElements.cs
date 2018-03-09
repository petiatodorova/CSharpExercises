using System;
using System.Linq;
using System.Text;

namespace Test
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] countArr = new int[arr.Length - 1];//последния е винаги с дължина 1
            int currIndex;
            int currCount;

            //пълним масива countArr
            for (int i = 0; i < arr.Length - 1; i++)
            {
                currIndex = i;
                currCount = 1;
                while (true)
                {
                    if (currIndex > arr.Length - 2)
                    {
                        break;
                    }
                    if (arr[currIndex] != arr[currIndex + 1])
                    {
                        break;
                    }
                    else
                    {
                        currCount++;
                        currIndex++;
                    }
                }
                countArr[i] = currCount;
            }

            int maxLength = countArr.Max();
            int theIndex = Array.IndexOf(countArr, maxLength);

            Console.WriteLine($"maxLength is: {maxLength}. The index is: {theIndex}");
            StringBuilder result = new StringBuilder();
            for (int m = 0; m < maxLength; m++)
            {
                result.Append(arr[theIndex]);
                result.Append(' ');
            }
            Console.WriteLine($"{result}");
        }
    }
}
