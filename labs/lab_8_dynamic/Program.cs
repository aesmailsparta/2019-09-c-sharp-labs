using System;

namespace lab_8_dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = 10;

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = "a string";

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = new int[1, 2, 3];

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());


            dynamic obj2 = 10;
            obj2 = "a string";
            obj2 = new int[1, 2, 3];

        }
    }
}
