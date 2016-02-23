using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem072
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 303963552393 in 805086337 ticks

        private static int[] s_primes;

        static IEnumerable<int> GetPrimeFactors(int val)
        {
            foreach (var prime in s_primes)
            {
                if (prime > val)
                {
                    break;
                }

                if (val%prime == 0)
                {
                    yield return prime;
                }
            }
        }

        // Terribly slow solution
        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
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

            s_primes = pList.ToArray();

            double res = 0.0;
            for (int n = 1; n < max; n++)
            {
                double phi = n;
                foreach (var primeFactor in GetPrimeFactors(n))
                {
                    phi *= (1-(1.0/primeFactor));
                }
                res += phi;
            }

            res++;
            timer.Stop();
            return (long)res;
        }
    }
}
