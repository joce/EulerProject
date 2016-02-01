using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem037
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 748317 in 80747 ticks

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

            List<int> l = new List<int>();

            for (int i = 11; i < 1000000; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    string p = i.ToString();

                    bool allPrimes = true;
                    for (int j = 1; j < p.Length; j++)
                    {
                        string s = p.Substring(0, p.Length-j); // Rotate the number
                        if (primes[int.Parse(s)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }

                        string s1 = p.Substring(j, p.Length-j); // Rotate the number
                        if (primes[int.Parse(s1)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }
                    }

                    if (allPrimes)
                    {
                        l.Add(i);
                    }
                }
            }

            int res = l.Sum();
            timer.Stop();

            return res;
        }
    }
}
