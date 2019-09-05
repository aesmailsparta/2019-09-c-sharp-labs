using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var base01 = new Base(5, 5);
            var child01 = new Child(5, 5);
            Base base02 = child01;

            Console.WriteLine($"Base Multiplys {base01.calculate()}");
            Console.WriteLine($"Child Subtracts {base02.calculate()}");

            Console.WriteLine(base02.calculate());
        }
    }

    class Base
    {
        public int number01;

        public int number02;

        public Base(int number01, int number02)
        {
            this.number01 = number01;
            this.number02 = number02;
        }

        public int calculate()
        {
            int newnum = this.number01 * this.number02;
            return newnum;
        }
    }

    class Child : Base
    {
        public Child(int number01, int number02):base(number01, number02)
        {
     
        }

        public new int calculate()
        {
            int newnum = this.number01 - this.number02;
            return newnum;
        }
    }
}
