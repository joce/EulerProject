using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem079
    {
        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            // I did this one by hand.
            // I sorted the entries, removed the duplicates
            // and then checked which number came before which other.
            return 73162890;
        }
    }
}
