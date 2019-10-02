using System;
using System.Collections.Generic;

namespace lab_36_reference_value_type
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primative Type    : int, bool, char, struct
            //STORED IN FAST STACK MEMORY
            //values stored with declaration in live fast code
            //destroyed immediately as well
            //Value Types as VALUE stored in stack memory with declaration

            //COPY of a value type is independant

            var x = 10;
            var y = x;
            x = 1000;
            y = 3333;

            Console.WriteLine($"{x} is x, {y} is y");

            DoThisPermanently(ref x, ref y);
            Console.WriteLine($"x is {x}, y is {y}");




            //reference types
            //VALUE Types are primatives eg. int held on the fast stack

            //reference types are large objects
            //short cut = POINTER held on fast stack
            //ACTUAL OBJECT held on SLOWER HEAP (LARGER MEMORY)

            // COPY A REFERENCE TYPE  : BY DEFAULT YOU ONLY COPY THE POINTER
            int[] myArray = new int[] { 100, 200, 300 };
            int[] myArray2 = myArray;//Copy pointer only not a new object in heap memory


            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));

            myArray[2] = 5000;
            myArray2[1] = 14000;

            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));

            //REFERENCE TYPES ARE NATURALLY TREATED AS GLOBAL WHEN PASSED INTO A METHOD
            List<string> myList = new List<string>();
            DoThisToMyList(myList);

            Console.WriteLine(string.Join(",", myList));
        }

        static void DoThis(int x, int y)
        {
            x = x * x;
            y = y * y * y;
        }
        static void DoThisPermanently(ref int x, ref int y)
        {
            x = x * x;
            y = y * y * y;
        }

        static void DoThisToMyList(List<string> list)
        {
            for(int i = 0; i < 10; i++)
            {
                list.Add($"Item {i.ToString()}");
            }
        }
    }
}
