﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EulerProject
{
    public static class Generator
    {
        public static IEnumerable<T> Generate<T>(this T first, Func<T, T> generator)
        {
            T current = first;
            for (;;)
            {
                yield return current;
                current = generator(current);
            }
        }
    }

    [EulerProblem]
    public class Problem002
    {
        // The results I got are of the following order of magnitude:
        //
        // Problem 2, Solution 1: Total = 4613732 in 27253 ticks
        // Problem 2, Solution 2: Total = 4613732 in 4082 ticks
        // Problem 2, Solution 3: Total = 4613732 in 29251 ticks
        // Problem 2, Solution 4: Total = 4613732 in 1 ticks
        // Problem 2, Solution 5: Total = 4613732 in 9393 ticks

        class FiboEnumerator : IEnumerator<int>
        {
            public FiboEnumerator()
            {
                Prev = 0;
                Current = 1;
            }

            void IDisposable.Dispose() { }

            public bool MoveNext()
            {
                int temp = Current;
                Current = Current + Prev;
                Prev = temp;
                return true;
            }

            int Prev { get; set; }
            public int Current { get; private set; }

            public void Reset()
            {
                Prev = 0;
                Current = 1;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        class Fibo : IEnumerable<int>
        {
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
            public IEnumerator<int> GetEnumerator() { return new FiboEnumerator(); }
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int total = new Fibo().Where(i => i % 2 == 0).TakeWhile(i => i < 4000000).Sum();
            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        static IEnumerable<int> GetFibo()
        {
            int prev = 0;
            int cur = 1;

            for (;;)
            {
                yield return cur;
                int temp = cur;
                cur = cur + prev;
                prev = temp;
            }
        }

        [EulerSolution]
        public static int Solution2(Stopwatch timer)
        {
            timer.Restart();
            int total = GetFibo().Where(i => i % 2 == 0).TakeWhile(i => i < 4000000).Sum();
            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

        static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a);
            return rec(rec);
        }

        static Func<A, R> MemoizeY<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            var cache = new Dictionary<A, R>();
            Recursive<A, R> rec = r => a =>
            {
                R value;
                if (!cache.TryGetValue(a, out value))
                {
                    value = f(r(r))(a);
                    cache[a] = value;
                }
                return value;
            };
            return rec(rec);
        }

        [EulerSolution]
        public static int Solution3(Stopwatch timer)
        {
            timer.Restart();
            var fib = MemoizeY<int, int>(f => n => n > 1 ? f(n - 1) + f(n - 2) : 1);
            int total = Enumerable.Range(0, Int32.MaxValue)
                                  .Select(fib)
                                  .Where(n => n % 2 == 0)
                                  .TakeWhile(n => n < 4000000)
                                  .Sum();
            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution4(Stopwatch timer)
        {
            timer.Restart();
            int prev = 0;
            int cur = 1;
            int total = 0;
            while (cur < 4000000)
            {
                if (cur % 2 == 0)
                {
                    total += cur;
                }
                int temp = cur;
                cur += prev;
                prev = temp;
            }
            timer.Stop();
            return total;
        }


        //////////////////////////////////////////////////////


        [EulerSolution]
        public static int Solution5(Stopwatch timer)
        {
            timer.Restart();

            // Results in ~12000 ticks.
            //int total = Tuple.Create(0, 1)
            //                 .Generate(pair => Tuple.Create(pair.Item2, pair.Item1 + pair.Item2))
            //                 .TakeWhile(pair => pair.Item2 < 4000000)
            //                 .Where(pair => pair.Item2 % 2 == 0)
            //                 .Sum(pair => pair.Item2);

            // Results in ~10200 ticks.
            //int total = Tuple.Create(0, 1)
            //                 .Generate(pair => Tuple.Create(pair.Item2, pair.Item1 + pair.Item2))
            //                 .Where(pair => pair.Item2 % 2 == 0)
            //                 .TakeWhile(pair => pair.Item2 < 4000000)
            //                 .Sum(pair => pair.Item2);

            // Results in ~9500 ticks.
            int total = Tuple.Create(0, 1)
                             .Generate(pair => Tuple.Create(pair.Item2, pair.Item1 + pair.Item2))
                             .Select(pair => pair.Item2)
                             .Where(i => i % 2 == 0)
                             .TakeWhile(i => i < 4000000)
                             .Sum();

            timer.Stop();
            return total;
        }
    }
}
