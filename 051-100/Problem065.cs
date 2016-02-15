using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem065
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 272 in 6204 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            BigInteger[] num = new BigInteger[102];
            BigInteger[] den = new BigInteger[102];

            num[0] = 2;
            num[1] = 3;

            den[0] = den[1] = 1;

            for (int cnt = 2, batch = 1; cnt < 100; batch++)
            {
                num[cnt] = 2*batch*num[cnt - 1] + num[cnt - 2];
                den[cnt] = 2*batch*den[cnt - 1] + den[cnt - 2];
                cnt++;

                num[cnt] = num[cnt - 1] + num[cnt - 2];
                den[cnt] = den[cnt - 1] + den[cnt - 2];
                cnt++;

                num[cnt] = num[cnt - 1] + num[cnt - 2];
                den[cnt] = den[cnt - 1] + den[cnt - 2];
                cnt++;
            }

            int res = num[99].ToString().Select(c => c - '0').Sum();
            timer.Stop();
            return res;
        }
    }
}
