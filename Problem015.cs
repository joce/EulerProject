using System.Diagnostics;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem015
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 15, Solution 1: Value = 137846528820 in 39 ticks
        // Problem 15, Solution 2: Value = 137846528820 in 126 ticks
        // Problem 15, Solution 2: Value = 137846528820 in 1 ticks

        [EulerSolution]
		public static long Solution1(Stopwatch timer)
        {
            timer.Restart();
            int size = 20;
            long[][] values = new long[2][];
            for (int i = 0; i < 2; i++)
            {
                values[i] = new long[size+1];
                for (int j = 0; j <= size; j++)
                {
                    values[i][j] = 1;
                }
            }

            int cur = 1;
            int prev = 0;

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    values[cur][j] = values[cur][j - 1] + values[prev][j];
                }
                cur ^= 1;
                prev ^= 1;
            }

            long result = values[prev][size];
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static BigInteger Solution2(Stopwatch timer)
        {
            timer.Restart();
            int size = 20;
            BigInteger result = 1;
            BigInteger divider = 1;

            for (int i = 1; i <= size; i++)
            {
                result *= (i+size);
                divider *= i;
            }
            result /= divider;
            timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
		public static long Solution3(Stopwatch timer)
        {
            timer.Restart();
            // 40! / ((20!)(20!)) simplified.
            long result = 23L * 29L * 31L * 33L * 35L * 37L * 39L * 4;
            timer.Stop();
            return result;
        }
    }
}
