using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem041
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 7652413 in 178332609 ticks

        // Brute-force-ish solution that looks at a whole lot of numbers
        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000000;
            byte[] primes = new byte[max]; // a prime is represented by a 0.
            primes.Initialize();

            primes[0] = 1;
            primes[1] = 1;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 2; i < sqrt; i++)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            int res = -1;

            for (int i = 2143; i < 1000000000; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    if (i.ToString().OrderBy(c => c).Select((c, n) => c - '1' == n ? 0 : 1).Sum() == 0)
                    {
                        res = i;
                    }
                }
            }

            timer.Stop();

            return res;
        }
    }
}
