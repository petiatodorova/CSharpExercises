using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CameraViewSol2
{
    class CameraViewSol2
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int toSkip = numbers[0];
            int toTake = numbers[1];

            string input = Console.ReadLine();

            string pattern = @"(\|<)([\w]{0," + toSkip + @"})([\w]{0," + toTake + @"})";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                MatchCollection myMatches = regex.Matches(input);
                List<string> result = new List<string>();

                foreach (Match match in myMatches)
                {
                    string curResult = match.Groups[3].ToString();
                    result.Add(curResult);
                }
                Console.WriteLine($"{string.Join(", ", result)}");
            }
        }
    }
}
