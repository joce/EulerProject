using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem058
    {
        // The results I got are of the following order of magnitude:
        //
        //	Solution 1: Result = 26241 in 51479232 ticks
        //  Solution 2: Result = 26241 in 1408587 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000000;
            byte[] primes = new byte[max]; // a prime is represented by a 0.

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

            double totalCount = 1;
            double primeCount = 0;

            bool found = false;
            int n = 3;
            for (; n < 200000; n+=2)
            {
                // Diagonal 1: f(n) = (n-3)n + 3     (prime?)
                if (primes[(n - 3)*n + 3] == 0)
                {
                    primeCount++;
                }

                // Diagonal 2: f(n) = (n-2)n + 2     (prime?)
                if (primes[(n - 2)*n + 2] == 0)
                {
                    primeCount++;
                }

                // Diagonal 3: f(n) = (n-1)^2 + n    (prime?)
                if (primes[(n - 1)*(n - 1) + n] == 0)
                {
                    primeCount++;
                }

                // Diagonal 4: f(n) = n^2            (NEVER prime)

                totalCount += 4;

                double ratio = primeCount/totalCount;

                if (ratio < 0.1)
                {
                    found = true;
                    break;
                }
            }

            timer.Stop();
            return found ? n : -1;
        }


        //////////////////////////////////////////////////////


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
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();

            double totalCount = 1;
            double primeCount = 0;

            bool found = false;
            int n = 3;
            for (; n < int.MaxValue; n+=2)
            {
                // Diagonal 1: f(n) = (n-3)n + 3     (prime?)
                if (IsPrime((n - 3)*n + 3))
                {
                    primeCount++;
                }

                // Diagonal 2: f(n) = (n-2)n + 2     (prime?)
                if (IsPrime((n - 2)*n + 2))
                {
                    primeCount++;
                }

                // Diagonal 3: f(n) = (n-1)^2 + n    (prime?)
                if (IsPrime((n - 1)*(n - 1) + n))
                {
                    primeCount++;
                }

                // Diagonal 4: f(n) = n^2            (NEVER prime)

                totalCount += 4;

                double ratio = primeCount/totalCount;

                if (ratio < 0.1)
                {
                    found = true;
                    break;
                }
            }

            timer.Stop();
            return found ? n : -1;
        }
    }
}
