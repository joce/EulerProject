using System.Diagnostics;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem057
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 153 in 18854 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            BigInteger num = 3;
            BigInteger den = 2;
            int cnt = 0;
            for (int i = 0; i < 1000; i++)
            {
                if ((int) BigInteger.Log10(num) > (int) BigInteger.Log10(den))
                {
                    cnt++;
                }
                BigInteger newNum = 2*den + num;
                BigInteger newDen = num + den;
                num = newNum;
                den = newDen;
            }
            timer.Stop();
            return cnt;
        }
    }
}
