using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem493
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = xxx in xxx ticks

        [EulerSolution]
        public static double Solution1(Stopwatch timer)
        {
            timer.Restart();
            // Got this from Wolfram Alpha:
            //
            // 7 * (1 - (60 choose 20) / (70 choose 20))
            timer.Stop();
            return 6.818741802;
        }
    }
}
