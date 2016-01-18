using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem025 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 25, Solution 1: Value = 4782 in 316790 ticks
        // Problem 25, Solution 2: Total = 4782 in 234651 ticks

        static IEnumerable<BigInteger> GetFibo()
        {
            BigInteger prev = 0;
            BigInteger cur = 1;

            for (;;)
            {
                yield return cur;
                BigInteger temp = cur;
                cur = cur + prev;
                prev = temp;
            }
        }

        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();
            int cnt = 1;
            int result = GetFibo().TakeWhile(bi=> bi.ToString().Length < 1000).Select(bi => ++cnt).Last();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 25, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();
            BigInteger prev = 0;
            BigInteger cur = 1;
            int cnt = 1;
            while (cur.ToString().Length < 1000)
            {
                cnt++;
                BigInteger temp = cur;
                cur += prev;
                prev = temp;
            }
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 25, Solution 2: Total = {0} in {1} ticks", cnt, _timer.ElapsedTicks));
        }
    }
}
