using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem042
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 162 in 12513 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            const int max = 1000;
            byte[] triangular = new byte[max];
            int val = 1;
            int i = 1;
            do
            {
                triangular[val] = 1;
                i++;
                val = (i*(i + 1))/2;
            } while (val < max);

            int count = File.ReadAllText(@"Problem042.data")
                            .Split(',')
                            .Select(s => s.Trim('"')
                                          .Select(c => c-'@')
                                          .Sum())
                            .Count(t => triangular[t] == 1);
            timer.Stop();
            return count;
        }
    }
}
