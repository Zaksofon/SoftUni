using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = line[0];

                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    return;
                }

                if (command == "Delete")
                {
                    numbers.RemoveAll(n => n == Convert.ToInt32((line[1])));
                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    if (numbers[i] == Convert.ToInt32(line[1]))
                    //    {
                    //        numbers.Remove(numbers[i]);
                    //        break;
                    //    }
                    //}
                }

                else if (command == "Insert")
                {
                    numbers.Insert(int.Parse(line[2]), int.Parse(line[1]));
                }
            }
        }
    }
}
