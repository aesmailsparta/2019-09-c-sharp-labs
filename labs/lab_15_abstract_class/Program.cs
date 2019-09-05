using System;

namespace lab_15_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var holiday = new HolidayWithTravel();
        }
    }

    public abstract class Holiday
    {
        public abstract void Travel();
        public void Places() { Console.WriteLine("Visiting vienna, Salzburg"); }
        public void Activities() { Console.WriteLine("Sking, Walking, Fishing"); }

    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel()
        {
            Console.WriteLine("By Train, Eurostar, Boat");
        }
    }
}
