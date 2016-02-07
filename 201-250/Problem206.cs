using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem206
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 1389019170 in 33287345 ticks

        [EulerSolution]
        public static ulong Solution1(Stopwatch timer)
        {
            timer.Restart();
            ulong i =   (ulong)Math.Sqrt(1020304050607080900);
            ulong max = (ulong)Math.Sqrt(1929394959697989990);
            for (; i < max; i+=10)
            {
                var s = (i*i).ToString();
                if (s[0] == '1' && s[2] == '2' && s[4] == '3' && s[6] == '4' && s[8] == '5' &&
                    s[10] == '6' && s[12] == '7' && s[14] == '8' && s[16] == '9' && s[18] == '0')
                    break;
            }
            timer.Stop();

            return i;
        }
    }
}
