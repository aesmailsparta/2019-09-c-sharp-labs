using System;

namespace do_it_07_switch
{
    class Program
    {
        static void Main(string[] args)
        {

            string numString;
            Console.WriteLine("Enter a number between 1 and 9");
            numString = Console.ReadLine();

            switch (numString)
            {
                case "1" :
                    Console.WriteLine("You selected ONE");
                    break;
                case "2" :
                    Console.WriteLine("You selected TWO");
                    break;
                case "3" :
                    Console.WriteLine("You selected THREE");
                    break;
                case "4" :
                    Console.WriteLine("You selected FOUR");
                    break;
                case "5" :
                    Console.WriteLine("You selected FIVE");
                    break;
                case "6" :
                    Console.WriteLine("You selected SIX");
                    break;
                case "7" :
                    Console.WriteLine("You selected SEVEN");
                    break;
                case "8" :
                    Console.WriteLine("You selected EIGHT");
                    break;
                case "9" :
                    Console.WriteLine("You selected NINE");
                    break;
                default :
                    Console.WriteLine("Unknown number recieved");
                    break;

            }

            Console.WriteLine("GOODBYE");
        }
    }
}
