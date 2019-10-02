using System;

namespace lab_32_events
{
    class Program
    {
        public delegate void MyDelegate();

        public static event MyDelegate MyEvent;
        static void Main(string[] args)
        {
            MyEvent += MethodA;//Pointer To a Method but dont call the method now
            MyEvent += MethodB;
            MyEvent += MethodC;

            MyEvent();
        }

        static void MethodA()
        {
            Console.WriteLine("Method A");
        }
        static void MethodB()
        {
            Console.WriteLine("Method B");
        }
        static void MethodC()
        {
            Console.WriteLine("Method C");
        }
    }
}
