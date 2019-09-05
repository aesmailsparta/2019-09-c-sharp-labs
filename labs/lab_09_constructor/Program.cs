using System;

namespace lab_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {

            var merc01 = new Mercedes("CHASIS1234ABC", "Silver", 2500);
            var Aclass01 = new AClass("CHASISA38842D", "Blue", 2650);
            var A104_01 = new A104("CHASIS9938FFD", "Green");

        }

        class Mercedes
        {
            protected string engineChassisID;

            public string Color { get; set; }

            public int Length { get; set; }

            public Mercedes()
            {

            }

            public Mercedes(string engineChassisID, string Color, int Length)
            {
                this.engineChassisID = engineChassisID;
                this.Color = Color;
                this.Length = Length;
            }

        }

        class AClass : Mercedes
        {
            public AClass()
            {
            }

            public AClass(string engineChassisID, string Color, int Length)
            {
                this.engineChassisID = engineChassisID;
                this.Length = Length;
                this.Color = Color;
            }
        }

        class A104 : AClass
        {

            public A104(string engineChassisID, string Color) : base(engineChassisID, Color, 2000)
            {

            }

        }

    }            
}
