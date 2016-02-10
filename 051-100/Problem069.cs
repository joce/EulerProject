using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem069
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 510510 in 322734494 ticks

        private static int[] s_primes;

        static IEnumerable<int> GetPrimeFactors(int val)
        {
            int max = (int)Math.Ceiling(val/2.0);

            foreach (var prime in s_primes)
            {
                if (prime > max)
                {
                    break;
                }

                if (val%prime == 0)
                {
                    yield return prime;
                }
            }
        }

        // Horrible solution.
        [EulerSolution(false, reason: "Takes too long")]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            // Compute primes.
            const int max = 1000001;
            byte[] primes = new byte[max]; // a prime is represented by a 0.

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

            List<int> pList = new List<int>();
            for (int i = 0; i < max; i++)
            {
                if (primes[i] == 0)
                {
                    pList.Add(i);
                }
            }

            primes = null; // we're done with the sieve
            s_primes = pList.ToArray();

            double maxRatio = 0;
            int maxN = -1;

            for (int n = 3; n < max; n++)
            {
                double phi = n;
                foreach (var primeFactor in GetPrimeFactors(n))
                {
                    phi *= (1-(1.0/primeFactor));
                }
                phi = Math.Round(phi);
                var ratio = n/phi;
                if (ratio > maxRatio)
                {
                    maxRatio = ratio;
                    maxN = n;
                }
            }

            timer.Stop();


            return maxN;
        }
    }
}
