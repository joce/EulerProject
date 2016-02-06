using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem099
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 709 in 2435 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            double max = 0.0;
            int maxI = -1;
            int i = 1;
            foreach (var line in File.ReadAllLines(@"Problem099.data"))
            {
                var vals = line.Split(',').Select(int.Parse).ToArray();
                var val = Math.Log10(vals[0])*vals[1];
                if (val > max)
                {
                    max = val;
                    maxI = i;
                }
                i++;
            }

            timer.Stop();
            return maxI;
        }
    }
}
