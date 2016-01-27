using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem030
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 30, Solution 1: Total = 443839 in 419409 ticks
        // Problem 30, Solution 2: Total = 443839 in 68359 ticks

        static readonly int[] _pow5Digits = {
            0,
            1,
            (int)Math.Pow(2, 5),
            (int)Math.Pow(3, 5),
            (int)Math.Pow(4, 5),
            (int)Math.Pow(5, 5),
            (int)Math.Pow(6, 5),
            (int)Math.Pow(7, 5),
            (int)Math.Pow(8, 5),
            (int)Math.Pow(9, 5),
        };

        static int Pow5Digits(int value)
        {
            return value.ToString().Select(c => _pow5Digits[c - '0']).Sum();
        }

        // Brute force solution
        [EulerSolution]
		public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int maxValue = 6 * (int)Math.Pow(9,5);
            int result = Enumerable.Range(2, maxValue).Where(n => n == Pow5Digits(n)).Sum();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        static int Pow5Digits2(int value)
        {
            int result = 0;
            while (value != 0)
            {
                result += _pow5Digits[value % 10];
                value /= 10;
            }
            return result;
        }

        // Slightly improved brute force solution
        [EulerSolution]
		public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int maxValue = 6 * (int)Math.Pow(9, 5);
            int result = 0;
            for (int i = 2; i < maxValue; i++)
            {
                if (Pow5Digits2(i) == i)
                {
                    result += i;
                }
            }

            timer.Stop();
            return result;
        }
    }
}
