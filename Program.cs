using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runAllProblems = ConfigurationManager.AppSettings["problems"].ToLower() == "all";
            IEnumerable<string> problems = ConfigurationManager.AppSettings["problems"]
                                                               .Split(',')
                                                               .Select(s => s.TrimStart('0',' '));

            foreach (var t in Assembly.GetExecutingAssembly().GetTypes()
                                                             .Where(t => t.BaseType == typeof(ProblemBase) &&
                                                                         t.IsPublic &&
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
                        var res = m.Invoke(null, null);
                        Trace.WriteLine(string.Format("\tSolution {0}: Result = {1} in {2} ticks",
                                                       m.Name.Substring("Solution".Length),
                                                       res,
                                                       ProblemBase.ElapsedTicks));
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
