using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {
            rabbits = updateRabbitList();
            printRabbits(rabbits);

            //new rabbit : WPF Textbox01.Text => Age/Name (2 boxes)
            //Add button to add a new rabbit

            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{rabbits.Count + 1}"
            };

            using (var db = new RabbitDbEntities())
            {

                db.Rabbits.Add(newRabbit);
                db.SaveChanges();

            }

            System.Threading.Thread.Sleep(200);

            rabbits = updateRabbitList();
            printRabbits(rabbits);

            Console.ReadLine();
            
        }

        static void printRabbits(List<Rabbit> rabbits)
        {
            Console.WriteLine($"{"ID",-5}" + $"{"Name",-12}{"Age"}");
            rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" +
                            $"{rabbit.Name,-12}{rabbit.Age}"));
        }

        static List<Rabbit> updateRabbitList()
        {
            using (var db = new RabbitDbEntities())
            {
                return db.Rabbits.ToList();
            }
        }

        static void createNewRabbit()
        {
            List<Rabbit> r = updateRabbitList();
            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{r.Count + 1}"
            };

            using (var db = new RabbitDbEntities())
            {

                db.Rabbits.Add(newRabbit);
                db.SaveChanges();

            }
        }


    }
}
