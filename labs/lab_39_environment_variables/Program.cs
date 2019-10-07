using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_39_environment_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(DictionaryEntry item in Environment.GetEnvironmentVariables())
            {   
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine(Environment.GetEnvironmentVariable("WinDir"));

            //Environment.SetEnvironmentVariable("SecretPassword", "123");

            Console.WriteLine(Environment.GetEnvironmentVariable("SamsSecretPassword"));
        }
    }
}
