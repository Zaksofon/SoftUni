using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            GetTheMatrix(number);
        }

        private static void GetTheMatrix(int number)
        {
            for (int rows = 0; rows < number; rows++)
            {
                for (int colums = 0; colums < number; colums++)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}
