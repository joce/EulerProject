﻿using System;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem016 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 16, Solution 1: Value = 1366 in 18684 ticks
        // Problem 16, Solution 2: Value = 1366 in 52 ticks
        // Problem 16, Solution 3: Value = 1366 in 29 ticks

        [EulerSolution]
        public static int Solution1()
        {
            _timer.Restart();
            int result = ((BigInteger)Math.Pow(2, 1000)).ToString().Select(c => c - '0').Sum();
            _timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2()
        {
            _timer.Restart();
            int result = 0;
            foreach (var c in ((BigInteger)Math.Pow(2, 1000)).ToString())
            {
                result += (c-'0');
            }
            _timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution3()
        {
            _timer.Restart();
            string val = ((BigInteger)Math.Pow(2, 1000)).ToString();
            int result = -(val.Length * '0');
            foreach (var c in val)
            {
                result += c;
            }
            _timer.Stop();
            return result;
        }
    }
}
