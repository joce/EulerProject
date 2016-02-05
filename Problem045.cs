using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem045
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 1533776805 in 132269 ticks
        // Solution 2: Result = 1533776805 in 6922073 ticks
        // Solution 3: Result = 1533776805 in 42094 ticks

        [EulerSolution]
        public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            const uint max = 2000000000;
            byte[] sieve = new byte[max];

            // All hexas are also triangulars. So we skip all triangulars.

            uint val = 40755;
            uint n = 165;
            do
            {
                sieve[val]++;
                n++;
                val = (n*(3*n - 1)) / 2;
            } while (val < max);

            n = 143;
            do
            {
                n++;
                val = n*(2*n - 1);
            } while (val < max && sieve[val] != 1);

            if (val > max)
                val = 0;
            timer.Stop();
            return val;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static long Solution2(Stopwatch timer)
        {
            timer.Restart();
            const long max = 2000000000;

            // All hexas are also triangulars. So we skip all triangulars.

            List<long> pens = new List<long>();
            long val;
            long n = 285;
            do
            {
                n++;
                val = (n*(3*n - 1)) / 2;
                pens.Add(val);
            } while (val < max);

            n = 143;
            do
            {
                n++;
                val = n*(2*n - 1);
                if (pens.Contains(val))
                    break;
            } while (val < max);

            if (val > max)
                val = -1;
            timer.Stop();
            return val;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static long Solution3(Stopwatch timer)
        {
            timer.Restart();
            const long max = 2000000000;

            // All hexas are also triangulars. So we skip all triangulars.

            List<long> pens = new List<long>();
            long val;
            long n = 165;
            do
            {
                n++;
                val = (n*(3*n - 1)) / 2;
                pens.Add(val);
            } while (val < max);

            List<long> hexas = new List<long>();
            n = 143;
            do
            {
                n++;
                val = n*(2*n - 1);
                hexas.Add(val);
            } while (val < max);

            val = hexas.Intersect(pens).FirstOrDefault();

            timer.Stop();
            return val;
        }
    }
}
