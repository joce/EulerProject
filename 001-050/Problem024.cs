using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem024
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 24, Solution 1: Value = 2783915460 in 473 ticks

        static int Factorial(int value)
        {
            int result = value --;
            while (value > 1)
            {
                result *= value --;
            }
            return result;
        }

        // I believe this is fast enough. I also can't think of a way to optimize this further at the moment.
        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            var originalList = new List<int>{0,1,2,3,4,5,6,7,8,9};
            var resultList = new List<int>();

            int place = 9;
            int value = 999999;

            while (place > 0)
            {
                int factorial = Factorial(place);
                int idx = value/factorial;
                resultList.Add(originalList[idx]);
                originalList.RemoveAt(idx);
                value -= idx*factorial;
                place--;
            }
            resultList.Add(originalList[0]);
            long result = Int64.Parse(resultList.ConvertAll(i => i.ToString()).Aggregate(string.Concat));
            timer.Stop();

            return result;
        }
    }
}
