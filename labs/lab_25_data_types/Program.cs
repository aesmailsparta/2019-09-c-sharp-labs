using System;

namespace lab_25_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            byte bmin = 0;
            byte bmax = 255;

            byte bmin_in_binary = 0b_00000000;
            byte bmax_in_binary = 0b_00000000;

            byte bmin_in_hex = 0x_00;
            byte bmax_in_hex = 0x_ff;

            //byte bnegative_is_invalid = -1;

            //letters are also stored as numbers
            char letter01 = 'a';

            //numbers
            //int - 32 bits (1bit for sign)
                var numberOfAnyType = 27;

            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            //short - 16 bits
            short shor01 = 25;
            //long - 64 bit
            long long01 = 3924343244;
            // 32 bit
            float f = 1.234f;
            // 64 bit
            double d = 1.234;
            // 128 bit
            decimal de = 1.234m;

            //Poistive numbers only // unsigned means pure 32 bit
            uint positiveInteger = 500;

            ///Operators
            ///
            // a+b=c    Expression
            // a, b     Operands
            // +        Operator

            //Binary two inputs
            //Unary one input

            //Unary
            int x = 10;

            x++;
            ++x;

            // !    NOT
            // !!   NOT NOT


            //Binary Two inputs
            // %    Modulus
            // int/int = int
            // a/b = remainder

            //proper decimal division, one number has to be a float or decimal or double

            //Ternary Operator
            //if(condition) ? return this if true : return this if false ;

            //nullable
            int number = 100;
            int? number2 = 1000;
            //number2 is useful if we read from database and its possible
            // this box is blank so returns NULL

            //Null coalesce operator : shorthand for

            Console.WriteLine("somevalue"??"returnthisifnull"); //somevalue
            Console.WriteLine(null??"returnthisifnull"); //null

            int somenumber = default; //0
            int? somenumber02 = default; //null

            //bit shift
            //>> to right make half in size 1010 => 101
            //<< to left make double 1010 << 10100

            Console.WriteLine(0b_1010>>1);//5
            Console.WriteLine(0b_1010<<1);//20

        }
    }
}
