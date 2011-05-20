using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    public static class Problem1
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 1, Solution 1: Total = 233168 in 370 ticks
        // Problem 1, Solution 2: Total = 233168 in 10205 ticks
        // Problem 1, Solution 3: Total = 233168 in 18398 ticks
        // Problem 1, Solution 4: Total = 233168 in 5 ticks

        static Stopwatch _timer = new Stopwatch();

        public static void Solution1()
        {
            int total = 0;

            _timer.Restart();
            foreach (int i in Enumerable.Range(1,999))
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    total += i;
                }
            }
            _timer.Stop();
            Trace.WriteLine(string.Format( "Problem 1, Solution 1: Total = {0} in {1} ticks", total, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution2()
        {
            _timer.Restart();
            int total = Enumerable.Range(1, 999).Where(i => i%3 == 0 || i%5 == 0).Sum();
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 1, Solution 2: Total = {0} in {1} ticks", total, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution3()
        {
            _timer.Restart();
            var porcessedVals = new HashSet<int>();
            int total = 0;
            for (int i = 3; i < 1000; i+= 3)
            {
                total += i;
                porcessedVals.Add(i);
            }

            for (int i = 5; i < 1000; i+= 5)
            {
                if (!porcessedVals.Contains(i))
                {
                    total += i;
                }
            }
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 1, Solution 3: Total = {0} in {1} ticks", total, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution4()
        {
            _timer.Restart();
            int total = 0;
            for (int i = 3; i < 1000; i+= 3)
            {
                total += i;
            }

            for (int i = 5; i < 1000; i+= 5)
            {
                if (i % 3 != 0)
                {
                    total += i;
                }
            }
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 1, Solution 4: Total = {0} in {1} ticks", total, _timer.ElapsedTicks));
        }
    }
}
