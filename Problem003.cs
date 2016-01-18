using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem003 : ProblemBase
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
            foreach (long i in Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(value))))
            {
                if (value % i == 0)
                {
                    res.Add(i);
                }
            }
            return res;
        }

        static HashSet<long> primes = new HashSet<long>();

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
        public static void Solution1()
        {
            _timer.Restart();
            long value = FindFactors1(600851475143).Where(IsPrime).Last();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 3, Solution 1: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        static List<long> FindFactors2(long value)
        {
            var res = new List<long>();
            foreach (long i in Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(value))))
            {
                if (value % i == 0 && IsPrime(i))
                {
                    res.Add(i);
                }
            }
            return res;
        }

        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();
            long value = FindFactors2(600851475143).Last();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 3, Solution 2: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
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
        public static void Solution3()
        {
            long seed = 600851475143;
            _timer.Restart();

            int value = Primes((int)Math.Ceiling(Math.Sqrt(seed))).Where(i => seed % i == 0).Last();

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 3, Solution 3: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static void Solution4()
        {
            _timer.Restart();
            long seed = 600851475143;
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

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 3, Solution 4: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }
    }
}
