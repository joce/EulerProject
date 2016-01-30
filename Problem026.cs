using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem026
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 983 in 477468 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int maxCycle = -1;
            int idx = -1;
            for (int divider = 3; divider <= 1000; divider+=2)
            {
                int leftover = 1;

                int[] numbers = new int[5000];
                int[] leftovers = new int[5000];
                int cycleLen = 0;

                int i = 0;

                while (leftover%divider != 0)
                {
                    if (leftovers.Contains(leftover))
                    {
                        cycleLen = i - Array.LastIndexOf(leftovers, leftover);
                        leftovers[i] = leftover;
                        break;
                    }
                    leftovers[i] = leftover;
                    leftover *= 10;

                    numbers[i] = leftover/divider;
                    leftover = leftover - divider*(numbers[i]);
                    i++;
                }

                if (cycleLen > maxCycle)
                {
                    maxCycle = cycleLen;
                    idx = divider;
                }
            }

            timer.Stop();
            return idx;
        }
    }
}
