using System;
using System.Text.RegularExpressions;

namespace StrongPassword
{
    class StrongPassword
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string patternDigit = @"[\d]";
            string patternSmallLetter = @"[a-z]";
            string patternCapitalLetters = @"[A-Z]";
            string patternSymbols = @"[\!\@\#\$\%\^\&\*()\-\+]";

            MatchCollection digitMatches = Regex.Matches(input, patternDigit);
            MatchCollection smallLettersMatches = Regex.Matches(input, patternSmallLetter);
            MatchCollection capitalLettersMatches = Regex.Matches(input, patternCapitalLetters);
            MatchCollection symbolsMatches = Regex.Matches(input, patternSymbols);

            int countDigits = digitMatches.Count;
            int countSmallLetters = smallLettersMatches.Count;
            int countCapitalLetters = capitalLettersMatches.Count;
            int countSymbols = symbolsMatches.Count;

            int countAll = countDigits + countSmallLetters + countCapitalLetters + countSymbols;
            int theMinNumber = 0;

            if (countDigits >= 1 && countCapitalLetters >= 1 && countSymbols >= 1 && countSmallLetters >= 1)
            {
                if (countAll < 6)
                {
                    theMinNumber = 6 - countAll;
                }
            }
            else
            {
                while (countDigits == 0 || countCapitalLetters == 0 || countSymbols == 0 || countSmallLetters == 0)
                {
                    if (countDigits == 0)
                    {
                        theMinNumber++;
                        countDigits++;
                    }
                    if (countCapitalLetters == 0)
                    {
                        theMinNumber++;
                        countCapitalLetters++;
                    }
                    if (countSmallLetters == 0)
                    {
                        theMinNumber++;
                        countSmallLetters++;
                    }
                    if (countSymbols == 0)
                    {
                        theMinNumber++;
                        countSymbols++;
                    }
                }

                if (countAll + theMinNumber < 6)
                {
                    theMinNumber += 6 - (countAll + theMinNumber);
                }
            }
            Console.WriteLine($"{theMinNumber}");
        }
    }
}
