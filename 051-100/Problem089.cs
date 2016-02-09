using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EulerProject
{
    [EulerProblem]
    public class Problem089
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 743 in 17703 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int res = 0;
            var regexOnes = new Regex("(V?IIII)", RegexOptions.Compiled);
            var regexTens = new Regex("(L?XXXX)", RegexOptions.Compiled);
            var regexHundreds = new Regex("(D?CCCC)", RegexOptions.Compiled);
            foreach (var line in File.ReadAllLines("Problem089.data"))
            {
                var match = regexOnes.Match(line);
                if (match.Success)
                {
                    res += match.Value.Length - 2; // Length of either IX or IV is 2.
                }

                match = regexTens.Match(line);
                if (match.Success)
                {
                    res += match.Value.Length - 2; // Length of either XC or XL is 2.
                }

                match = regexHundreds.Match(line);
                if (match.Success)
                {
                    res += match.Value.Length - 2; // Length of either CM or CD is 2.
                }
            }
            timer.Stop();
            return res;
        }
    }
}
