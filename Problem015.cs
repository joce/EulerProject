using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem015
    {
        // The results I got are of the following order of magnitude:
        // 
        static Stopwatch _timer = new Stopwatch();

        public static void Solution1()
        {
            _timer.Restart();
            int result = 0;
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 15, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }

    }
}
