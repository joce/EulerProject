using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem041
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 7652413 in 178332609 ticks
        // Solution 2: Result = 7652413 in 250581 ticks

        // Brute-force-ish solution that looks at a whole lot of numbers
        [EulerSolution(false, reason: "Takes too long")]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000000;
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

            int res = -1;

            for (int i = 2143; i < 1000000000; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    if (i.ToString().OrderBy(c => c).Select((c, n) => c - '1' == n ? 0 : 1).Sum() == 0)
                    {
                        res = i;
                    }
                }
            }

            timer.Stop();

            return res;
        }


        //////////////////////////////////////////////////////


        // Lifted from https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array/10629938#10629938
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1).SelectMany(t => list.Where(o => !t.Contains(o)),
                                                                (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            // Using insight from jinjinir_cent on the Euler forums (https://projecteuler.net/thread=41&page=8#230021):
            //
            // Try all digit combinations:
            // Digits      Sum of digits
            // 1                OUT
            // 12          = 3  OUT
            // 123         = 6  OUT
            // 1234        = 10
            // 12345       = 15 OUT
            // 123456      = 21 OUT
            // 1234567     = 28
            // 12345678    = 36 OUT
            // 123456789   = 45 OUT
            //
            // Digits are "OUT" if sum of digits is divisible by 3. Such numbers, whose sum of digits is divisible by 3, are not prime.
            // Only two combinations remain:
            // 1234
            // 1234567

            timer.Restart();

            // Compute primes.
            const int max = 7654321 + 1; // Enough to get the biggest pandigital of length 7.
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

            int ret = -1;

            foreach (var len in new [] {7, 4})
            {
                var perms = GetPermutations(Enumerable.Range(1,len).Reverse(), len);
                foreach (var perm in perms)
                {
                    int val = perm.Reverse().Select((i, pow) => i*(int)Math.Pow(10, pow)).Sum();
                    if (primes[val] == 0)
                    {
                        ret = val; // We're checking in decreasing order. The first hit will be the one we're after.
                        goto Done;
                    }
                }
            }

        Done:

            timer.Stop();

            return ret;
        }
    }
}
