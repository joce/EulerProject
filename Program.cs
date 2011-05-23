﻿namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int problem = 8;
            switch (problem)
            {
                case 1: {
                    Problem001.Solution1();
                    Problem001.Solution2();
                    Problem001.Solution3();
                    Problem001.Solution4();
                } break;

                case 2: {
                    Problem002.Solution1();
                    Problem002.Solution2();
                    Problem002.Solution3();
                    Problem002.Solution4();
                    Problem002.Solution5();
                } break;

                case 3:
                {
                    Problem003.Solution1();
                    Problem003.Solution2();
                    Problem003.Solution3();
                    Problem003.Solution4();
                } break;

                case 4:
                {
                    Problem004.Solution1();
                    Problem004.Solution2();
                    Problem004.Solution3();
                } break;

                case 5:
                {
                    // Solution 1 and 2 are terribly lengthy are have been disabled.
                    //Problem5.Solution1();
                    //Problem5.Solution2();
                    Problem005.Solution3();
                    Problem005.Solution4();
                } break;

                case 6:
                {
                    Problem006.Solution1();
                    Problem006.Solution2();
                    Problem006.Solution3();
                    Problem006.Solution4();
                } break;

                case 7:
                {
                    Problem007.Solution1();
                    Problem007.Solution2();
                } break;

                case 8:
                {
                    Problem008.Solution1();
                } break;

                default: break;
            }
        }
    }
}
