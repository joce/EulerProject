using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LinqStatistics;

namespace EulerProject
{
    class Program
    {
        static long[] RunSolution(MethodInfo m, int times)
        {
	        Stopwatch timer = new Stopwatch();
            long[] ticks = new long[times];
			object[] arguments = { timer };
            for (int i = 0; i < times; i++)
            {
				m.Invoke(null, arguments);
                ticks[i] = timer.ElapsedTicks;
            }
            return ticks;
        }

        static void Main(string[] args)
        {
            bool runAllProblems = ConfigurationManager.AppSettings["problems"].ToLower() == "all";
            IEnumerable<string> problems = ConfigurationManager.AppSettings["problems"]
                                                               .Split(',')
                                                               .Select(s => s.TrimStart('0',' '));

            foreach (var t in Assembly.GetExecutingAssembly().GetTypes()
                                                             .Where(t => t.IsPublic &&
                                                                         t.GetCustomAttributes(typeof(EulerProblemAttribute), false).Any() &&
                                                                         t.Name.StartsWith("Problem") &&
                                                                         (runAllProblems || problems.Contains(t.Name.Substring("Problem".Length).TrimStart('0'))))
                                                             .OrderBy(t => t.Name))
            {
                Trace.WriteLine("\n===================");
                Trace.WriteLine(string.Format("Problem {0}", t.Name.Substring("Problem".Length).TrimStart('0')));
                foreach (var m in t.GetMethods()
                                   .Where(m => m.IsStatic &&
                                               m.IsPublic &&
                                               m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).Any())
                                   .OrderBy(m => m.Name))
                {
                    var attrib = ((EulerSolutionAttribute)m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).First());
                    if (attrib.IsEnabled)
                    {
						// Get the result. Pass in a dummy timer.
						var res = m.Invoke(null, new object[] { new Stopwatch() });

						// Get the timings.
						long[] ticks = RunSolution(m, 10);
                        Range<long> tickExtremes = ticks.MinMax();
                        Trace.WriteLine(string.Format("\tSolution {0}: Result = {1} (low: {2}, high: {3}, avg: {4:F3}, med: {5:F1}, stdev: {6:F3})",
                                                       m.Name.Substring("Solution".Length),
                                                       res,
                                                       tickExtremes.Min, tickExtremes.Max,
                                                       ticks.Average(), ticks.Median(), ticks.StandardDeviation()));
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("\tSolution {0}: Disabled ({1})",
                                                       m.Name.Substring("Solution".Length),
                                                       attrib.Reason));
                    }
                }
            }

            Trace.WriteLine("\n===================\n");
        }
    }
}
