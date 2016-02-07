using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem047
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 134043 in 582637 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int max = 1000000;
            int maxPrimeDivider = (int)Math.Ceiling(Math.Sqrt(max));

            byte[] primes = new byte[maxPrimeDivider];
            primes.Initialize();

            int sqrt = (int)Math.Ceiling(Math.Sqrt(maxPrimeDivider));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < maxPrimeDivider; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            int firstOfFour = -1;
            int fourPrimeDivsCnt = 0;

            for (int n = 6; n < max; n++)
            {
                int primeDividersCnt = n % 2 == 0 ? 1 : 0;
                int cap = Math.Min(n, maxPrimeDivider);

                for (int i = 3; i < cap; i+=2)
                {
                    if (primes[i] == 0 && (n % i == 0))
                    {
                        primeDividersCnt++;
                    }
                }

                if (primeDividersCnt == 4)
                {
                    if (firstOfFour == -1)
                    {
                        firstOfFour = n;
                        fourPrimeDivsCnt = 1;
                    }
                    else
                    {
                        fourPrimeDivsCnt++;
                        if (fourPrimeDivsCnt == 4)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    firstOfFour = -1;
                }
            }

            timer.Stop();
            return firstOfFour;
        }
    }
}
