using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem357
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = xxx in xxx ticks

        static IEnumerable<int> Divisors(int val)
        {
            yield return 1;
            if (val != 1)
                yield return val;
            else
                yield break;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(val));
            for (int i = 2; i < sqrt; i++)
            {
                if (val%i == 0)
                {
                    yield return i;
                    yield return val/i;
                }
            }

            if (sqrt*sqrt == val)
            {
                yield return sqrt;
            }
        }

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 100000000;
            byte[] primes = new byte[max+1]; // a prime is represented by a 0.
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

            long sum = 0;
            for (int val = 1; val < max; val++)
            {
                bool match = true;
                foreach (var d in Divisors(val))
                {
                    if (primes[d + val/d] == 1)
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    sum += val;
            }
            timer.Stop();
            return sum;
        }
    }
}
