using System.Collections.Generic;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem001 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 1, Solution 1: Total = 233168 in 370 ticks
        // Problem 1, Solution 2: Total = 233168 in 10205 ticks
        // Problem 1, Solution 3: Total = 233168 in 18398 ticks
        // Problem 1, Solution 4: Total = 233168 in 5 ticks
        // Problem 1, Solution 4: Total = 233168 in 1 ticks

        [EulerSolution]
        public static int Solution1()
        {
            _timer.Restart();
			int total = 0;
			foreach (int i in Enumerable.Range(1, 999))
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    total += i;
                }
            }
            _timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2()
        {
            _timer.Restart();
            int total = Enumerable.Range(1, 999).Where(i => i%3 == 0 || i%5 == 0).Sum();
            _timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution3()
        {
            _timer.Restart();
            var porcessedVals = new HashSet<int>();
            int total = 0;
            for (int i = 3; i < 1000; i+= 3)
            {
                total += i;
                porcessedVals.Add(i);
            }

            for (int i = 5; i < 1000; i+= 5)
            {
                if (!porcessedVals.Contains(i))
                {
                    total += i;
                }
            }
            _timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution4()
        {
            _timer.Restart();
            int total = 0;
            for (int i = 3; i < 1000; i+= 3)
            {
                total += i;
            }

            for (int i = 5; i < 1000; i+= 5)
            {
                if (i % 3 != 0)
                {
                    total += i;
                }
            }
            _timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution5()
        {
            _timer.Restart();

            const int upperLimit = 1000;

            const int nbThrees = upperLimit / 3;
            const int nbFives = upperLimit / 5;
            const int nbFifteens = upperLimit / 15;

            const int sumOfThrees = 3 * ((nbThrees * (nbThrees + 1))/2);
            const int sumOfFives = 5 * ((nbFives * (nbFives + 1))/2);
            const int sumOfFifteens = 15 * ((nbFifteens * (nbFifteens + 1))/2);

            const int total = (sumOfThrees + sumOfFives) - sumOfFifteens;

            _timer.Stop();
            return total;
        }
    }
}
