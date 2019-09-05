using System;
using System.IO;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {
            string string01 = "";
            string fileName = "myFile.txt";

            if (File.Exists(fileName))
            {
                string01 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string01);
            }
            else
            {
                File.WriteAllText(fileName, "Here is some text data, \n\n And\nthis\nis\na\nnew\nline.");
            }

            string[] myArray = new string[] {"some", "text", "array", "data"};

            File.WriteAllLines(fileName, myArray);

            var OutputArray = File.ReadAllLines(fileName);

            foreach(var s in OutputArray)
            {
                Console.WriteLine(s);
            }

            File.WriteAllText(fileName, "Appended New Line" + Environment.NewLine + "");


            Console.WriteLine("\n==========LOGGING==========\n");

            var d = DateTime.Now;
            Console.WriteLine(d);
            for(int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log()", $"Event happend at time {DateTime.Now}");
                System.Threading.Thread.Sleep(300);
            }

            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}
