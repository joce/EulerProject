using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem010
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 10, Solution 1: Value = 142913828922 in 88719 ticks
        // Problem 10, Solution 2: Value = 142913828922 in 50901 ticks
        // Problem 10, Solution 3: Value = 142913828922 in 54379 ticks

        public static IEnumerable<long> Primes(long max)
        {
            byte[] primes = new byte[max];
            primes.Initialize();

            //yield return 1;
            yield return 2;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    yield return i;
                    for (int j = 3*i; j < max; j+=2*i)
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

        [EulerSolution]
		public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            long result = Primes(2000000).Sum();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static long Solution2(Stopwatch timer)
        {
            timer.Restart();
            const int max = 2000000;

            byte[] primes = new byte[max];
            primes.Initialize();

            long result = 2;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    result += i;
                    for (int j = 3*i; j < max; j+=2*i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            for (int i = (sqrt % 2 == 0 ? sqrt + 1 : sqrt); i < max; i+=2)
            {
                if (primes[i] == 0)
                {
                    result += i;
                }
            }

            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        // Surprisingly, it appears that the check for if (primes[j] == 0) is more costly that the extra loop
        // for (int i = (sqrt % 2 == 0 ? sqrt + 1 : sqrt); i < max; i+=2)
        [EulerSolution]
		public static long Solution3(Stopwatch timer)
        {
            timer.Restart();
            const long max = 2000000;

            byte[] primes = new byte[max+1];
            primes.Initialize();

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            long result = ((max) * (max) + max)/2 - ((max/2) * (max/2) + (max/2)) + 1;

            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    for (int j = 3*i; j < max; j+=2*i)
                    {
                        if (primes[j] == 0)
                        {
                            primes[j] = 1;
                            result -= j;
                        }
                    }
                }
            }

            timer.Stop();
            return result;
        }
    }
}
