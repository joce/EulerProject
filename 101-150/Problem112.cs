using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem112
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 1587000 in 129903 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            double bouncyCount = 0.0;
            int[] digits = new int[10];
            double ratio = 0.0;
            int i = 99;

            while (ratio != 0.99)
            {
                int n = ++i;
                int c = 0;
                int dir = 0;

                // Get the first digit in.
                digits[c++] = n%10;
                n /= 10;

                while (n != 0)
                {
                    digits[c] = n%10;
                    n /= 10;

                    if (dir == 1)
                    {
                        if (digits[c] < digits[c - 1])
                        {
                            bouncyCount++;
                            break;
                        }
                    }
                    else if (dir == -1)
                    {
                        if (digits[c] > digits[c - 1])
                        {
                            bouncyCount++;
                            break;
                        }
                    }
                    else
                    {
                        dir = digits[c].CompareTo(digits[c - 1]);
                    }
                    c++;
                }

                ratio = bouncyCount/i;
            }

            timer.Stop();
            return i;
        }
    }
}
