using System;

namespace lab_37_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 123456789;
            long l = 1234567890123456789;
            float f = 123456789012345678901234567890.0f;
            double dd = 123456789012345678912345678901234567890123456789123456789012345678901234567891234567890.0;
            decimal d = 12345678901234567890123456789.0M;

            //Check for overflow exceptions - Default is unchecked
            //unchecked
            checked
            {
                //integer maximums // WRAPs on Overflow
                int bigInt = int.MaxValue;
                bigInt++;
                Console.WriteLine($"INT : {bigInt}");
                
            }

        }

    }
}
