using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexExample
{
    class CameraViewSol1
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

            string pattern = @"(\|<)(\w+)";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                MatchCollection myMatches = regex.Matches(input);
                List<string> result = new List<string>();

                foreach (Match match in myMatches)
                {
                    string currentMatch = match.Groups[2].ToString();
                    string curResult = currentMatch.Substring(toSkip, Math.Min(toTake, currentMatch.Length - toSkip));
                    result.Add(curResult);
                }
                Console.WriteLine($"{string.Join(", ", result)}");
            }
        }
    }
}
