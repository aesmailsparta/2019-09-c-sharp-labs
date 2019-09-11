using System;
using System.Collections.Generic;

namespace lab_21_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //KEY-VALUE PAIRS
            //KEY Index
            //VALUE 
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            myDictionary.Add(0, "hi");
            myDictionary.Add(1, "hi");

            myDictionary.TryAdd(0, "hi");

            foreach(var item in myDictionary)
            {
                Console.WriteLine($"{item.Key, -10}{item.Value}");
            }

        }
    }
}
