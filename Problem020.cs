using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public static class Problem020
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 20, Solution 1: Value = 648 in 15972 ticks
        // Problem 20, Solution 2: Value = 648 in 90 ticks

        static Stopwatch _timer = new Stopwatch();

        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();
            BigInteger val = 1;
            for (int i = 2; i <= 100; i++)
            {
                val *= i;
            }
            int result = val.ToString().Select(c => c - '0').Sum();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 20, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static void Solution2()
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
            Trace.WriteLine(string.Format("Problem 20, Solution 2: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
