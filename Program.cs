using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LinqStatistics;

namespace EulerProject
{
    class Program
    {
        private static long getTiming(Stopwatch sw)
        {
            return showMs ? sw.ElapsedMilliseconds : sw.ElapsedTicks;
        }

        private static string getTimingUnits()
        {
            return showMs ? "ms" : "ticks";
        }

        private static long[] RunSolutionParallel(MethodInfo m, int times)
        {
            var localTimer = new Stopwatch();
            var timings = new long[times];
            localTimer.Restart();
            {
                Parallel.ForEach(Enumerable.Range(0, times),
                    i =>
                    {
                        var timer = new Stopwatch();
                        object[] arguments = { timer };
                        m.Invoke(null, arguments);
                        timings[i] = getTiming(timer);
                    }
                );
            }
            localTimer.Stop();
            Trace.WriteLine(string.Format("******* PARALLEL RUN TIME: {0} {1}", getTiming(localTimer), getTimingUnits().ToUpper()));
            return timings;
        }

        private static long[] RunSolution(MethodInfo m, int times)
        {
            var localTimer = new Stopwatch();
            var timings = new long[times];
            localTimer.Restart();
            {
                var timer = new Stopwatch();
                object[] arguments = { timer };
                for (int i = 0; i < times; i++)
                {
                    m.Invoke(null, arguments);
                    timings[i] = getTiming(timer);
                }
            }
            localTimer.Stop();
            Trace.WriteLine(string.Format("******* NON PARALLEL RUN TIME: {0} {1}", getTiming(localTimer), getTimingUnits().ToUpper()));
            return timings;
        }

        private delegate long[] SolutionRunner(MethodInfo m, int times);

        private static SolutionRunner runner;
        private static bool runAllProblems;
        private static string[] problems;
        private static int iterations;
        private static bool showMs;

        private static void ReadSettings()
        {
            string problemSettings = ConfigurationManager.AppSettings["problems"] ?? "all";
            runAllProblems = problemSettings.ToLower() == "all";
            if (!runAllProblems)
            {
                problems = problemSettings.Split(',')
                                            .Select(s => s.TrimStart('0', ' '))
                                            .ToArray();
            }

            string runnerSettings = ConfigurationManager.AppSettings["runner"] ?? string.Empty;
            runner = runnerSettings.ToLower() == "parallel"
                ? (SolutionRunner)RunSolutionParallel
                : RunSolution;

            iterations = int.Parse(ConfigurationManager.AppSettings["iterations"] ?? "1");
            if (iterations < 1)
            {
                iterations = 1;
            }

            showMs = (ConfigurationManager.AppSettings["timingUnits"] ?? "ms".ToLower()) == "ms";
        }

        private static IEnumerable<Type> GetAllEulerProblems()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                                                  .Where(t => t.IsPublic &&
                                                              t.GetCustomAttributes(typeof(EulerProblemAttribute), false).Any() &&
                                                              t.Name.StartsWith("Problem") &&
                                                              (runAllProblems || problems.Contains(t.Name.Substring("Problem".Length).TrimStart('0'))))
                                                  .OrderBy(t => t.Name);
        }

        private static IEnumerable<MethodInfo> GetAllEulerSolutions(Type eulerProblem)
        {
            return eulerProblem.GetMethods()
                               .Where(m => m.IsStatic &&
                                           m.IsPublic &&
                                           m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).Any())
                               .OrderBy(m => m.Name);
        }

        static void Main(string[] args)
        {
            ReadSettings();

            foreach (Type t in GetAllEulerProblems())
            {
                Trace.WriteLine("\n===================");
                Trace.WriteLine(string.Format("Problem {0}", t.Name.Substring("Problem".Length).TrimStart('0')));
                foreach (MethodInfo m in GetAllEulerSolutions(t))
                {
                    var attrib = ((EulerSolutionAttribute)m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).First());
                    if (attrib.IsEnabled)
                    {
                        var defaultTimer = new Stopwatch();
                        // Get the result. Pass in a dummy timer.
                        var res = m.Invoke(null, new object[] { defaultTimer });

                        if (iterations > 1)
                        {
                            // Get the timings.
                            long[] timings = runner(m, iterations);
                            Range<long> timingExtremes = timings.MinMax();
                            Trace.WriteLine(string.Format("\tSolution {0}: Result = {1} [low: {2}, high: {3}, avg: {4:F3}, med: {5:F1}, stdev: {6:F3}] (timing in {7})",
                                                           m.Name.Substring("Solution".Length),
                                                           res,
                                                           timingExtremes.Min, timingExtremes.Max,
                                                           timings.Average(), timings.Median(), timings.StandardDeviation(), getTimingUnits()));
                        }
                        else
                        {
                            Trace.WriteLine(string.Format("\tSolution {0}: Result = {1} in {2} {3}",
                                                           m.Name.Substring("Solution".Length),
                                                           res, getTiming(defaultTimer), getTimingUnits()));
                        }
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
