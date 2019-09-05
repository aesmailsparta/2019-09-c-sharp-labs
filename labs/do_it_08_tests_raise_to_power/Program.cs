using System;

namespace do_it_08_tests_raise_to_power
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
    }

    public class MathTools
    {
        public static double RaiseToPower(double x, double y, int p)
        {
            // 2, 3, 3  ==> (2*3)=6 and raise this to power 3 ie 36*6=216
            Console.WriteLine($"Here is some data {x} {y} {p}");
            return Math.Pow((x * y), p);
        }

    }
}
