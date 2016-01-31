using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem029
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 9183 in 34831 ticks

        private static IEnumerable<BigInteger> GetAllPowers()
        {
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    yield return BigInteger.Pow(i, j);
                }
            }
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            // Brute force
            timer.Restart();
            int res = GetAllPowers().Distinct().Count();
            timer.Stop();
            return res;
        }
    }
}
