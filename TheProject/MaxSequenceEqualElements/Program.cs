using System;
using System.Linq;
using System.Text;

namespace MaxSequenceEqualElements
{
    class MaxSequenceEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            /*
                Array in which we'll keep the max count
                of equal elements starting from the current index to right.
                The length is arr.Length - 1, because in the last index
                we have always 1.
            */
            
            int[] countArr = new int[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int currIndex = i;
                int currCount = 1;
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
            //string result = "";
            //for (int m = 0; m < maxLength; m++)
            //{
            //    result += arr[theIndex] + " ";

            //}
            Console.WriteLine($"{result}");
        }
    }
}
