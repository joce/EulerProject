using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {

            int problem = 3;
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
                } break;

                case 3:
                {
                    Problem3.Solution1();
                    Problem3.Solution2();
                    Problem3.Solution3();
                    Problem3.Solution4();
                } break;

                default: break;
            }
        }
    }
}
