using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double costs = double.Parse(Console.ReadLine());

            int collectingPeriod = int.Parse(Console.ReadLine());

            double totalSavings = 0;

            for (int i = 1; i <= collectingPeriod; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    totalSavings -= totalSavings * 0.16;
                }

                if (i % 4 == 0)
                {
                    totalSavings += totalSavings * 0.25;
                }

                double monthlySavings = costs * 0.25;
                totalSavings += monthlySavings;
            }

            Console.WriteLine(totalSavings >= costs
                ? $"Bravo! You can go to Disneyland and you will have {totalSavings - costs:F2}lv. for souvenirs."
                : $"Sorry. You need {costs - totalSavings:F2}lv. more.");
        }
    }
}
