using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab_31_tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            Delegate myDelegate;

            //annonymous (lambda) delegate
            var task01 = new Task(() => 
            { 
                Console.WriteLine("Running Task01"); 
            });
            task01.Start();

            var oldtask = new Task(DoThis);
            //Delegate is a place holder for one or more methods
            //Simplest Delegate is called an Action
            //Action void DoThis(){} // no parameters in void output

            oldtask.Start();
            var task02 = Task.Run(() => { Console.WriteLine("Task02"); });

            var taskArray = new Task[10];
            taskArray[0] = Task.Run(() => { Console.WriteLine("Task Array 00"); });
            taskArray[1] = Task.Run(() => { Console.WriteLine("Task Array 01"); });
            taskArray[2] = Task.Run(() => { Console.WriteLine("Task Array 02"); });

            for(int i = 3; i < 10; i++)
            { 
                taskArray[i] = Task.Run(() => Console.WriteLine($"Task Array {i}"));
                System.Threading.Thread.Sleep(100);
            }

            // parallel ForEach
            Stopwatch s1 = new Stopwatch();
            Stopwatch s2 = new Stopwatch();

            var myList = new List<string> { "a", "b", "c","d","e","f","g" };
            s1.Start();
            myList.ForEach((s) => {
                Console.WriteLine($"Item is {s}");
                System.Threading.Thread.Sleep(50);
            } );
            s1.Stop();
            Console.WriteLine($"Serial Took {s1.ElapsedMilliseconds}ms");

            s2.Start();
            Parallel.ForEach(myList, (s) =>
            {
                Console.WriteLine($"Parallel item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            s2.Stop();
            Console.WriteLine($"Parallel Took {s2.ElapsedMilliseconds}ms");

            float pratio = (float)s2.ElapsedMilliseconds / (float)(s1.ElapsedMilliseconds)*100;

            Console.WriteLine($"Parallel is {pratio}");
            // PLINQ parallel LINQ

            var OutPutAsParallel =
                (from item in myList
                 select item).AsParallel().ToList();

            //Getting data back from a task
            // var t = Task<T>.Run... return data of type T
            //access data with t.Result

            var taskWithResult = Task<int>.Run(() => {
                return 100;
            });


            taskWithResult.Wait();

            Console.WriteLine($"Result of our task is {taskWithResult.Result}");
            Task.WaitAll(taskArray);
            Console.ReadLine();
        }

        static void DoThis()
        {
            Console.WriteLine("I am doing this");
        }
    }
}
