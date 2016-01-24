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
                                                             .Where(t => t.IsPublic &&
                                                                         t.GetCustomAttributes(typeof(EulerProblemAttribute), false).Any() &&
                                                                         t.Name.StartsWith("Problem") &&
                                                                         (runAllProblems || problems.Contains(t.Name.Substring("Problem".Length).TrimStart('0'))))
                                                             .OrderBy(t => t.Name))
            {
                foreach (var m in t.GetMethods()
                                   .Where(m => m.IsStatic &&
                                               m.IsPublic &&
                                               m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).Any())
                                   .OrderBy(m => m.Name))
                {
                    var attrib = ((EulerSolutionAttribute)m.GetCustomAttributes(typeof(EulerSolutionAttribute), false).First());
                    if (attrib.IsEnabled)
                    {
                        m.Invoke(null, null);
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("Problem {0}, Solution {1}: Disabled ({2})",
                                                       t.Name.Substring("Problem".Length).TrimStart('0'),
                                                       m.Name.Substring("Solution".Length),
                                                       attrib.Reason));
                    }
                }
            }
        }
    }
}
