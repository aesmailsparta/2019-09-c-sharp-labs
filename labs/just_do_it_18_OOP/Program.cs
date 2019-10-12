using System;

namespace just_do_it_18_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var child = new Child("Billy", "Likes frogs", 6, 2);
            var adult = new Adult("Chad", "Enjoys going to raves", 27);

            Console.WriteLine($" My name is {child.WhoAmI()}, Am I old: {(child.AmIOld() ? "Yes" : "No")}, my information is {child.GetDescription()}");
            Console.WriteLine($" My name is {adult.WhoAmI()}, Am I old: {(adult.AmIOld() ? "Yes" : "No")}, my information is {adult.GetDescription()}");

            child.UpdateInformation(19);
            child.UpdateInformation("Billeth");
            adult.UpdateInformation(39, "Chadington", "Loves to program in C#");


            Console.WriteLine("\n\n\n");


            Console.WriteLine($" My name is {child.WhoAmI()}, Am I old: {(child.AmIOld() ? "Yes" : "No")}, my information is {child.GetDescription()}");
            Console.WriteLine($" My name is {adult.WhoAmI()}, Am I old: {(adult.AmIOld() ? "Yes" : "No")}, my information is {adult.GetDescription()}");
        }
    }

    public abstract class Person
    {
        public int Age;
        public string Name;
        protected string Description;
        public abstract string WhoAmI();

        public abstract bool AmIOld();

        public abstract void UpdateInformation(int Age, string Name, string Description);
    }

    public class Child : Person, MyTools
    {
        private int SchoolYear;

        public Child()
        {
            this.Name = "unknown";
            this.Description = "unknown description";
            this.Age = 0;
        }

        public Child(string Name, string Description, int Age, int SchoolYear)
        {
            this.Name = Name;
            this.Description = Description;
            this.Age = Age;
            this.SchoolYear = SchoolYear;
        }

        public override string WhoAmI()
        {
            return Name;
        }

        public override bool AmIOld()
        {
            if (Age > 18)
            {
                return true;
            }

            return false;
        }

        public override void UpdateInformation(int Age, string Name, string Description)
        {
            this.Age = Age;
            this.Name = Name;
            this.Description = Description;
        }

        public void UpdateInformation(int Age)
        {
            this.Age = Age;
        }

        public void UpdateInformation(string Name)
        {
            this.Name = Name;
        }

        public string initials()
        {
            return this.Name.Substring(0, 1);
        }

        public string GetDescription()
        {
            return this.Description;
        }

    }

    public class Adult : Child {
        public Adult()
        {
            this.Name = "unknown";
            this.Description = "unknown description";
            this.Age = 0;
        }

        public Adult(string Name, string Description, int Age)
        {
            this.Name = Name;
            this.Description = Description;
            this.Age = Age;
        }

        public override string WhoAmI()
        {
            return Name;
        }

        public override bool AmIOld()
        {
            if (Age > 35)
            {
                return true;
            }

            return false;
        }

        public override void UpdateInformation(int Age, string Name, string Description)
        {
            this.Age = Age;
            this.Name = Name;
            this.Description = Description;
        }

    }

    sealed class HiddenAbilities{

            
    }

    interface MyTools
    {
        public string initials();
    }



}
