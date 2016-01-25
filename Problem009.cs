namespace EulerProject
{
    [EulerProblem]
    public class Problem009 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 9, Solution 1: Value = 31875000 in 2618 ticks
        // Problem 9, Solution 2: Value = 31875000 in 6 ticks

        [EulerSolution]
        public static int Solution1()
        {
            _timer.Restart();
            int result = 0;

            for (int a = 1; a < 333; a++)
            {
                for (int b = a+1; b < 500; b++)
                {
                    int c = 1000 - (a + b);
                    if ((a*a) + (b*b) == (c*c))
                    {
                        result = a * b * c;
                    }
                }
            }

            _timer.Stop();
            return result;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution2()
        {
            // a^2 * b^2 = c^2
            // c = 1000 - (a + b)
            // b = (500000 - 1000a) / (1000 - a)

            _timer.Restart();
            int a;
            int b = 2;

            for (a = 1 ; a < 333 ; a++)
            {
                int num = 500000 - (1000 * a);
                int denom = 1000 - a;
                if (num % denom == 0)
                {
                    b = num / denom ;
                    break;
                }
            }

            int result = a * b * (1000 - (a+b));
            _timer.Stop();
            return result;
        }
    }
}
