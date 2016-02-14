using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem062
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 127035954683 in 870569 ticks

        static long OrderedPermutation(long val)
        {
            char[] orderedChar = val.ToString().OrderBy(c => c != '0' ? c : c+10).ToArray();
            return long.Parse(new string(orderedChar));
        }

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            var r = Enumerable.Range(1, 100000)
                              .Select(v => (long) v*v*v)
                              .GroupBy(OrderedPermutation)
                              .Where(g => g.Count() == 5)
                              .SelectMany(g => g.Select(e => e))
                              .OrderBy(v => v)
                              .First();
            timer.Stop();
            return r;
        }
    }
}
