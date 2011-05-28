using System.Diagnostics;

namespace EulerProject
{
    public static class Problem048
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 48, Solution 1: Value = 9110846700 in 42739 ticks

        static Stopwatch _timer = new Stopwatch();

        const long _maxVal = 10000000000;

        static ulong PartialSelfExp(ulong nb)
        {
            ulong result = nb;
            for (ulong i = 1; i < nb; i++)
            {
                result = (result * nb) % _maxVal;
            }

            return result;
        }

        public static void Solution1()
        {
            _timer.Restart();
            ulong result = 0;
            for (ulong i = 1; i <= 1000; i++)
            {
                result = (result + PartialSelfExp(i));
            }
            result = result % _maxVal;
            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 48, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
