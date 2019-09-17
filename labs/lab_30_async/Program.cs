using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace lab_30_async
{
    class Program
    { 
        
        static List<string> lines = new List<string>();

        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
           
            s.Start();

            //Create Dummy Data
            //for (int i = 0; i < 100000; i++)
            //{    
            //    File.AppendAllText("async.txt", $"Adding line : {i} at {DateTime.Now}\n");
            //}


            //DoThisLongThing();
            DoThisLongThingAsync();

            //s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static void DoThisLongThing()
        {
            System.Threading.Thread.Sleep(3000);
        }
        
        async static void DoThisLongThingAsync()
        {
            // STREAM IN DATA STREAMREADER(Unknown length of data)
            using(var reader = new StreamReader("async.txt"))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null)
                    {
                        break;
                    }
                    lines.Add(line);
                }
            } 
            s.Stop();
            Console.WriteLine($"Finished Reading {lines.Count} lines in {s.ElapsedMilliseconds}");
           
        }
    }


}
