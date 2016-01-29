using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem023
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 23, Solution 1: Result = 4179871 in 4153483 ticks

        private static IEnumerable<int> GetDividers(int input)
        {
            yield return 1; // Everything is divisible by 1
            for (int i = 2; i <= input/2; ++i)
            {
                if (input%i == 0)
                {
                    yield return i;
                }
            }
        }

        private static bool IsAbundant(int input)
        {
            return GetDividers(input).Sum() > input;
        }

        private static IEnumerable<int> AbundantsTo(int input)
        {
            // I think this could be sped up because while I don't have the formal proof, I believe that
            // multiples of an abundant numbers are themselves abundant.
            for (int i = 12; i <= input; ++i)
            {
                if (IsAbundant(i))
                {
                    yield return i;
                }
            }
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int total = 0;

            int[] abundant = AbundantsTo(28123).ToArray();
            int[] sums = new int[28124];

            foreach (int sum in abundant.SelectMany(ab1 => abundant.Select(ab2 => ab1+ab2).TakeWhile(sum => sum <= 28123)))
            {
                sums[sum] = 1;
            }

            total = sums.Select((v, i) => v == 0 ? i : 0).Sum();

            timer.Stop();
            return total;
        }
    }
}
