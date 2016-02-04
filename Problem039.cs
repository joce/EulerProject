using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem039
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 840 in 364099 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int maxCnt = -1;
            int maxN = -1;

            for (int n = 3; n < 1000; n+=1)
            {
                int cnt = 0;
                int maxA = n/3;
                int maxB = n/2;
                for (int a = 1; a <= maxA; a++)
                {
                    for (int b = a; b <= maxB; b++)
                    {
                        int c = n - (a + b);
                        if (a*a + b*b == c*c)
                        {
                            cnt++;
                        }
                    }
                }

                if (cnt > maxCnt)
                {
                    maxCnt = cnt;
                    maxN = n;
                }
            }
            timer.Stop();
            return maxN;
        }
    }
}
