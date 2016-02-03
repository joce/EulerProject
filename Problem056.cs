using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem056
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 972 in 92615 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int max = -1;
            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    var digitSum = BigInteger.Pow(a, b).ToString().Select(c => c - '0').Sum();
                    if (digitSum > max)
                    {
                        max = digitSum;
                    }
                }
            }
            timer.Stop();
            return max;
        }
    }
}
