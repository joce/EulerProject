using System.Diagnostics;
using System.Linq;
using System.Security.Policy;

namespace EulerProject
{
    [EulerProblem]
    public class Problem145
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 608720 in 1070855273 ticks
        // Solution 2: Result = 608720 in 250003118 ticks

        // Brute force solution
        [EulerSolution(false, reason: "Takes too long")]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int cnt = 0;
            for (long i = 11; i < 1000000000; i+=2)
            {
                string s = i.ToString();
                if (s[s.Length - 1] == '0')
                {
                    continue;
                }

                if ((s[0]-'0' + s[s.Length-1]-'0') % 2 == 0)
                {
                    i-=3;
                    continue;
                }

                long rev = long.Parse(new string(s.Reverse().ToArray()));
                rev += i;
                string s1 = rev.ToString();
                bool found = true;
                foreach (char c in s1)
                {
                    if (c%2 == 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    cnt++;
                }
            }
            timer.Stop();
            return cnt;
        }


        //////////////////////////////////////////////////////


        static int reverse(int i)
        {
            int n = i, c = 0;

            int[] digits = new int[10];
            int nn = 0;

            while (n != 0)
            {
                int digit = n % 10;
                n /= 10;
                digits[c] = digit;

                nn *= 10;
                nn += digits[c++];
            }

            return nn;
        }

        static bool checkDigits(int n)
        {
            int i = n;
            while (i != 0)
            {
                int digit = i % 10;
                i /= 10;

                if (digit % 2 == 0)
                    return false;
            }

            return true;
        }

        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();

            int cnt = 0;
            for (int i = 1; i < 1000000000; i++)
            {
                if (i % 10 != 0)
                {
                    cnt += checkDigits(i + reverse(i)) ? 1 : 0;
                }
            }

            timer.Stop();
            return cnt;
        }
    }
}
