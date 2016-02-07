using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem053
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 4075 in 141 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            double expLog = 0.0;
            double [] expLogs = new double[101];
            for (int i = 1; i <= 100; i++)
            {
                expLog += Math.Log10(i);
                expLogs[i] = expLog;
            }

            int overOneMillion = 0;
            for (int n = 23; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    double combLog = expLogs[n] - (expLogs[r] + expLogs[n - r]);
                    if (combLog >= 6.0)
                    {
                        overOneMillion++;
                    }
                }
            }

            timer.Stop();
            return overOneMillion;
        }
    }
}
