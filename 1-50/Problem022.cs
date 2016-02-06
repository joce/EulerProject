using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem022
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 22, Solution 1: Value = 871198282 in 67787 ticks
        // Problem 22, Solution 2: Value = 871198282 in 83760 ticks

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();

            int i = 1;
            long result = File.ReadAllText(@"Problem022.data").Split(',').OrderBy(s => s).Select(s => s.Trim('"').Select(c => c - 'A' + 1).Sum() * i++).Sum();
            timer.Stop();

            return result;
        }


        //////////////////////////////////////////////////////


        // Surprisingly, the non-LINQ version isn't faster that the LINQ one. That's a first! :-/
        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();

            SortedList<string, bool> l = new SortedList<string, bool>();

            int i = 1;
            int start = i;
            string s = File.ReadAllText(@"Problem022.data");
            while (i < s.Length)
            {
                while (s[i] != '"')
                {
                    i++;
                }
                l.Add(s.Substring(start, i-start), true);
                i+=3;
                start = i;
            }

            int offset = -'A' + 1;
            int result = 0;
            i = 1;
            foreach (var item in l)
            {
                int t = 0;
                int j = 0;
                foreach (var c in item.Key)
                {
                    t += c;
                    j++;
                }
                t += (offset * j);
                result += t*i;
                i++;
            }

            timer.Stop();
            return result;
        }
    }
}
