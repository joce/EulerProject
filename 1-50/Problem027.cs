using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem027
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = -59231 in 24103 ticks

        // Fact: n^2 -61n +971 generates primes for n = [0, 71]

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000;
            byte[] primes = new byte[max]; // a prime is represented by a 0.
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

            int maxCnt = -1;
            int maxi = 0;
            int maxj = 0;

            for (int i = 0; i < 1000; i++)
            {
                if (primes[i] == 1) // not a prime
                    continue;
                for (int j = 0; j < 1000; j++)
                {
                    if (primes[j] == 1) // not a prime
                        continue;

                    // The following block is repeated 4 times, for (+i, +j), (-i, +j), (+i, -j) and (-i, -j).
                    // Could look nicer.
                    {
                        int cnt = 0;
                        while (true)
                        {
                            int r = cnt*cnt + i*cnt + j;
                            if (r < 0 || primes[r] == 1)
                                break;
                            cnt++;
                        }
                        if (cnt > maxCnt)
                        {
                            maxCnt = cnt;
                            maxi = i;
                            maxj = j;
                        }
                    }


                    {
                        int cnt = 0;
                        while (true)
                        {
                            int r = cnt*cnt - i*cnt + j;
                            if (r < 0 || primes[r] == 1)
                                break;
                            cnt++;
                        }
                        if (cnt > maxCnt)
                        {
                            maxCnt = cnt;
                            maxi = -i;
                            maxj = j;
                        }
                    }


                    {
                        int cnt = 0;
                        while (true)
                        {
                            int r = cnt*cnt + i*cnt - j;
                            if (r < 0 || primes[r] == 1)
                                break;
                            cnt++;
                        }
                        if (cnt > maxCnt)
                        {
                            maxCnt = cnt;
                            maxi = i;
                            maxj = -j;
                        }
                    }

                    {
                        int cnt = 0;
                        while (true)
                        {
                            int r = cnt*cnt - i*cnt - j;
                            if (r < 0 || primes[r] == 1)
                                break;
                            cnt++;
                        }
                        if (cnt > maxCnt)
                        {
                            maxCnt = cnt;
                            maxi = -i;
                            maxj = -j;
                        }
                    }
                }
            }

            int res = maxi*maxj;
            timer.Stop();
            return res;
        }
    }
}
