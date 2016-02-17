using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem074
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 402 in 7258617 ticks

        static readonly int[] factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            List<int> lst = new List<int>();
            int cnt = 0;

            for (int i = 1; i < 1000000; i++)
            {
                lst.Clear();
                int v = i;
                while (!lst.Contains(v))
                {
                    lst.Add(v);
                    int n = v;
                    v = 0;
                    while (n != 0)
                    {
                        int d = n%10;
                        n /= 10;
                        v += factorials[d];
                    }
                }

                if (lst.Count == 60)
                {
                    cnt++;
                }
            }

            timer.Stop();
            return cnt;
        }
    }
}
