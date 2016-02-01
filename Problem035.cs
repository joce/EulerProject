using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem035
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 55 in 68597 ticks

        private static readonly char[] avoid = {'0', '2', '4', '5', '6', '8'};

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000;
            byte[] primes = new byte[max]; // a prime is represented by a 0.
            primes.Initialize();

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

            int res = 3; // We assume '2', 3 and 5 are already counted.

            for (int i = 7; i < 1000000; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    string p = i.ToString();
                    if (p.Any(c => avoid.Contains(c)))
                    {
                        continue;
                    }

                    bool allPrimes = true;
                    for (int j = 0; j < p.Length-1; j++)
                    {
                        p = p[p.Length-1] + p.Substring(0, p.Length-1); // Rotate the number
                        if (primes[int.Parse(p)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }
                    }

                    if (allPrimes)
                    {
                        res++;
                    }
                }
            }
            timer.Stop();
            return res;
        }
    }
}
