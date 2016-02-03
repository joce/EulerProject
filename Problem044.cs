using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem044
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 5482660 in 175636 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute the pentagonal numbers up to 10M
            const int max = 10000000;
            byte[] pentagonalSieve = new byte[max];
            List<int> pentagonalVals = new List<int>();
            int val = 1;
            int n = 1;
            do
            {
                pentagonalSieve[val] = 1;
                pentagonalVals.Add(val);
                n++;
                val = (n*(3*n - 1)) / 2;
            } while (val < max);

            int minDiff = -1;
            for (int j = 0; j < pentagonalVals.Count; j++)
            {
                for (int k = j+1; k < pentagonalVals.Count; k++)
                {
                    int sum = pentagonalVals[j] + pentagonalVals[k];
                    int diff = pentagonalVals[k] - pentagonalVals[j];
                    if (sum < max && pentagonalSieve[sum] == 1 && pentagonalSieve[diff] == 1)
                    {
                        minDiff = diff;
                        goto Done;
                    }
                }
            }
        Done:
            timer.Stop();
            return minDiff;
        }
    }
}
