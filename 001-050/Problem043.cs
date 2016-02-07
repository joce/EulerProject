using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem043
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 16695334890 in 163795860 ticks

        // Lifted from https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array/10629938#10629938
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1).SelectMany(t => list.Where(o => !t.Contains(o)),
                                                                (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        // Terrible solution. There has to be a better way.
        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            List<long> results = new List<long>();
            int[] even = {0, 2, 4, 6, 8};
            foreach (var perm in GetPermutations("1234567890", 10))
            {
                if (perm.First() == '0')
                {
                    continue;
                }
                char last = perm.Last();
                if (even.Contains(last))
                    continue;

                string s = new string(perm.ToArray());
                if (int.Parse(s.Substring(1, 3)) % 2 != 0)
                    continue;

                if (int.Parse(s.Substring(2, 3)) % 3 != 0)
                    continue;

                if (int.Parse(s.Substring(3, 3)) % 5 != 0)
                    continue;

                if (int.Parse(s.Substring(4, 3)) % 7 != 0)
                    continue;

                if (int.Parse(s.Substring(5, 3)) % 11 != 0)
                    continue;

                if (int.Parse(s.Substring(6, 3)) % 13 != 0)
                    continue;

                if (int.Parse(s.Substring(7, 3)) % 17 == 0)
                    results.Add(long.Parse(s));
            }

            long res = results.Sum();
            timer.Stop();
            return res;
        }
    }
}
