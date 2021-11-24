using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string command = line[0];

                if (command == "3:1")
                {
                    break;
                }

                if (command == "merge")
                {
                    var startIndex = int.Parse(line[1]);
                    var endIndex = int.Parse(line[2]);

                    if (startIndex >= input.Count)
                    {
                        continue;
                    }
                    else if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= input.Count)
                    {
                        endIndex = input.Count - 1;
                    }
                    else if (endIndex <= 0)
                    {
                        continue;
                    }

                    string merged = " ";

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        merged += input[i];
                    }

                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, merged);
                }
                else
                {
                    int index = int.Parse(line[1]);
                    int partitions = int.Parse(line[2]);

                    string element = input[index];
                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);

                    input.InsertRange(index, substrings);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
