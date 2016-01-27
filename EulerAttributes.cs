using System;

namespace EulerProject
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EulerProblemAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class EulerSolutionAttribute : Attribute
    {
        public bool IsEnabled { get; private set; }
        public string Reason { get; private set; }

        public EulerSolutionAttribute(bool isEnabled, string reason)
        {
            IsEnabled = isEnabled;
            Reason = reason;
        }

        public EulerSolutionAttribute() :
            this(true,"")
        {
        }
    }
}
