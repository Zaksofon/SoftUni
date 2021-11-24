using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firsInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            int sumFirstAndSecondInt = GetSumFirstAndSecondInteger(firsInt, secondInt);

            int subtractionSumAndThirdInt = GetResultSubtraction(sumFirstAndSecondInt, thirdInt);

            Console.WriteLine(subtractionSumAndThirdInt);
        }

        private static int GetResultSubtraction(int sumFirstAndSecondInt, int thirdInt)
        {
            int subtraction = sumFirstAndSecondInt - thirdInt;

            return subtraction;
        }

        private static int GetSumFirstAndSecondInteger(int firsInt, int secondInt)
        {
            int sum = firsInt + secondInt;

            return sum;
        }
    }
}
