using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "END")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    return;
                }

                switch (command)
                {
                    case "Change" when numbers.Contains(int.Parse(parts[1])):
                        int newNumber = int.Parse(parts[2]);
                        int numberToBeChanged = numbers.IndexOf(int.Parse(parts[1]));
                        numbers.RemoveAt(numberToBeChanged);
                        numbers.Insert(numberToBeChanged, newNumber);
                        break;

                    case "Hide" when numbers.Contains(int.Parse(parts[1])):
                        numbers.RemoveAt(numbers.IndexOf(int.Parse(parts[1])));
                        break;

                    case "Switch" when numbers.Contains(int.Parse(parts[1])) && numbers.Contains(int.Parse(parts[2])):
                        int firsNumber = int.Parse(parts[1]);
                        int firstNumberIndex = numbers.IndexOf(firsNumber);
                        int secondNumber = int.Parse(parts[2]);
                        int secondNumberIndex = numbers.IndexOf(secondNumber);
                        numbers.RemoveAt(firstNumberIndex);
                        numbers.Insert(firstNumberIndex, secondNumber);
                        numbers.RemoveAt(secondNumberIndex);
                        numbers.Insert(secondNumberIndex, firsNumber);
                        break;

                    case "Insert" when int.Parse(parts[1]) >= 0 && int.Parse(parts[1]) <= numbers.Count - 1:
                        numbers.Insert(int.Parse(parts[1]) + 1, int.Parse(parts[2]));
                        break;

                    case "Reverse":
                        numbers.Reverse();
                        break;
                }
            }
        }
    }
}
