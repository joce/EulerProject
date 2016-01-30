using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem000
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = xxx in xxx ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            timer.Stop();
            return 0;
        }
    }
}
