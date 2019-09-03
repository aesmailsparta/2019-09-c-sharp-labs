using System;
using System.Collections.Generic;

namespace lab_05_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rabbit> listOfRabbits = new List<Rabbit>();
            var rabbit = new Rabbit();
            rabbit.Name = "cute01";
            rabbit.Age = -10;

            for (int i = 1; i <= 10; i++)
            {
                var newRabbit = new Rabbit();
                newRabbit.Name = $"Rabbit{i:D2}";
                newRabbit.Age = i;
                listOfRabbits.Add(newRabbit);
            }

            foreach (Rabbit r in listOfRabbits.ToArray())
            {
                Console.WriteLine($"Rabbit Name: {r.Name}, Age: {r.Age}");
            }

            //Console.WriteLine(listOfRabbits.ToArray().ToString());

            //Console.WriteLine(rabbit.Name);
        }
    }

    class Rabbit
    {
        private int _bloodType;
        private int _age;

        public string Name { get; set; }

        public int Age
        {
            get {
                return this._age;
            }
            set {
                if (value > 0)
                {
                    this._age = value;
                }
            }

        }

    }
}
