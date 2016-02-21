using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem102
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 228 in 5931 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Inspiration drawn from StackOverflow:
            // http://stackoverflow.com/a/9755252/82682
            int cnt = 0;
            foreach (var line in File.ReadAllLines(@"Problem102.data"))
            {
                var coords = line.Split(',').Select(int.Parse).ToArray();

                int as_x = -coords[0];
                int as_y = -coords[1];

                bool s_ab = (coords[2]-coords[0])*as_y-(coords[3]-coords[1])*as_x > 0;

                if ((coords[4]-coords[0])*as_y-(coords[5]-coords[1])*as_x > 0 == s_ab)
                    continue;

                if ((coords[4]-coords[2])*(-coords[3])-(coords[5]-coords[3])*(-coords[2]) > 0 != s_ab)
                    continue;

                cnt++;
            }
            timer.Stop();
            return cnt;
        }
    }
}
