using System;

namespace lab_20_array
{
    class Program
    {
        static void Main(string[] args)
        {
            //1D Array
            int[] array01 = new int[10];
            int[] arrayLiteral = new int[] { 1, 2, 3, 4, 5 };

            //2D Array
            int[ , ] array2D = new int[10 , 10];

            //3D Array
            int[ , , ] array3D = new int[10, 10, 10];

            string arrayOut = "";

            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array2D[i, j] = (i*i) * (j*j);
                    sum += array2D[i, j];
                    arrayOut += $"{array2D[i, j]}, ";
                }

                arrayOut += $"\n";
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum += array2D[i, j];
                }
            }

            int sum3D = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++) { 

                        array3D[i, j, k] = i * i * j * j * k * k;

                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++) { 

                        sum3D += array3D[i, j, k];

                    }
                }
            }


            Console.WriteLine(sum3D);

            //Jagged Array
            int[][] myJaggedArray = new int[10][];

            myJaggedArray[0] = new int[5];
            myJaggedArray[1] = new int[] { 1, 2, 3 };

        }
    }
}
