using System;

namespace lab_6_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.Name = "Fido";

            var labrador01 = new Labrador();
            labrador01.Name = "MansBestFriend";
        }
    }

    class Dog
    {
        public string Name { get; set; }

    }

    class Labrador : Dog
    {
        public int Age { get; set; }

    }
}
