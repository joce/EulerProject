using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem031
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 73682 in 10604316 ticks
        // Solution 2: Result = 73682 in 875415 ticks
        // Solution 3: Result = 73682 in 22 ticks

        // I must admit feeling pretty dumb as I can't really wrap my head around the solution.
        // This solution was lifted from http://stackoverflow.com/a/18865778/82682
        private static int CountChange(int money, IEnumerable<int> coins)
        {
            int[] c = coins.ToArray();
            if (money == 0)
                return 1;
            if (c.Length == 0 || money < 0)
                return 0;
            return CountChange(money - c[0], c) + CountChange(money, c.Skip(1));
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int res = CountChange(200, new[] {1, 2, 5, 10, 20, 50, 100, 200});
            timer.Stop();
            return res;
        }


        //////////////////////////////////////////////////////


        private static readonly int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };

        private static int CountChange2(int money, int coinIdx)
        {
            if (money == 0)
                return 1;
            if (coinIdx == coins.Length || money < 0)
                return 0;
            return CountChange2(money - coins[coinIdx], coinIdx) + CountChange2(money, coinIdx+1);
        }

        // Slightly improved version of solution 1 where we don't pass in arrays or enumerables but
        // rather just an index.
        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int res = CountChange2(200, 0);
            timer.Stop();
            return res;
        }


        //////////////////////////////////////////////////////


        // Better solution, lifted also from StackOverflow: http://stackoverflow.com/a/19595523/82682
        [EulerSolution]
        public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
            int[] tbl = new int[201];
            tbl[0] = 1;
            foreach (var k in new[] {1, 2, 5, 10, 20, 50, 100, 200})
            {
                for (int j = k; j <= 200; j++)
                {
                    tbl[j] += tbl[j - k];
                }
            }
            int res = tbl[200];
            timer.Stop();
            return res;
        }
    }
}
