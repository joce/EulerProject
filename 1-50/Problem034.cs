using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem034
    {
        // The results I got are of the following order of magnitude:
        //
        // 	Solution 1: Result = 40730 in 6812837 ticks

        static readonly int[] factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            List<int> results = new List<int>();
            for (int i = 3; i < 9999999; i++)
            {
                if (i == i.ToString().Select(c => factorials[c - '0']).Sum())
                {
                    results.Add(i);
                }
            }
            int res = results.Sum();
            timer.Stop();
            return res;
        }
    }
}
