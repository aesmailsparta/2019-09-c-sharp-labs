using System;

namespace lab_40_core_library
{
    public class MyClass
    {
        public string TestValue { get; set; }
        public int SomeNumber {get; set; }

        public void AddMe(){
            SomeNumber += 10;
            Console.WriteLine(SomeNumber);
        }
    }
}
