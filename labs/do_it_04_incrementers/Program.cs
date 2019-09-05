using System;

namespace do_it_04_incrementers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 50;
            Console.WriteLine(x++);//incremented after use
            Console.WriteLine(++x);//incremented before use
        }
    }
}
