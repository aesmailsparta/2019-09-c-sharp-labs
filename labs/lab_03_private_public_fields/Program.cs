using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";
            person01.SetNINO("ABC123");
            Console.WriteLine(person01.GetNINO());
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        public string GetNINO()
        {
            return this.NINO;
        }

        public void SetNINO(string NINO)
        {
            this.NINO = NINO;
        }
    }
}
