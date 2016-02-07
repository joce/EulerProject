using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem097
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 8739992577 in 166988 ticks

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();

            long val = 1;

            for (int i = 0; i < 7830457; i++)
            {
                val *= 2;
                val %= 10000000000;
            }
            val *= 28433;
            val++;
            val %= 10000000000;
            timer.Stop();
            return val;
        }
    }
}
