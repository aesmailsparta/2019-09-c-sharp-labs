using System;

namespace do_it_06_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            Console.WriteLine("Break");
            while (counter < 10)
            {
                counter++;
                Console.WriteLine(counter);
                break;

                counter += 200;
            }

            Console.WriteLine();
            Console.WriteLine("Continue");


            while (counter < 10)
            {
                counter++;
                Console.WriteLine(counter);
                continue;

                counter += 200;
            }
        }
    }
}
