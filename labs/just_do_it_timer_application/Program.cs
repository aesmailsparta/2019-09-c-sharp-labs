using System;
using System.IO;
using System.Diagnostics;

namespace just_do_it_timer_application
{
    class Program
    {
        static void Main(string[] args)
        {
            int LinesToWrite = 10;

            FileTimer fileTimer = new FileTimer();

            long timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);

            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");

            //100 Lines
            LinesToWrite = 100;

            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);

            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");

            //1000 Lines
            LinesToWrite = 1000;

            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);

            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");

            //10000 Lines
            LinesToWrite = 10000;

            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);

            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");

            //Read 10 Lines

            timeTaken = fileTimer.FileReadLines("read10Test.txt", 10);

            Console.WriteLine($"{timeTaken}ms to read 10 lines from file");

            //Read 100 Lines

            timeTaken = fileTimer.FileReadLines("read100Test.txt", 100);

            Console.WriteLine($"{timeTaken}ms to read 100 lines from file");

            //Read 1000 Lines

            timeTaken = fileTimer.FileReadLines("read1000Test.txt", 1000);

            Console.WriteLine($"{timeTaken}ms to read 1000 lines from file");

            //Read 10000 Lines

            timeTaken = fileTimer.FileReadLines("read10000Test.txt", 10000);

            Console.WriteLine($"{timeTaken}ms to read 10000 lines from file");




            //10 Lines
            LinesToWrite = 10;
            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");
            timeTaken = fileTimer.FileReadLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to read {LinesToWrite} lines from file\n");
            //100 Lines
            LinesToWrite = 100;
            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");
            timeTaken = fileTimer.FileReadLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to read {LinesToWrite} lines from file\n");
            //1000 Lines
            LinesToWrite = 1000;
            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");
            timeTaken = fileTimer.FileReadLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to read {LinesToWrite} lines from file\n");
            //10000 Lines
            LinesToWrite = 10000;
            timeTaken = fileTimer.FileAppendLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to write {LinesToWrite} lines to file");
            timeTaken = fileTimer.FileReadLines("async.txt", LinesToWrite);
            Console.WriteLine($"{timeTaken}ms to read {LinesToWrite} lines from file\n");




        }
    }

    class FileTimer
    {
        public Stopwatch timer = new Stopwatch();

        public long FileAppendLines(string fileName, int lines)
        {
            if (File.Exists(fileName)) { File.Delete(fileName); }
            timer.Reset();
            timer.Start();
            for (int i = 0; i <  lines; i++)
            {
                File.AppendAllText(fileName, "This is a line of text.... Hello!\n");
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        public long FileReadLines(string fileName, int lines)
        {
            timer.Reset();
            timer.Start();

            var t = new Stopwatch();
            t.Start();
            //int counter = 0;
            using (var reader = new StreamReader(fileName))
            {
                //while (counter <  lines)
                //{
                //    var line = reader.ReadLine();
                //    if (line == null)
                //    {
                //        break;
                //    }

                //    counter++;
                //}

                //reader.Close();

                for(int i = 0; i < lines; i++)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                }
            }
            t.Stop();
            //File.ReadAllLines(fileName);
            timer.Stop();
           
            return t.ElapsedTicks;
        }

    }
}
