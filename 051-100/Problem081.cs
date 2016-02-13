using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem081
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 427337 in 8530 ticks

        private static int[][] matrix;
        private static int[][] resMat;
        private const int sizeX = 80;
        private const int sizeY = 80;

        public static int MinPath(int x, int y)
        {
            if (resMat[x][y] != -1)
            {
                return resMat[x][y];
            }
            int newX = x < sizeX - 1 ? x + 1 : x;
            int newY = y < sizeY - 1 ? y + 1 : y;
            int newVal = 0;
            if (newX != x && newY != y)
            {
                newVal = Math.Min(MinPath(newX, y), MinPath(x, newY));
            }
            else if (newX != x)
            {
                newVal = MinPath(newX, y);
            }
            else if (newY != y)
            {
                newVal = MinPath(x, newY);
            }

            resMat[x][y] = matrix[x][y] + newVal;
            return resMat[x][y];
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            matrix = new int[sizeX][];
            resMat = new int[sizeX][];

            int i = 0;
            foreach (var line in File.ReadAllLines("Problem081.data"))
            {
                matrix[i] = line.Split(',').Select(int.Parse).ToArray();
                resMat[i] = Enumerable.Repeat(-1, sizeY).ToArray();
                i++;
            }

            int res = MinPath(0, 0);
            timer.Stop();
            return res;
        }
    }
}
