using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem006
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 6, Solution 1: Value = 25164150 in 17164 ticks
        // Problem 6, Solution 2: Value = 25164150 in 379 ticks
        // Problem 6, Solution 3: Value = 25164150 in 2 ticks
        // Problem 6, Solution 4: Value = 25164150 in 0 ticks

        static Stopwatch _timer = new Stopwatch();

        public static void Solution1()
        {
            _timer.Restart();
            int result = (int)Math.Pow(Enumerable.Range(1,100).Sum(),2) - Enumerable.Range(1,100).Select(i=> i*i).Sum();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 6, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution2()
        {
            _timer.Restart();
            const int n = 100;
            int sum = (((n * n) + n) / 2);
            int result = (sum*sum) - Enumerable.Range(1, 100).Select(i => i*i).Sum();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 6, Solution 2: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution3()
        {
            _timer.Restart();
            const int n = 100;
            int result = (((n * n) + n) / 2);
            result *= result;

            for (int i = 1; i <= 100; i++)
            {
                result -= (i*i);
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 6, Solution 3: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution4()
        {
            _timer.Restart();
            const int n = 100;
            int sum = (((n * n) + n) / 2);
            int result = sum * sum;

            // Found the sum of squares formula here: 
            // http://answers.yahoo.com/question/index?qid=20091130193118AA2BwrJ
            int sumOfSquares = (n * (n + 1) * (2 * n + 1) ) / 6;

            result -= sumOfSquares;

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 6, Solution 4: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
