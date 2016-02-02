using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem049
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 296962999629 in 100601 ticks

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int maxPrime = 10000;
            byte[] primes = new byte[maxPrime]; // a prime is represented by a 0.
            primes.Initialize();

            primes[0] = 1;
            primes[1] = 1;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(maxPrime));
            for (int i = 2; i < sqrt; i++)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < maxPrime; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            List<Tuple<int,int,int>> res = new List<Tuple<int, int, int>>();
            for (int i = 1007; i < 9999; i+=2)
            {
                if (primes[i] == 0)
                {
                    int max = ((9999 - i)/2) + 1;
                    for (int n = 2; n < max; n++)
                    {
                        if (primes[i + n] == 0 && primes[i + 2*n] == 0)
                        {
                            string s1 = new string(i.ToString().OrderBy(c => c).ToArray());
                            string s2 = new string((i + n).ToString().OrderBy(c => c).ToArray());
                            string s3 = new string((i + 2*n).ToString().OrderBy(c => c).ToArray());
                            if (s1 == s2 && s2 == s3)
                            {
                                res.Add(Tuple.Create(i, i + n, i + 2*n));
                                if (res.Count == 2) // We know there's only 2 such groups of numbers.
                                {
                                    goto Done;
                                }
                            }
                        }
                    }
                }
            }

        Done:
            long result = 0;
            foreach (var tuple in res)
            {
                if (tuple.Item1 == 1487) // The group starting with 1487 isn't the one we're after.
                    continue;
                result = (tuple.Item1 * 100000000L) + (tuple.Item2 * 10000) + tuple.Item3;
            }
            timer.Stop();
            return result;
        }
    }
}
