using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem087
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 1097343 in 322446 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            const int max = 50000000;
            // Compute primes using sieve.
            int maxPrime = (int)Math.Ceiling(Math.Sqrt(max));
            byte[] primeSieve = new byte[maxPrime]; // a prime is represented by a 0.
            primeSieve.Initialize();

            primeSieve[0] = 1;
            primeSieve[1] = 1;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(maxPrime));
            for (int i = 2; i < sqrt; i++)
            {
                if (primeSieve[i] == 0)
                {
                    for (int j = 2*i; j < maxPrime; j+=i)
                    {
                        primeSieve[j] = 1;
                    }
                }
            }

            // Get our list of primes.
            List<int> pList = new List<int>();
            for (int i = 0; i < maxPrime; i++)
            {
                if (primeSieve[i] == 0)
                    pList.Add(i);
            }

            // Find the numbers
            HashSet<long> foundNums = new HashSet<long>();

            foreach (var i in pList)
            {
                long val = i*i;
                foreach (var j in pList)
                {
                    long valj = val + j*j*j;
                    if (valj > max)
                        break;

                    foreach (var k in pList)
                    {
                        long valk = valj + k*k*k*k;
                        if (valk > max)
                            break;
                        foundNums.Add(valk);
                    }
                }
            }

            int res = foundNums.Count;
            timer.Stop();
            return res;
        }
    }
}
