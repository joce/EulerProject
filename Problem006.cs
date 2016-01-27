using System;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem006
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 6, Solution 1: Value = 25164150 in 17164 ticks
        // Problem 6, Solution 2: Value = 25164150 in 379 ticks
        // Problem 6, Solution 3: Value = 25164150 in 2 ticks
        // Problem 6, Solution 4: Value = 25164150 in 0 ticks

        [EulerSolution]
		public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int result = (int)Math.Pow(Enumerable.Range(1,100).Sum(),2) - Enumerable.Range(1,100).Select(i=> i*i).Sum();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            const int n = 100;
            int sum = (((n * n) + n) / 2);
            int result = (sum*sum) - Enumerable.Range(1, 100).Select(i => i*i).Sum();
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
            const int n = 100;
            int result = (((n * n) + n) / 2);
            result *= result;

            for (int i = 1; i <= 100; i++)
            {
                result -= (i*i);
            }

            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static int Solution4(Stopwatch timer)
        {
            timer.Restart();
            const int n = 100;
            int sum = (((n * n) + n) / 2);
            int result = sum * sum;

            // Found the sum of squares formula here:
            // http://answers.yahoo.com/question/index?qid=20091130193118AA2BwrJ
            int sumOfSquares = (n * (n + 1) * (2 * n + 1) ) / 6;

            result -= sumOfSquares;

            timer.Stop();
            return result;
        }
    }
}
