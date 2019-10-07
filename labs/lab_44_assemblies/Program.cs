using System;
using System.Reflection;

namespace lab_44_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            // use INT type as an example
            var myType = typeof(int);
            //Lets find the DLL of where int lives in windows
            var myAssembly = Assembly.GetAssembly(myType);

            Console.WriteLine($"Assembly is called {myAssembly.GetName()}\n\n");

            foreach (var type in myAssembly.GetTypes())
            {
                Console.WriteLine(type);
            }
        }
    }
}
