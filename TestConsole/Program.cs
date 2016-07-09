using System;
using static System.Console;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> add = Add;
            var add1 = add.Apply(1);
            WriteLine(add(2, 3));
            WriteLine(add1(32));
            Func<double, double, double, double> addDouble = Add;
            Func<double, double, double, double> addDouble2 = (x, y, z) => x + y + z;
            Func<int, int> square = Square;
            var addAndSquare = add.Compose(square);
            var add2 = addDouble.Apply(2);
            var add2and3 = addDouble.Apply(2, 3);
            WriteLine(add2(1, 1));
            WriteLine(add2and3(1));
            addAndSquare(4, 3).Pipe(WriteLine);
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Square(int x)
        {
            return x*x;
        }

        static double Add(double x, double y, double z)
        {
            return x + y + z;
        }

        static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f1, Func<T2, T3> f2)
        {
            return x => f2(f1(x));
        }
        static Func<T1, T2, T4> Compose<T1, T2, T3, T4>(this Func<T1, T2, T3> f1, Func<T3, T4> f2)
        {
            return (x, y) => f2(f1(x, y));
        }
        static Func<T2, T3> Apply<T1, T2, T3>(this Func<T1, T2, T3> f1, T1 t)
        {
            return x => f1(t, x);
        }
        static Func<T3, T4> Apply<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> f1, T1 t1, T2 t2)
        {
            return x => f1(t1, t2, x);
        }
        static Func<T2, T3, T4> Apply<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> f1, T1 t1)
        {
            return (x, y) => f1(t1, x, y);
        }
        static Func<T4, T5> Apply<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> f1, T1 t1, T2 t2, T3 t3)
        {
            return x => f1(t1, t2, t3, x);
        }

        static void Pipe<T1>(this T1 t1, Action<T1> a1)
        {
            a1(t1);
        }
    }
}
