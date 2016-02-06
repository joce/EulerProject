using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem050
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 997651 in 55353 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000;
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

            int maxCnt = -1;
            int maxPrime = -1;

            for (int i = 3; i < max; i+=2)
            {
                if (primes[i] == 1)
                {
                    continue;
                }
                int cnt = 0;
                int sum = i;
                for (int j = i+2; j < max && sum + j < 1000000; j+=2)
                {
                    if (primes[j] == 1)
                        continue;
                    sum += j;
                    cnt++;
                    if (primes[sum] == 0 && cnt > maxCnt)
                    {
                        maxPrime = sum;
                        maxCnt = cnt;
                    }
                }
            }

            timer.Stop();
            return maxPrime;
        }
    }
}
