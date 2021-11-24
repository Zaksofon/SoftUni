namespace _1._ExtractPersonInformation
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args) 
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match name = Regex.Match(input, @"@(?<name>\w+)\|");

                Match age = Regex.Match(input, @"#(?<age>\d+)\*");

                Console.WriteLine($"{name.Groups["name"]} is {age.Groups["age"]} years old.");
            }
        }
    }
}
