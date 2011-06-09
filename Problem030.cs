using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EulerProject
{
    [EulerProblem]
    public static class Problem030
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 30, Solution 1: Total = 443839 in 419409 ticks
        // Problem 30, Solution 2: Total = 443839 in 68359 ticks

        static Stopwatch _timer = new Stopwatch();

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
        public static void Solution1()
        {
            _timer.Restart();
            int maxValue = 6 * (int)Math.Pow(9,5);
            int result = Enumerable.Range(2, maxValue).Where(n => n == Pow5Digits(n)).Sum();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 30, Solution 1: Total = {0} in {1} ticks", result, _timer.ElapsedTicks));
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
        public static void Solution2()
        {
            _timer.Restart();
            int maxValue = 6 * (int)Math.Pow(9, 5);
            int result = 0;
            for (int i = 2; i < maxValue; i++)
            {
                if (Pow5Digits2(i) == i)
                {
                    result += i;
                }
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 30, Solution 2: Total = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
