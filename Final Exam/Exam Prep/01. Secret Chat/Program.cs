using System;
using System.Linq;
using System.Text;

namespace Problem_1.Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Reveal")
                {
                    Console.WriteLine($"You have a new text message: {input}");
                    break;
                }
                string[] parts = line.Split(new[] { ":|:" }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(parts[1]);
                        input = input.Insert(index, " ");
                        Console.WriteLine(input);
                        break;

                    case "Reverse":
                        string substring = parts[1];

                        if (input.Contains(substring))
                        {
                            string reversedSubstring = new string(substring.Reverse().ToArray());

                            input = input.Remove(input.IndexOf(substring), substring.Length);
                            input += reversedSubstring;

                            Console.WriteLine(input);
                            continue;
                        }
                        Console.WriteLine("error");
                        break;

                    case "ChangeAll":
                        string substringToReplace = parts[1];
                        string replacement = parts[2];

                        if (input.Contains(substringToReplace))
                        {
                            input = input.Replace(substringToReplace, replacement);
                            Console.WriteLine(input);
                           
                        }
                        break;
                }
            }
        }
    }
}

