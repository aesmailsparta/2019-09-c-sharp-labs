using System;

namespace lab_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create an instance, Input user variables
            Console.WriteLine("We have a new Mammal!");
            Console.WriteLine("What is the mammals name?");
            string mammalName = Console.ReadLine();
            Console.WriteLine("What kind of mammal is it?");
            string mammalType = Console.ReadLine();
            Console.WriteLine("How tall is the mammal?");
            string mammalHeight = Console.ReadLine();
            Console.WriteLine("How heavy is the mammal?");
            string mammalWeight = Console.ReadLine();

            var mammal01 = new Mammal(mammalName, mammalType, int.Parse(mammalHeight), int.Parse(mammalWeight));

            Console.WriteLine($"Welcome to the family {mammal01.GetName()}");

        }
    }

    //class with private public fields, get, set
    class Mammal
    {
        private string Name;
        private string Type;
        public int Height;
        public int Weight;

        public Mammal(string name, string type, int height, int weight)
        {
            this.Name = name;
            this.Type = type;
            this.Height = height;
            this.Weight = weight;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
