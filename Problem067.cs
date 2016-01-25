using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem067 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 67, Solution 1: Value = 7273 in 8025 ticks

        // Fast solution, same as Problem 18's fast solution. Not sure how it can be sped up at the moment.
        [EulerSolution]
        public static int Solution1()
        {
            _timer.Restart();
            var triangle = File.ReadAllLines("Problem067.data").Select(line => line.Split(' ').Select(item => int.Parse(item)).ToArray()).ToArray();

            int[][] temp = new int[2][];
            temp[0] = new int[triangle[triangle.Length-1].Length];
            temp[1] = new int[triangle[triangle.Length-1].Length];

            int cur = 0;
            int next = 1;

            temp[cur][0] = triangle[0][0];
            for (int i = 1; i < triangle.Length; i++)
            {
                for (int j = 0; j < triangle[i-1].Length; j++)
                {
                    int v1 = temp[cur][j] + triangle[i][j];
                    int v2 = temp[cur][j] + triangle[i][j+1];

                    if (temp[next][j] < v1)
                    {
                        temp[next][j] = v1;
                    }

                    if (temp[next][j+1] < v2)
                    {
                        temp[next][j+1] = v2;
                    }
                }

                temp[cur].Initialize();

                cur ^= 1;
                next ^= 1;
            }

            int result = temp[cur].Max();
            _timer.Stop();

            return result;
        }
    }
}
