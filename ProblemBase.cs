using System.Diagnostics;

namespace EulerProject
{
    public class ProblemBase
    {
        protected static Stopwatch _timer = new Stopwatch();
        public static long ElapsedTicks{ get { return _timer.ElapsedTicks; } }
    }
}
