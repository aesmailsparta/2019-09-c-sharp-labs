using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_19_struct
{
    class Program
    {
        static void Main(string[] args)
        {

            var s = new MyStruct(10, 10, "hi");

            Console.WriteLine(s.GetX());

            Stack<int> stack = new Stack<int>();

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            List<int> myList = new List<int>();

            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add("hi");

        }
    }

    class MyClass{}

    struct MyStruct{
        private int X;
        public int Y;
        public string Z { get; set; }

        public MyStruct(int x, int y, string z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int GetX()
        {
            return this.X;
        }
    }
}
