using System.Diagnostics;
namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int problem = 4;
            switch (problem)
            {
                case 1: {
                    Problem1.Solution1();
                    Problem1.Solution2();
                    Problem1.Solution3();
                    Problem1.Solution4();
                } break;

                case 2: {
                    Problem2.Solution1();
                    Problem2.Solution2();
                    Problem2.Solution3();
                    Problem2.Solution4();
                    Problem2.Solution5();
                } break;

                case 3:
                {
                    Problem3.Solution1();
                    Problem3.Solution2();
                    Problem3.Solution3();
                    Problem3.Solution4();
                } break;

                case 4:
                {
                    Problem4.Solution1();
                    Problem4.Solution2();
                    Problem4.Solution3();
                } break;

                default: break;
            }
        }
    }
}
