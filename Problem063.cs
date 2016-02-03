using System.Diagnostics;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem063
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 49 in 220 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int cnt = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int pow = 1; pow <= 21; pow++)
                {
                    if (BigInteger.Pow(i, pow).ToString().Length == pow)
                    {
                        cnt++;
                    }
                }
            }

            timer.Stop();
            return cnt;
        }
    }
}
