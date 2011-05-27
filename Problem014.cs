﻿using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem014
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 14, Solution 1: Value = 837799 in 2812572 ticks
        // Problem 14, Solution 2: Value = 837799 in 1672917 ticks
        // Problem 14, Solution 1: Value = 837799 in 432930 ticks

        static Stopwatch _timer = new Stopwatch();

        // Brute force, no caching.
        static long Find3nMinusOne(long n)
        {
            if (n == 1)
            {
                return 1;
            }

            return Find3nMinusOne(n%2 == 0 ? n/2 : 3*n + 1) + 1;
        }

        public static void Solution1()
        {
            _timer.Restart();
            long longest = 0;
            int result = 0;

            for (int i = 3; i < 1000000; i+=2)
            {
                long length = Find3nMinusOne(i);
                if (length > longest)
                {
                    longest = length;
                    result = i;
                }
            }
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 14, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////

        // The dictionary cache is memory efficient as the results are sparse. However, it's rather costly in CPU cycles.
        static short Find3nMinusOne2(Dictionary<long, short> cache, long n)
        {
            if (n == 1)
            {
                return 1;
            }
            
            short val = 0;
            if (!cache.ContainsKey(n))
            {
                val = (short)(Find3nMinusOne2(cache, n%2 == 0 ? n/2 : 3*n + 1) + 1);
                cache[n] = val;
            }
            else
            {
                val = cache[n];
            }

            return val;
        }

        public static void Solution2()
        {
            _timer.Restart();

            var cache = new Dictionary<long, short>();

            int longest = 0;
            int result = 0;

            for (int i = 3; i < 1000000; i+=2)
            {
                int length = Find3nMinusOne2(cache, i);
                if (length > longest)
                {
                    longest = length;
                    result = i;
                }
            }

            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 14, Solution 2: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        // The size of the biggest chunk I can allocate:
        const ulong _cacheSize = 0x3ffffeff;
        static short Find3nMinusOne3(short[] cache, ulong n)
        {
            // Results are only partially cached because the function has very high watermarks (in the 10s of billions) in some
            // cases and the gain we'd get doesn't match the algorithmic and memory cost.
            if ((n & ~_cacheSize) != 0)
            {
                return (short)(Find3nMinusOne3(cache, n%2 == 0 ? n/2 : 3*n + 1) + 1);
            }

            if (cache[n] == 0)
            {
                cache[n] = (short)(Find3nMinusOne3(cache, n%2 == 0 ? n/2 : 3*n + 1) + 1);
            }

            return cache[n];
        }

        public static void Solution3()
        {
            _timer.Restart();

            var cache = new short[_cacheSize];

            cache[1] = 1;

            ulong result = 0;
            short maxdepth = 0;

            for (ulong i = 3; i < 1000000; i+=2)
            {
                short depth = Find3nMinusOne3(cache, i);
                if (depth > maxdepth)
                {
                    maxdepth = depth;
                    result = i;
                }
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 14, Solution 3: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
