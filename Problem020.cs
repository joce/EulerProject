using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem020 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 20, Solution 1: Value = 648 in 15972 ticks
        // Problem 20, Solution 2: Value = 648 in 90 ticks

        [EulerSolution]
        public static int Solution1()
        {
            _timer.Restart();
            BigInteger val = 1;
            for (int i = 2; i <= 100; i++)
            {
                val *= i;
            }
            int result = val.ToString().Select(c => c - '0').Sum();
            _timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2()
        {
            _timer.Restart();
            BigInteger val = 1;
            for (int i = 2; i <= 100; i++)
            {
                val *= i;
            }
            string valStr = val.ToString();
            int result = -(valStr.Length * '0');
            foreach (var c in valStr)
            {
                result += c;
            }
            _timer.Stop();
            return result;
        }
    }
}
