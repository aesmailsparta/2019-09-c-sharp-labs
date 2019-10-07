using System;
using lab_40_core_library;

namespace lab_40_use_library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var thing = new MyClass();

            thing.AddMe();

            System.Console.WriteLine(thing.SomeNumber);
        }
    }
}
