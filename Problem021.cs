using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public static class Problem021
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 21, Solution 1: Value = 31626 in 84208 ticks
        // Problem 21, Solution 2: Value = 31626 in 19140 ticks

        static Stopwatch _timer = new Stopwatch();

        static IEnumerable<int> FindFactors1(int value)
        {
            yield return 1;
            foreach (int i in Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(value))))
            {
                if (value % i == 0)
                {
                    yield return i;
                    yield return value / i;
                }
            }
        }

        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();

            HashSet<int> amicable = new HashSet<int>();

            Dictionary<int, int> values = new Dictionary<int, int>();
            for (int i = 1; i < 10000; i++)
            {
                int sum = FindFactors1(i).Sum();
                values.Add(i, sum);
                if (i != sum && values.ContainsKey(sum) && values[sum] == i)
                {
                    amicable.Add(i);
                    amicable.Add(sum);
                }
            }

            int result = amicable.Sum();
                        
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 21, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();

            int result = 0;
            int[] values = new int[10000];
            for (int i = 1; i < 10000; i++)
            {
                int sum = 1;
                int sqrt = (int)Math.Floor(Math.Sqrt(i));
                for (int j = 2; j < sqrt; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                        sum += (i / j);
                    }
                }

                values[i] = sum;
                if (i > sum && values[sum] == i)
                {
                    result += (i + sum);
                }
            }

            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 21, Solution 2: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
