using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem046
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 5777 in 1383 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 10000;
            byte[] composites = new byte[max]; // a composite is represented by a 1.

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 2; i < sqrt; i++)
            {
                if (composites[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        composites[j] = 1;
                    }
                }
            }

            byte[] squares = new byte[max];
            int n = 1;
            int sq = 1;
            while (sq < max)
            {
                squares[sq] = 1;
                n++;
                sq = n*n;
            }

            int res = -1;
            for (int comp = 9; comp < max; comp+=2)
            {
                if (composites[comp] == 1)
                {
                    bool found = false;
                    for (int prim = comp-1; prim>=2; prim--)
                    {
                        if (composites[prim] == 1)
                            continue;

                        if (squares[(comp - prim)/2] == 1)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        res = comp;
                        break;
                    }
                }
            }

            timer.Stop();
            return res;
        }
    }
}
