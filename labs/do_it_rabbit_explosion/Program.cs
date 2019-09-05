using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace do_it_rabbit_explosion
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxPopulation = 100;

            var rabbitReturn = just_do_it_11_rabbit_exp.ExponentialGrowth(maxPopulation);

            Console.WriteLine($"Population reached in {rabbitReturn.years} Years");
        }

        static Rabbit SpawnRabbit(int count)
        {
            var rabbit = new Rabbit($"Rabbit{count:D2}", 0);
            return rabbit;
        }
    }

    public class just_do_it_11_rabbit_exp
    {
        static List<Rabbit> Rabbits = new List<Rabbit>();

        public static (int years, int population) ExponentialGrowth(int maxPopulation)
        {
            
            string LogFile = "Log.txt";
            var s = new Stopwatch();
            int proCreationAge = 3;

            int count = 0;

            int iterationCount = 0;
            s.Start();
            while (Rabbits.Count < maxPopulation)
            {
                if (count == 0)
                {
                    Rabbits.Add(SpawnRabbit(count));
                    count++;
                }
                else
                {
                    int cycles = Rabbits.Count;
                    for (int i = 0; i < cycles; i++)
                    {
                        Rabbits[i].Age++;

                        if (Rabbits[i].Age >= proCreationAge)
                        {
                            if (Rabbits.Count < maxPopulation)
                            {
                                Rabbit r = SpawnRabbit(count);
                                Rabbits.Add(r);
                                File.WriteAllText(LogFile, $"New Rabbit Called {r.Name}, Born at {DateTime.Now} {Environment.NewLine}");
                                count++;
                            }
                            else
                            {
                                Console.WriteLine("LIMIT HAS BEEN REACHED");
                                s.Stop();
                                break;
                            }
                        }

                    }
                }


                iterationCount += (maxPopulation != Rabbits.Count) ? 1 : 0;

            }

            foreach (Rabbit r in Rabbits)
            {
                Console.WriteLine($"Name: {r.Name}, Age: {r.Age}");
            }


            Console.WriteLine(File.ReadAllText(LogFile));


            Console.WriteLine($"{iterationCount} Iterations Taken \n\n");
            Console.WriteLine($"Total time elapsed: {s.ElapsedMilliseconds}ms");

            return (iterationCount, Rabbits.Count);
        }

        static Rabbit SpawnRabbit(int count)
        {
            var rabbit = new Rabbit($"Rabbit{count:D2}", 0);
            return rabbit;
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Rabbit(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

    }


}
