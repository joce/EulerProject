using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EulerProject
{
    [EulerProblem]
    public class Problem032
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 45228 in 169345 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            const string pendigital = "123456789";
            HashSet<int> results = new HashSet<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < 10000; i++)
            {
                for (int j = i + 1; j < 10000; j++)
                {
                    sb.Clear();
                    int z = i*j;
                    sb.Append(i);
                    sb.Append(j);
                    sb.Append(z);
                    if (sb.Length > 9)
                    {
                        break;
                    }
                    if (sb.Length < 9)
                    {
                        continue;
                    }
                    if (new string(sb.ToString().OrderBy(c => c).ToArray()) == pendigital)
                    {
                        results.Add(z);
                    }
                }
            }

            int res = results.Sum();
            timer.Stop();
            return res;
        }
    }
}
