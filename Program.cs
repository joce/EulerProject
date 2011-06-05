﻿namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int problem = 22;
            switch (problem)
            {
                case 1: {
                    Problem001.Solution1();
                    Problem001.Solution2();
                    Problem001.Solution3();
                    Problem001.Solution4();
                    Problem001.Solution5();
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
                    Problem008.Solution2();
                } break;

                case 9:
                {
                    Problem009.Solution1();
                    Problem009.Solution2();
                } break;

                case 10:
                {
                    Problem010.Solution1();
                    Problem010.Solution2();
                    Problem010.Solution3();
                } break;

                case 11:
                {
                    Problem011.Solution1();
                    Problem011.Solution2();
                } break;

                case 12:
                {
                    Problem012.Solution1();
                } break;

                case 13:
                {
                    Problem013.Solution1();
                    Problem013.Solution2();
                } break;

                case 14:
                {
                    Problem014.Solution1();
                    Problem014.Solution2();
                    Problem014.Solution3();
                } break;

                case 15:
                {
                    Problem015.Solution1();
                    Problem015.Solution2();
                    Problem015.Solution3();
                } break;

                case 16:
                {
                    Problem016.Solution1();
                    Problem016.Solution2();
                    Problem016.Solution3();
                } break;

                case 20:
                {
                    Problem020.Solution1();
                    Problem020.Solution2();
                } break;

                case 22:
                {
                    Problem022.Solution1();
                    Problem022.Solution2();
                } break;

                case 25:
                {
                    Problem025.Solution1();
                    Problem025.Solution2();
                } break;

                case 36:
                {
                    Problem036.Solution1();
                    Problem036.Solution2();
                    Problem036.Solution3();
                } break;

                case 48:
                {
                    Problem048.Solution1();
                } break;

                default: break;
            }
        }
    }
}
