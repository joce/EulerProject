using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem003
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 3, Solution 1: Value = 6857 in 175500 ticks
        // Problem 3, Solution 2: Value = 6857 in 69071 ticks
        // Problem 3, Solution 3: Value = 6857 in 57826 ticks
        // Problem 3, Solution 4: Value = 6857 in 33253 ticks

        static List<long> FindFactors1(long value)
        {
            var res = new List<long>();
            foreach (int i in Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(value))))
            {
                if (value % i == 0)
                {
                    res.Add(i);
                }
            }
            return res;
        }

        static bool IsPrime(long value)
        {
            if (value % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i < (int)Math.Floor(Math.Sqrt(value)); i+=2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        [EulerSolution]
		public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            long value = FindFactors1(600851475143).Where(IsPrime).Last();
            timer.Stop();
            return value;
        }


        //////////////////////////////////////////////////////


        static List<long> FindFactors2(long value)
        {
            var res = new List<long>();
            foreach (int i in Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(value))))
            {
                if (value % i == 0 && IsPrime(i))
                {
                    res.Add(i);
                }
            }
            return res;
        }

        [EulerSolution]
		public static long Solution2(Stopwatch timer)
        {
            timer.Restart();
            long value = FindFactors2(600851475143).Last();
            timer.Stop();
            return value;
        }


        //////////////////////////////////////////////////////


        public static IEnumerable<int> Primes(int max)
        {
            byte[] primes = new byte[max];
            primes.Initialize();

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            yield return 1;
            yield return 2;
            for (int i = 3; i < max; i+=2)
            {
                if (primes[i] == 0)
                {
                    yield return i;
                }
            }
        }

        [EulerSolution]
		public static long Solution3(Stopwatch timer)
        {
            timer.Restart();
			const long seed = 600851475143;
			int value = Primes((int)Math.Ceiling(Math.Sqrt(seed))).Last(i => seed % i == 0);
            timer.Stop();
            return value;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static int Solution4(Stopwatch timer)
        {
            timer.Restart();
            const long seed = 600851475143;
            int maxPrimeDivider = (int)Math.Ceiling(Math.Sqrt(seed));

            byte[] primes = new byte[maxPrimeDivider];
            primes.Initialize();

            int sqrt = (int)Math.Ceiling(Math.Sqrt(maxPrimeDivider));
            for (int i = 3; i < sqrt; i+=2)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < maxPrimeDivider; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            int value = 1;
            for (int i = 3; i < maxPrimeDivider; i+=2)
            {
                if (primes[i] == 0 && (seed % i == 0))
                {
                    value = i;
                }
            }

            timer.Stop();
            return value;
        }
    }
}
