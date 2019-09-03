using System;

namespace lab_7_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();

            var m = new Mammal();
            m.GetOlder();

            //method INSIDE method
            void DoThis()
            {
                Console.WriteLine("I am doing something");
            }

            OutParameters(10, 10, out int a);
            Console.WriteLine(a);

            TupleMethod();

            var TupleOutput = TupleMethod();

            Console.WriteLine($"{TupleOutput.x}, {TupleOutput.y}, {TupleOutput.z}");
            {

            }
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;
        }

        //Add method to class
        static void DoThisAswell()
        {
            Console.WriteLine("I am doing something aswell");
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }
    }

    class Mammal
    {
        public int Age { get; set; }

        //Instance Method
        public void GetOlder()
        {
            Age++;
        }
    }
}
