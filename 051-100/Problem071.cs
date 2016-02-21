using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem071
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 428570 in 8821 ticks

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();

            long bestNum = 0;
            long bestDen = 1;

            for (int den = 1000000; den > 2; den--)
            {
                long num = (3*den - 1)/7;
                if (num*bestDen > bestNum*den)
                {
                    bestNum = num;
                    bestDen = den;
                }
            }

            timer.Stop();
            return bestNum;
        }
    }
}
