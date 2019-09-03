using System;

namespace lab_02_class
{
    // Instructions (BLUEPRINT) for new Dog Object
    class Dog{

        public string Name;
        public int Age;
        public int Height;

        public void Grow()
        {
            this.Age++;
            this.Height += 10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // use the class : create new DOG object == INSTANCE
            var dog01 = new Dog();//create empty dog object
            dog01.Name = "Fido";
            dog01.Age = 1;
            dog01.Height = 400;

            Console.WriteLine($"Age is {dog01.Age}");
            Console.WriteLine($"Height is {dog01.Height}");

            dog01.Grow();
            Console.WriteLine("Your puppy is evolving.......");
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine($"Age is {dog01.Age}");
            Console.WriteLine($"Height is {dog01.Height}");

            Console.ReadLine();
        }
    }


}
