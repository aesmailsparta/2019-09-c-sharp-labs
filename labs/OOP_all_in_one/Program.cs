using System;

namespace OOP_all_in_one
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Parent : IDoThis, IDoThat
    {
        private int PIN = 1234;
        internal string ForThisAppOnly = "MySecret";
        protected string FamilyInformation = "FamilySecret";
        public virtual void OverrideThisIfYouLike()
        {
            Console.WriteLine("I am the Original");
        }

        string DoThat(string duplicate)
        {
            return duplicate + duplicate;
        }

        string DoThis(string concatenate)
        {
            return concatenate + "RandomString";
        }
    }

    class Child : Parent
    {
        Child(string AppSecret, string FamilySecret)
        {
            this.ForThisAppOnly = AppSecret;
            this.FamilyInformation = FamilySecret;
        }

    }

    interface IDoThis
    {
        string DoThis();
    }

    interface IDoThat
    {
        string DoThat();
    }
}
