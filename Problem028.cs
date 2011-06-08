using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public static class Problem028
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 28, Solution 1: Total = 669171001 in 15554 ticks
        // Problem 28, Solution 2: Total = 669171001 in 5 ticks

        static Stopwatch _timer = new Stopwatch();

        // For a given level of the spiral, the numbers to add are:
        // n^2
        // n^2 - (n-1)
        // n^2 - 2(n-1)
        // n^2 - 3(n-1)
        // Which can be simplified to 4n^2 - 6(n-1)
        // Given that we only add the odd numbers >= 3, we can then use 
        // 4(2n+1)^2 - 6(2n+1-1) => 
        // 4(2n+1)^2 - 12n =>
        // 4(4n^2 + 4n) - 12n =>
        // 16n^2 + 4n + 4
        //
        // We also need to add 1 to the computed total as it's the center of both diagonals.
        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();
            int result = Enumerable.Range(1, 500).Select(n => (16 * (n * n)) + (4 * n) + 4).Sum() + 1;
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 28, Solution 1: Total = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        // Decomposing further, we have 
        // sum(16n^2 + 4n + 4) + 1 =>
        // sum(16n^2) + sum(4n) + sum(4) + 1 =>
        // 16*sum(n^2) + 4*sum(n) + 4n +1 =>
        // 16*sum(n^2) + 4(n(n+1)/2) + 4n + 1 =>
        // 16*sum(n^2) + 2n^2 + 2n + 4n + 1
        // 16*sum(n^2) + 2n^2 + 6n + 1
        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();
            int result = 0;
            int limit = 500;
            for (int i = 1; i <= limit; i++)
            {
                result += (i * i);
            }
            result *= 16;
            result += 2 * (limit * limit);
            result += 6 * limit;
            result += 1;
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 28, Solution 2: Total = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
