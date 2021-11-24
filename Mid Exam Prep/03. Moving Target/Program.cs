using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Programming_Fundamentals_Mid_Exam_Retake____03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            while (true)
            {
                string[] parts = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "End")
                {
                    Console.WriteLine(string.Join("|", targets));
                    return;
                }

                int index = int.Parse(parts[1]);
                int value = int.Parse(parts[2]);

                switch (command)
                {
                    case "Shoot" when index <= targets.Count - 1 && index >= 0:
                    {
                        targets[index] -= value;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }

                        break;
                    }
                    case "Add" when index <= targets.Count - 1 && index >= 0:
                        targets.Insert(index, value);
                        continue;
                    case "Add":
                        Console.WriteLine("Invalid placement!");
                        break;
                    case "Strike" when index + value <= targets.Count - 1 && index - value >= 0:
                        targets.RemoveRange(index - value, value * 2 + 1);
                        continue;
                    case "Strike":
                        Console.WriteLine("Strike missed!");
                        break;
                }
            }
        }
    }
}
