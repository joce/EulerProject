using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem017 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 18, Solution 1: Value = 21124 in 2716 ticks

        static readonly string[] _units =
		{
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
        };

        static readonly string[] _teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
        };

        static readonly string[] _tens =
        {
            "units", // unused
            "teens", // unused
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety",
        };

        static int GetOneToNineteen()
        {
            int result = GetOneToNine();
            for (int i = 0; i < 10; i++)
            {
                result += _teens[i].Length;
            }
            return result;
        }

        static int GetOneToNine()
        {
            int result = 0;
            for (int i = 1; i < 10; i++)
            {
                result += _units[i].Length;
            }
            return result;
        }

        // Isn't there a word in English for "dizaine"?
        static int GetTen(int ten)
        {
            // It's assumed "ten" will be >= 2 and <= 9
            int result;
            result = (_tens[ten].Length * 10);

            return result + GetOneToNine();
        }

        static int GetHundred(int hundred)
        {
            // It's assumed "ten" will be >= 0 and <= 9
            int result = hundred > 0 ? (100 * (_units[hundred].Length + "hundred".Length)) + (99 * "and".Length) : 0;
            result += GetOneToNineteen();
            for (int i = 2; i <= 9; i++)
            {
                result += GetTen(i);
            }
            return result;
        }

        // Rather crappy problem. Not looking for a better solution.
        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();

            int result = 0;
            for (int i = 0; i <= 9; i++)
            {
                result += GetHundred(i);
            }

            result += "one".Length + "thousand".Length;
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 17, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
