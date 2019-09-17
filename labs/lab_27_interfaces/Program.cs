using System;

namespace lab_27_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();

            c.IDoThis();

            c.IDoThat();

            c.Laugh();
        }
    }

    class Parent
    {
        void DoingSomeParentThing() { Console.WriteLine("I am doing some parent thing"); }
    }

    class Child : Parent , IUseThis, IUseThat, external.IAlsoDoThis
    {
        public void IDoThis()
        {
            Console.WriteLine( "Hello" );
        }

        public void IDoThat()
        {
            Console.WriteLine("GoodBye");
        }

        public void Laugh()
        {
            Console.WriteLine("HAHAHAHAHAHA");
        }
    }

    interface IUseThis
    {
        void IDoThis();
    }

    interface IUseThat
    {
        void IDoThat();
    }
}

namespace external
{
    interface IAlsoDoThis
    {
        void Laugh();
    }
}