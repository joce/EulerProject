using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem055
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 249 in 259572 ticks

        static bool IsPalindrome(BigInteger value)
        {
            string strVal = value.ToString();
            int halfLenght = strVal.Length / 2;
            for (int i = 0; i < halfLenght; i++)
            {
                if (strVal[i] != strVal[strVal.Length -1 -i])
                {
                    return false;
                }
            }
            return true;
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int cnt = 0;
            for (int i = 1; i < 10000; i++)
            {
                BigInteger nb = i;
                int n = 0;
                for (; n < 50; n++)
                {
                    nb += BigInteger.Parse(new string(nb.ToString().Reverse().ToArray()));
                    if (IsPalindrome(nb))
                    {
                        break;
                    }
                }
                if (n == 50)
                {
                    cnt++;
                }
            }

            timer.Stop();
            return cnt;
        }
    }
}
