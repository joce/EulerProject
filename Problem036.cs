using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem036
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 36, Solution 1: Total = 872187 in 356114 ticks
        // Problem 36, Solution 2: Total = 872187 in 301185 ticks
        // Problem 36, Solution 3: Total = 872187 in 1684 ticks

        static bool IsPalindrome(string value)
        {
            int halfLenght = value.Length / 2;
            for (int i = 0; i < halfLenght; i++)
            {
                if (value[i] != value[value.Length -1 -i])
                {
                    return false;
                }
            }
            return true;
        }


        [EulerSolution]
		public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int result = Enumerable.Range(1, 1000000).Where(i => IsPalindrome(i.ToString()) && IsPalindrome(Convert.ToString(i, 2))).Sum();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static int Solution2(Stopwatch timer)
        {
            int result = 0;

            timer.Restart();
            for (int i = 1; i < 1000000; i++)
            {
                if (IsPalindrome(i.ToString()) && IsPalindrome(Convert.ToString(i,2)))
                {
                    result += i;
                }
            }
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        // Solution suggested by Project Euler
        // (http://projecteuler.net/project/resources/036_1e63891bfed6acfe660ba685852b1616/036_overview.pdf)

        static bool IsPalindrome2(int n, int bse)
        {
            int reversed = 0;
            int k = n;
            while (k > 0)
            {
                reversed = (bse * reversed) + (k % bse);
                k /= bse;
            }
            return n == reversed;
        }

        static int MakePalindromeBase2(int n, bool oddLength)
        {
            int res = n;
            if (oddLength)
            {
                n >>= 1;
            }
            while (n > 0)
            {
                res = (res << 1) + (n & 1);
                n = n >> 1;
            }
            return res;
        }

        [EulerSolution]
		public static int Solution3(Stopwatch timer)
        {
			timer.Restart();
			const int limit = 1000000;
            int result = 0;
            int i = 1;
            int p = MakePalindromeBase2(i, true);
            while (p < limit)
            {
                if (IsPalindrome2(p,10))
                {
                    result += p;
                }
                i++;
                p = MakePalindromeBase2(i, true);
            }

            i = 1;
            p = MakePalindromeBase2(i, false);
            while (p < limit)
            {
                if (IsPalindrome2(p, 10))
                {
                    result += p;
                }
                i++;
                p = MakePalindromeBase2(i, false);
            }
            timer.Stop();
            return result;
        }
    }
}
