using System;

namespace do_it_03_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[10,10];

            string[,] words = new string[10,10];

            int[,] twoGrid = new int[10, 10];

            int[, ,] threeGrid = new int[5, 5, 5];

            string arrayout = "";

            for (int i = 0; i<10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    twoGrid[i, j] = j + ( 10 * i );
                    //arrayout += $"{twoGrid[i, j]:D2}, ";
                }
                //arrayout += "\n";
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++) {

                        threeGrid[i, j, k] = k + ( j * 5 ) + (5 * (5*i));
                        arrayout += $"{threeGrid[i, j, k]:D2}, ";
                    }
                    arrayout += "\n";
                }
                arrayout += "\n";
            }

            //foreach(int x in twoGrid)
            //{
            //    Console.WriteLine(x.ToString());
            //}

            Console.WriteLine(arrayout);
        }
    }
}
