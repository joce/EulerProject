using System.Diagnostics;

namespace EulerProject
{
	public struct EulerResult<T>
	{
		public T result;
		public Stopwatch timer;

		public EulerResult(T result, Stopwatch timer)
		{
			this.result = result;
			this.timer = timer;
		}
	}
}
