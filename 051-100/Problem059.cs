using System.Diagnostics;
using System.IO;
using System.Linq;
//using System.Text;

namespace EulerProject
{
    [EulerProblem]
    public class Problem059
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = xxx in xxx ticks

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            var encryptedChars = File.ReadAllText("Problem059.data").Split(',').Select(s => int.Parse(s)).ToArray();

            char[] key = new char[3];
            for (int i = 0; i < 3; i++)
            {
                int maxChars = -1;
                char bestKey = '\0';
                for (char c = 'a'; c <= 'z'; c++)
                {
                    int charCnt = 0;
                    for (int n = i; n < encryptedChars.Length; n+=3)
                    {
                        char decryptedChar = (char)(encryptedChars[n] ^ c);
                        if (decryptedChar >= 'a' && decryptedChar <= 'z')
                        {
                            charCnt++;
                        }
                    }
                    if (charCnt > maxChars)
                    {
                        maxChars = charCnt;
                        bestKey = c;
                    }
                }
                key[i] = bestKey;
            }

            // The following prints the string. Left out
//             StringBuilder sbr = new StringBuilder();
//
//             for (int i = 0; i < encryptedChars.Length; i++)
//             {
//                 sbr.Append((char) (encryptedChars[i] ^ key[i%3]));
//             }
//
//             Trace.WriteLine(sbr.ToString());

            int res = 0;
            for (int i = 0; i < encryptedChars.Length; i++)
            {
                res += (encryptedChars[i] ^ key[i%3]);
            }
            timer.Stop();
            return res;
        }
    }
}
