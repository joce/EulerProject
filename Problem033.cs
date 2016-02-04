using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem033
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 100 in 327 ticks

        static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int r = a%b;
                a = b;
                b = r;
            }
            return a;
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int num = 1;
            int den = 1;

            for (int i = 11; i < 100; i++)
            {
                float fi = i;
                for (int j = i+1; j < 100; j++)
                {
                    float r = fi/j;
                    if ((i/10 == j%10 && (float)(i/10)/(j%10) == r) ||
                        (i%10 == j/10 && (float)(i/10)/(j%10) == r))
                    {
                        num *= i;
                        den *= j;
                    }
                }
            }

            int res = den/Gcd(num, den);

            timer.Stop();
            return res;
        }
    }
}
