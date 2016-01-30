using System;
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
        // Problem 23, Solution 1: Result = 4179871 in 4246624 ticks
        // Problem 23, Solution 2: Result = 4179871 in 2711091 ticks
        // Problem 23, Solution 3: Result = 4179871 in 6501380 ticks
        // Problem 23, Solution 4: Result = 4179871 in 2580855 ticks
        // Problem 23, Solution 5: Result = 4179871 in 147792 ticks

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

            int[] abundant = AbundantsTo(28123).ToArray();
            int[] sums = new int[28124];

            foreach (int sum in abundant.SelectMany(ab1 => abundant.Select(ab2 => ab1+ab2).TakeWhile(sum => sum <= 28123)))
            {
                sums[sum] = 1;
            }

            int total = sums.Select((v, i) => v == 0 ? i : 0).Sum();

            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int total = 0;

            int[] abundant = AbundantsTo(28123).ToArray();
            int[] sums = new int[28123];

            foreach (var ab1 in abundant)
            {
                foreach (var ab2 in abundant)
                {
                    if (ab1 + ab2 >= 28123)
                    {
                        break;
                    }
                    sums[ab1 + ab2] = 1;
                }
            }

            for (int i = 0; i < 28123; i++)
            {
                if (sums[i] == 0)
                {
                    total += i;
                }
            }

            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        private static int[] AbundantsIndexes(int input)
        {
            int[] abundants = new int[input];
            // I think this could be sped up because while I don't have the formal proof, I believe that
            // multiples of an abundant numbers are themselves abundant.
            for (int i = 12; i < input; ++i)
            {
                if (abundants[i] == 0 && IsAbundant(i))
                {
                    for (int j = i; j < input; j += i)
                    {
                        abundants[i] = 1;
                    }
                }
            }

            return abundants;
        }

        [EulerSolution]
        public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
            int total = 0;

            int[] abundant = AbundantsIndexes(28123);
            int[] sums = new int[28123];

            for (int i = 0; i < 28123; i++)
            {
                for (int j = 0; j < 28123; j++)
                {
                    if (i + j >= 28123)
                    {
                        break;
                    }
                    if (abundant[i] != 0 && abundant[j] != 0)
                    {
                        sums[i + j] = 1;
                    }
                }
            }

            for (int i = 0; i < 28123; i++)
            {
                if (sums[i] == 0)
                {
                    total += i;
                }
            }

            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        private static bool IsAbundant2(int input)
        {
            int total = 0;
            foreach (var divider in GetDividers(input))
            {
                total += divider;
            }
            return total > input;
        }

        private static IEnumerable<int> AbundantsTo2(int input)
        {
            for (int i = 12; i <= input; ++i)
            {
                if (IsAbundant2(i))
                {
                    yield return i;
                }
            }
        }

        [EulerSolution]
        public static int Solution4(Stopwatch timer)
        {
            timer.Restart();
            int total = 0;

            var abundant = AbundantsTo2(28123).ToArray();
            int[] sums = new int[28123];

            for (int i = 0; abundant[i] < 28123/2; i++)
            {
                for (int j = i; j < abundant.Length; j++)
                {
                    int ab = abundant[i] + abundant[j];
                    if (ab >= 28123)
                    {
                        break;
                    }
                    sums[ab] = 1;
                }
            }

            for (int i = 0; i < 28123; i++)
            {
                if (sums[i] == 0)
                {
                    total += i;
                }
            }

            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        // Solution heavily inspired from thomad16 on
        // the Euler Project's forum (https://projecteuler.net/thread=23;page=9)
        [EulerSolution]
        public static int Solution5(Stopwatch timer)
        {
            timer.Restart();

            var abundant = new bool[28123];
            for (int i = 12; i < 28123; i++)
            {
                if (abundant[i])
                    continue;

                int facts = 1;
                int sqrt = (int)Math.Sqrt(i);
                if (sqrt*sqrt == i)
                    facts += sqrt;
                else
                    sqrt += 1;

                for (int j = 2; j < sqrt; j++)
                {
                    if (i%j == 0)
                    {
                        facts += j;
                        facts += (i/j);
                    }
                }

                if (facts > i)
                {
                    for (int j = i; j < 28123; j+=i)
                    {
                        abundant[j] = true;
                    }
                }
            }

            int total = 276; // 1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20+21+22+23;
            for (int i = 24; i < 28111 /*28123-12*/; i++)
            {
                int half = i/2;
                int add = i;
                for (int j = 12; j <= half; j++)
                {
                    if (abundant[j] && abundant[i - j])
                    {
                        add = 0;
                        break;
                    }
                }
                total += add;
            }

            timer.Stop();
            return total;
        }
    }
}
