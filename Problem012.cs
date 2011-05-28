﻿using System;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem012
    {
        static Stopwatch _timer = new Stopwatch();

        static int HalfDivisorCount(long val)
        {
            int res = 1;
            int sqrt = (int)Math.Sqrt(val);
            for (int i = 2; i < sqrt; i++)
            {
                if (val % i == 0)
                {
                    res++;
                }
            }
            return res;
        }

        // Brute force solution.
        public static void Solution1()
        {
            _timer.Restart();
            long result = 0;

            long val = 0;
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                val += i;
                if (HalfDivisorCount(val) >= 250)
                {
                    result = val;
                    break;
                }
            }

            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 12, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}