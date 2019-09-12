using System;
using System.IO;

namespace lab_26_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ERROR
            //Bank calculates your interest correctly : programmer error in logic
            //EXCEPTION
            //code crashes so program cannot continue

            // handled      exception takes place inside a TRYBLOCK, and code is handled in the CATCH BLOCK
            //then whether error or not run the finally block.
            // unhandled    // messy error, messy exception program terminates
            // compiler     // REd LINE IE WILL NOT BUILD
            // runtime      // EG divide by zero

            int x = 10;
            int y = 0;
           // Console.WriteLine(x/y); unhandled
            try
            {
                //Try any code which might produce an exception
                Console.WriteLine(x/y);
            }
            catch(Exception e)
            {
                Console.WriteLine("Hey, don't do that!" + e.Message);
            }
            finally
            {
                Console.WriteLine("have fun");
            }

            //Custom exception
            var myException = new Exception("Hey this is a Aly Special");
            try
            {
                //Imagine engine is getting hot but has not burnt out yet
                throw (myException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //LARGE APPLICATION
            //NESTING : MAIN, SUB, SUB

            try
            {
                try
                {
                    try
                    {
                        throw (new Exception("Inner Exception - Alys Code"));
                    }
                    catch(Exception e){
                        throw;
                    }
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.WriteAllText("log.txt", $"Phils code not working again - Typical - {e.Message}");
            }

            //Types of exceptions

            try { }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("dont do that");
            }
            catch (Exception e)
            {
                Console.WriteLine("all exceptions");
            }

        }
    }
}
