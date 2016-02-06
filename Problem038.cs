using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EulerProject
{
    [EulerProblem]
    public class Problem038
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 932718654 in 552899 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            int res = -1;
            const string pendigital = "123456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 1000000; i++)
            {
                sb.Clear();
                int n = 1;
                while (sb.Length < 9)
                {
                    sb.Append(i*n);
                    n++;
                }
                if (sb.Length > 9)
                    continue;
                string resStr = sb.ToString();
                string s = new string(resStr.OrderBy(c => c).ToArray());
                if (s == pendigital)
                {
                    int v = int.Parse(resStr);
                    if (v > res)
                        res = v;
                }
            }
            timer.Stop();
            return res;
        }
    }
}
