using System;

namespace lab_10_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Method01();
            Method01(100);
            Method01("Hello");
            Method01("BLANK", 1500);
        }

        static void Method01()
        {
            Console.WriteLine("I have no parameters");
        }

        static void Method01(int x)
        {
            Console.WriteLine($"{x} is an integer");
        }

        static void Method01(string x)
        {
            Console.WriteLine($"{x} is a string");
        }

        static void Method01(string x, int y)
        {
            Console.WriteLine($"{x} is a string and {y} is an integer");
        }
    }

    class MyClass
    {
        void Method01()
        {
            Console.WriteLine("I have no parameters");
        }

        void Method01(int x)
        {
            Console.WriteLine($"{x} is an integer");
        }

        void Method01(string x)
        {
            Console.WriteLine($"{x} is an string");
        }
    }
}
