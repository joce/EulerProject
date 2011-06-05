﻿using System;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;

namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> problems = ConfigurationManager.AppSettings["problems"].Split(',').Select(s => s.TrimStart('0',' '));
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes()
                                                             .Where(t => t.IsPublic && t.GetCustomAttributes(typeof(EulerProblemAttribute), false)
                                                                                        .Any())
                                                             .OrderBy(t => t.Name))
            {
                if (t.Name.StartsWith("Problem") && problems.Contains(t.Name.Substring("Problem".Length).TrimStart('0')))
                {
                    foreach (var m in t.GetMethods()
                                       .Where(m => m.IsStatic && m.IsPublic && m.GetCustomAttributes(typeof(EulerSolutionAttribute), false)
                                                                                .Any())
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
}
