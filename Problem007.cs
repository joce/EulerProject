using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem007
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 7, Solution 1: Value = 104743 in 35707 ticks
        // Problem 7, Solution 2: Value = 104743 in 92947 ticks

        public static IEnumerable<int> Primes(int max)
        {
            byte[] primes = new byte[max];
            primes.Initialize();

            yield return 1;
            yield return 2;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    yield return i;
                    for (int j = 2*i; j < max; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            for (int i = (sqrt % 2 == 0 ? sqrt + 1 : sqrt); i < max; i+=2)
            {
                if (primes[i] == 0)
                {
                    yield return i;
                }
            }
        }


        // This version cheats as I use compute the primes using the the sieve of Eratosthenes. However, this method requires you know the upper bound
        // you want to compute your primes to (i.e. compute all primes below 1000000). In this case, I used a rough estimate, got the result, then
        // use this result as the upper bound.
        [EulerSolution]
		public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // 10002 because in the problem, they don't seem to assume 1 is prime.
            int result = Primes(104745).Take(10002).Last();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        // This is IMO a better general case solution (albeit slower) in the case where you don't know what an approximate value of the prime you're looking for.
        // I've also found that no isqrt implementation I tried was faster that the double Math.Sqrt() cast to an int. Weird.
        [EulerSolution]
		public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int result = 0;
            int[] primes = new int[10001];
            primes.Initialize();
            int nbPrime = 0;
            primes[nbPrime++] = 2;
            for(int i = 3; i < Int32.MaxValue; i+=2)
            {
                bool isPrime = true;
                int sqrt = (int)Math.Sqrt(i) + 1;
                for(int j = 0; primes[j] < sqrt; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    primes[nbPrime++] = i;
                }
                if (nbPrime == 10001)
                {
                    result = i;
                    break;
                }
            }
            timer.Stop();

            return result;
        }
    }
}
