using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem005
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 5, Solution 1: Value = 232792560 in 32855954 ticks
        // Problem 5, Solution 2: Value = 232792560 in 518492188 ticks
        // Problem 5, Solution 3: Total = 232792560 in 3275 ticks
        // Problem 5, Solution 4: Total = 232792560 in 11 ticks

        [EulerSolution(false, reason: "Takes too long")]
		public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int result = 0;
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                bool found = true;
                for (int j = 1; j <= 20; j++)
                {
                    if (i % j != 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    result = i;
                    break;
                }
            }
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution(false, reason: "Takes too long")]
		public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int result = Enumerable.Range(1, Int32.MaxValue).First(i => Enumerable.Range(1, 20).Select(j => i % j).Sum() == 0);
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        public static int[] Primes(int max)
        {
            byte[] naturals = new byte[max];
            naturals.Initialize();

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (naturals[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        naturals[j] = 1;
                    }
                }
            }

            var primes = new List<int> {1, 2};
            for (int i = 3; i < max; i+=2)
            {
                if (naturals[i] == 0)
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }

        public static int[] PrimeFactors(int value, int[] primes)
        {
            var primeFactors = new int[primes.Length];
            primeFactors.Initialize();
            while (value != 1)
            {
                // We skip '1', the 0th prime.
                for (int i = 1; i < primes.Length; i++)
                {
                    if (value % primes[i] == 0)
                    {
                        primeFactors[i]++;
                        value /= primes[i];
                    }
                }
            }
            return primeFactors;
        }

        [EulerSolution]
		public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
			int total = 1;
			int[] primes = Primes(20);
            int[] maxPrimeFactors = new int[primes.Length];
            for (int i = 2; i <= 20; i++)
            {
                int[] primeFactors = PrimeFactors(i, primes);
                for (int j = 0; j < primeFactors.Length; j++)
                {
                    if (primeFactors[j] > maxPrimeFactors[j])
                    {
                        maxPrimeFactors[j] = primeFactors[j];
                    }
                }
            }

            for (int i = 1; i < primes.Length; i++)
            {
                total *= (int)Math.Pow(primes[i],  maxPrimeFactors[i]);
            }
            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        // Devin's O(n^2) solution.
        [EulerSolution]
		public static int Solution4(Stopwatch timer)
        {
            timer.Restart();
			int total = 1;
			int[] factors = new int[21];
            for (int i = 2; i <= 20; ++i)
            {
                int value = i;
                int j;
                for (j = 2; j < i; ++j)
                {
                    if (value % factors[j] == 0)
                    {
                        value /= factors[j];
                    }
                }
                factors[j] = value;
                total *= value;
            }
            timer.Stop();
            return total;
        }
    }
}
