using System;
using System.ComponentModel;

namespace Exercise_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallest = int.MaxValue; 

            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < smallest)
                {
                    smallest = number;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
