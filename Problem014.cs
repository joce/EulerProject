using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem014
    {
        static Stopwatch _timer = new Stopwatch();

        static int idx;
        static int maxdepth;

        static short Find3nMinusOne(short[][] cache, int n)
        {
            int mainIdx = 0;
            if (n > 1000000000)
            {
                mainIdx = 1;
                n -= 1000000000;
            }

            if (cache[mainIdx][n] == 0)
            {
                cache[mainIdx][n] = (short)(Find3nMinusOne(cache, n%2 == 0 ? n/2 : 3*n + 1) + 1);
            }

            if (cache[mainIdx][n] > maxdepth)
            {
                maxdepth = cache[mainIdx][n];
                idx = mainIdx*1000000000 + n;
            }

            return cache[mainIdx][n];
        }

        public static void Solution1()
        {
            _timer.Restart();

            short[][] cache = new short[2][];

            cache[0] = new short[1000000000];
            cache[1] = new short[1000000000];
            
            cache[0][1] = 1;

            idx = 0;
            maxdepth = 0;

            for (int i = 2; i < 1000000; i++)
            {
                Find3nMinusOne(cache, i);
            }

            int result = idx;
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 14, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
            
        }
    }
}
