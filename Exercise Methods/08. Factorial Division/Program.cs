using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstInteger = Double.Parse(Console.ReadLine());
            double secondInteger = Double.Parse(Console.ReadLine());

            double first = GetFactorial(firstInteger);
            double second = GetFactorial(secondInteger);

            double result = first / second;
            Console.WriteLine($"{result:F2}");
        }

        private static double GetFactorial(double integer)
        {
            {
                double factorial = 1;

                for (double i = 2; i <= integer; i++)
                {
                    factorial = factorial * i;
                }

                return factorial;
            }
        }
    }
}
