using System;

namespace do_it_05_BIDMAS
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1;
            double b = 2;
            double c = 3;
            double d = 4;
            double e = 5;
            double f = 6;
            double n = 7;

            double total = 0;

            total = Math.Pow(((a + b * c / d - e) / f), n);

            Console.WriteLine(total);

             a = 10;
             b = 15;
             c = 20;
             d = 25;
             e = 30;
             f = 35;
             n = 4;

             total = 0;

            total = Math.Pow(((a + b * c / d - e) / f), n);

            Console.WriteLine(total);
        }
    }
}
