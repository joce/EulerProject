using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem040
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 210 in 11650 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int cnt = 0;
            int nextObjective = 1;
            int[] values = new int[7];
            for (int i = 1; i < 1000000; i++)
            {
                int nextCnt = cnt + (int) Math.Log10(i) + 1;
                if (nextCnt >= nextObjective)
                {
                    values[(int) Math.Log10(nextObjective)] = i.ToString().Skip(nextObjective-cnt-1).First() - '0';
                    if (nextObjective == 1000000)
                    {
                        break;
                    }
                    nextObjective *= 10;

                }
                cnt = nextCnt;
            }
            int res = values.Aggregate(1, (c, n) => c*n);
            timer.Stop();
            return res;
        }
    }
}
