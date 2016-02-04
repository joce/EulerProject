using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem039
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 840 in 364099 ticks
        // Solution 2: Result = 840 in 15097 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int maxCnt = -1;
            int maxN = -1;

            for (int n = 3; n < 1000; n += 1)
            {
                int cnt = 0;
                int maxA = n/3;
                int maxB = n/2;
                for (int a = 1; a <= maxA; a++)
                {
                    for (int b = a; b <= maxB; b++)
                    {
                        int c = n - (a + b);
                        if (a*a + b*b == c*c)
                        {
                            cnt++;
                        }
                    }
                }

                if (cnt > maxCnt)
                {
                    maxCnt = cnt;
                    maxN = n;
                }
            }
            timer.Stop();
            return maxN;
        }


        //////////////////////////////////////////////////////


        static int gcd(int a, int b)
        {
            while (b != 0)
            {
                int r = a%b;
                a = b;
                b = r;
            }
            return a;
        }

        static int lcm(int a, int b)
        {
            return (a*b)/gcd(a, b);
        }

        // Solution inspired from gofs's Python solution on Euler's forums:
        // https://projecteuler.net/thread=39&page=8
        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();

            var a = new HashSet<int>();
            int maxlcm = 1;
            int t = 0;
            var results = new List<int>();

            for (int i = 2; i <= 20; i++)
            {
                int k = i%2 == 0 ? 1 : 2;
                for (int j = k; j < i; j+=2)
                {
                    if (gcd(i, j) == 1)
                    {
                        a.Add(2*i*(i + j));
                    }
                }
            }

            var sortedA = a.OrderBy(v => v).ToArray();

            while (maxlcm < 1000)
            {
                maxlcm = lcm(maxlcm, sortedA[t]);
                results.Add(maxlcm);
                t++;
            }

            int res = results[results.Count - 2];
            timer.Stop();
            return res;
        }
    }
}
