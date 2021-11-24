using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Exam_preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                List<string> parts = new List<string>(Console.ReadLine()
                    .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries));

                string command = parts[0];

                if (command == "Decode")
                {
                    break;
                }

                switch (command)
                {
                    case "Move":
                        int lettersToBeMoved = int.Parse(parts[1]);
                        string lettersToAdd = input.Substring(0,lettersToBeMoved);
                        string lettersLeft = input.Substring(lettersToBeMoved);
                        input = lettersLeft + lettersToAdd;
                        break;
                    case "Insert":
                        int index = int.Parse(parts[1]);
                        string value = parts[2];
                        input = input.Insert(index, value);
                        break;
                    case "ChangeAll":
                        char oldChar = char.Parse(parts[1]);
                        char newChar = char.Parse(parts[2]);
                        input = input.Replace(oldChar, newChar);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}