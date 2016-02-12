using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem076
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 190569291 in 205 ticks

        // This is basically just a repurpose of the best solution of problem 31 (coins sums)
        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int[] tbl = new int[101];
            tbl[0] = 1;
            foreach (var k in Enumerable.Range(1,99))
            {
                for (int j = k; j <= 100; j++)
                {
                    tbl[j] += tbl[j - k];
                }
            }

            int res = tbl[100];
            timer.Stop();
            return res;
        }
    }
}
