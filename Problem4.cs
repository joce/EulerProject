using System.Linq;
using System.Diagnostics;

namespace EulerProject
{
    public static class Problem4
    {
        // The results I got are of the following order of magnitude:
        // 
        // Problem 4, Solution 1: Value = 906609 in 137573 ticks
        // Problem 4, Solution 2: Value = 906609 in 30935 ticks
        // Problem 4, Solution 3: Value = 906609 in 8378 ticks
        
        static Stopwatch _timer = new Stopwatch();

        static bool IsPalindrome(int value)
        {
            string strVal = value.ToString();
            return strVal.StartsWith(new string(strVal.Substring(strVal.Length/2).Reverse().ToArray()));
        }

        public static void Solution1()
        {
            _timer.Restart();

            int value = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = i; j < 1000; j++)
                {
                    int mult = i * j;
                    if (mult > value && IsPalindrome(mult))
                    {
                        value = mult;
                    }
                }
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 4, Solution 1: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        static bool IsPalindrome2(int value)
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

        public static void Solution2()
        {
            _timer.Restart();

            int value = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = i; j < 1000; j++)
                {
                    int mult = i * j;
                    if (mult > value && IsPalindrome2(mult))
                    {
                        value = mult;
                    }
                }
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 4, Solution 2: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        public static void Solution3()
        {
            _timer.Restart();

            int value = 0;
            for (int i = 999; i >= 100; i--)
            {
                for (int j = i; j >= 100; j--)
                {
                    int mult = i * j;
                    if (mult > value && IsPalindrome2(mult))
                    {
                        value = mult;
                    }
                }
            }

            _timer.Stop();
            Trace.WriteLine(string.Format("Problem 4, Solution 3: Value = {0} in {1} ticks", value, _timer.ElapsedTicks));
        }
    }
}
