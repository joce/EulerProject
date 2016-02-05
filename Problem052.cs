using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem052
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 142857 in 1377351 ticks

        // Rather poor brute force solution
        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int res = -1;
            for (int i = 1;; i++)
            {
                var _2 = new string((i*2).ToString().OrderBy(c=>c).ToArray());
                var _3 = new string((i*3).ToString().OrderBy(c=>c).ToArray());
                var _4 = new string((i*4).ToString().OrderBy(c=>c).ToArray());
                var _5 = new string((i*5).ToString().OrderBy(c=>c).ToArray());
                var _6 = new string((i*6).ToString().OrderBy(c=>c).ToArray());

                if (_2 == _3 && _2 == _4 && _2 == _5 && _2 == _6)
                {
                    res = i;
                    break;
                }
            }
            timer.Stop();
            return res;
        }
    }
}
