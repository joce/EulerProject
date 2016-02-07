using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EulerProject
{
    [EulerProblem]
    public class Problem037
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 748317 in 72234 ticks
        // Solution 2: Result = 748317 in 47290 ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 1000000;
            byte[] primes = new byte[max]; // a prime is represented by a 0.
            primes.Initialize();

            primes[0] = 1;
            primes[1] = 1;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 2; i < sqrt; i++)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            List<int> l = new List<int>();

            for (int i = 11; i < 1000000; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    string p = i.ToString();

                    bool allPrimes = true;
                    for (int j = 1; j < p.Length; j++)
                    {
                        string s = p.Substring(0, p.Length-j); // Trim right
                        if (primes[int.Parse(s)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }

                        string s1 = p.Substring(j, p.Length-j); // Trim left
                        if (primes[int.Parse(s1)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }
                    }

                    if (allPrimes)
                    {
                        l.Add(i);
                    }
                }
            }

            int res = l.Sum();
            timer.Stop();

            return res;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();

            // Compute primes.
            const int max = 799999; // We assume all number will be found below 1M, and we know all the 800k and 900k will fail the test.
            byte[] primes = new byte[max]; // a prime is represented by a 0.
            primes.Initialize();

            primes[0] = 1;
            primes[1] = 1;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(max));
            for (int i = 2; i < sqrt; i++)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2*i; j < max; j+=i)
                    {
                        primes[j] = 1;
                    }
                }
            }

            List<int> l = new List<int>();

            for (int i = 21; i < max; i+=2)
            {
                if (primes[i] == 0) // 0 => prime.
                {
                    string p = i.ToString();
                    string firstNum = p[0].ToString();
                    if (primes[int.Parse(firstNum)] == 1) // == 1 means not a prime
                    {
                        // We'll skip the whole group that starts with a non prime because none can match the requirement.
                        // e.g. skip the 100's, 400's, 8000's, 90000's etc.
                        var sb = new StringBuilder((int.Parse(firstNum)+1).ToString());
                        for (int j = 0; j < p.Length - 2; j++)
                        {
                            sb.Append("0");
                        }
                        sb.Append("1"); // make sure we get to an odd number
                        i = int.Parse(sb.ToString());
                        continue;
                    }

                    bool allPrimes = true;
                    for (int j = 1; j < p.Length; j++)
                    {
                        string s = p.Substring(0, p.Length-j); // Trim right
                        if (primes[int.Parse(s)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }

                        s = p.Substring(j, p.Length-j); // Trim left
                        if (primes[int.Parse(s)] == 1)
                        {
                            allPrimes = false;
                            break;
                        }
                    }

                    if (allPrimes)
                    {
                        l.Add(i);
                    }
                }
            }

            int res = l.Sum();
            timer.Stop();

            return res;
        }

    }
}
