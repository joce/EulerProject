using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem018 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 18, Solution 1: Value = 1074 in 29912 ticks
        // Problem 18, Solution 1: Value = 1074 in 31 ticks

        static readonly int [][] triangle =
        {
            new[] {75,},
            new[] {95, 64,},
            new[] {17, 47, 82,},
            new[] {18, 35, 87, 10,},
            new[] {20, 04, 82, 47, 65,},
            new[] {19, 01, 23, 75, 03, 34,},
            new[] {88, 02, 77, 73, 07, 63, 67,},
            new[] {99, 65, 04, 28, 06, 16, 70, 92,},
            new[] {41, 41, 26, 56, 83, 40, 80, 70, 33,},
            new[] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29,},
            new[] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,},
            new[] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,},
            new[] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,},
            new[] {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,},
            new[] {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23,},
        };

        static int _max;

        static void SearchTriangle(int level, int position, Stack<int> items)
        {
            if (level < triangle.Length)
            {
                items.Push(triangle[level][position]);
                SearchTriangle(level+1, position, items);
                SearchTriangle(level+1, position+1, items);
                items.Pop();
            }
            else
            {
                if (items.Sum() > _max)
                {
                    _max = items.Sum();
                }
            }
        }

        // Brute force solution. It doesn't now but it can keep the list of items in the largest sum path.
        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();

            Stack<int> myItems = new Stack<int>();
            SearchTriangle(0,0,myItems);
            _timer.Stop();

            int result = _max;
            Trace.WriteLine(string.Format("Problem 18, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        // Fast solution. Can't keep track of the items that make the largest sum path.
        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();

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
            _timer.Stop();

            int result = temp[cur].Max();

            Trace.WriteLine(string.Format("Problem 18, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}
