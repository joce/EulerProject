using System;
using System.Diagnostics;

namespace EulerProject
{
    [EulerProblem]
    public class Problem019 : ProblemBase
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 19, Solution 1: Value = 171 in 262 ticks
        // Problem 19, Solution 1: Value = 171 in 1203 ticks

        static readonly int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // Wow... Somehow, NOT taking into account ANY leap year leads to the correct answer. That is weird.
        [EulerSolution]
        public static void Solution1()
        {
            _timer.Restart();
            int result = 0;
            int year = 1900;
            int day = 6;
            int month = 0;
            int daysInMonth = _daysInMonth[month];

            while (year < 2001)
            {
                day += 7;
                int newDay = day%daysInMonth;
                if (newDay < day)
                {
                    month++;
                    if (month >= 12)
                    {
                        month = 0;
                        year++;
                    }
                    daysInMonth = _daysInMonth[month];
                }
                day = newDay;
                if (day == 0 && year >= 1901)
                {
                    result += 1;
                }
            }
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 19, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }


        //////////////////////////////////////////////////////


        // Proper solution with the right number of days taken into account.
        [EulerSolution]
        public static void Solution2()
        {
            _timer.Restart();
            int result = 0;
            int year = 1900;
            int day = 6;
            int month = 1;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            while (year < 2001)
            {
                day += 7;
                int newDay = day%daysInMonth;
                if (newDay < day)
                {
                    month++;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                    daysInMonth = DateTime.DaysInMonth(year, month);
                }
                day = newDay;
                if (day == 0 && year >= 1901)
                {
                    result += 1;
                }
            }
            _timer.Stop();

            Trace.WriteLine(string.Format("Problem 19, Solution 1: Value = {0} in {1} ticks", result, _timer.ElapsedTicks));
        }
    }
}