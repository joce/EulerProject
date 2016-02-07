using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem092
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 8581146 in 33388723 ticks
        // Solution 2: Result = 8581146 in 32634710 ticks
        // Solution 3: Result = 8581146 in 8148340 ticks
        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int cnt = 0;
            for (int i = 2; i < 10000000; i++)
            {
                int v = i;
                while (v != 1 && v != 89)
                {
                    v = v.ToString().Select(c => (c - '0')*(c - '0')).Sum();
                }

                if (v == 89)
                {
                    cnt++;
                }
            }
            timer.Stop();
            return cnt;
        }

        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int cnt = 0;
            int[] sq = new int[(int)'9'+1];
            for (int i = '0'; i <= '9'; i++)
            {
                sq[i] = (i - '0')*(i - '0');
            }

            for (int i = 2; i < 10000000; i++)
            {
                int v = i;
                while (v != 1 && v != 89)
                {
                    v = v.ToString().Select(c => sq[c]).Sum();
                }

                if (v == 89)
                {
                    cnt++;
                }
            }
            timer.Stop();
            return cnt;
        }

        [EulerSolution]
        public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
            int cnt = 0;
            int[] sq = new int[(int)'9'+1];
            for (int i = '0'; i <= '9'; i++)
            {
                sq[i] = (i - '0')*(i - '0');
            }

            byte[] leadsTo89 = new byte[10000000];
            byte[] leadsTo1 = new byte[10000000];

            leadsTo89[89] = 1;
            leadsTo1[1] = 1;

            List<int> ints = new List<int>();

            for (int i = 2; i < 10000000; i++)
            {
                ints.Clear();
                int v = i;
                while (leadsTo89[v] == 0 && leadsTo1[v] == 0)
                {
                    v = v.ToString().Select(c => sq[c]).Sum();
                    ints.Add(v);
                }

                if (leadsTo89[v] == 1)
                {
                    foreach (var i1 in ints)
                    {
                        leadsTo89[i1] = 1;
                    }
                    cnt++;
                }

                if (leadsTo1[v] == 1)
                {
                    foreach (var i1 in ints)
                    {
                        leadsTo1[i1] = 1;
                    }
                }
            }
            timer.Stop();
            return cnt;
        }
    }
}
