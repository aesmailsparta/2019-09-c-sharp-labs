using System;
using System.IO;
using System.Diagnostics;

namespace lab_50_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = new string[]
            {
                "Name, Age, Hobby",
                "Phil, 34, Gym",
                "Fuat, 26, Football",
                "Ryan, 22, Coding",
                "Mohssin, 21, MMA",
            };

            File.WriteAllLines("data.txt", data);
            File.WriteAllLines("data.csv", data);

            Process.Start("Excel.exe", "data.csv");

            Console.WriteLine("Data Written");
        }
    }
}
