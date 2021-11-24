using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_1.Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Done")
                {
                    Console.WriteLine($"Your password is: {input}");
                    break;
                }
                string[] parts = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "TakeOdd":
                        input = string.Concat(input.Where((c, i) => i % 2 != 0));
                        Console.WriteLine(input);
                        break;
                    
                    case "Cut":
                        int index = int.Parse(parts[1]);
                        int length = int.Parse(parts[2]);
                        input = input.Remove(index, length);
                        Console.WriteLine(input);
                        break;
                    
                    case "Substitute":
                        string substring = parts[1];
                        string substitute = parts[2];

                        if (input.Contains(substring))
                        {
                            input = input.Replace(substring, substitute);
                            Console.WriteLine(input);
                            continue;
                        }
                        Console.WriteLine("Nothing to replace!");
                        break;
                }
            }
        }
    }
}
