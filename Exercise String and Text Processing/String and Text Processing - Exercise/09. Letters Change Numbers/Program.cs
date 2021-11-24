using System;

namespace _08.Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

            double result = 0;

            foreach (var word in input)
            {
                char firstLetter = word[0];
                char lastLetter = word[word.Length - 1];
                double number = double.Parse(word.Substring(1, word.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    number /= (firstLetter - 64);
                }

                else if (char.IsLower(firstLetter))
                {
                    number *= (firstLetter - 96);
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= (lastLetter - 64);
                }

                else if (char.IsLower(lastLetter))
                { 
                    number += (lastLetter - 96);
                }

                result += number;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
