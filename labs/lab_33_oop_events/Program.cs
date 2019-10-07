using System;

namespace lab_33_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {

            var James = new Child();

            James.Name = "James";

            for (int i = 0; i < 10; i++)
            {
                int AgeNow = James.Grow($"Special party for year {i}");
            }
        }
    }

    class Child
    {
        public delegate int BirthdayDelegate(string TypeOfParty);
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }

        public int Age { get; set; }

        public Child()
        {
            this.Age = 0;
            this.HaveABirthday += Celebrate;
            Console.WriteLine("Congratulation !!!! Beautiful Baby /(\",/)");
        }

        public int Grow(string TypeOfParty)
        {
            int AgeNow = HaveABirthday(TypeOfParty);
            return AgeNow;
        }

        int Celebrate(string TypeOfParty)
        {
            Age++;
            Console.WriteLine($"Celebrating another birthday : Age is {this.Age}");
            return this.Age;
        }
    }
}
