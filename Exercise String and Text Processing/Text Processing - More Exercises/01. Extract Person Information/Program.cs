using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> line = new List<string>(Regex.Split(Console.ReadLine(), @"\s+")
                        .ToList());

                string name = "";
                string age = "";

                foreach (var word in line.Where(word => word.Contains('@') || word.Contains('#')))
                {
                    if (word.Contains('@'))
                    {
                        name = word.Substring(word.IndexOf('@') + 1, word.IndexOf('|') - (word.IndexOf('@') + 1));
                    }

                    if (word.Contains('#'))
                    {
                        age = word.Substring(word.IndexOf('#') + 1, word.IndexOf('*') - (word.IndexOf('#') + 1));
                    }
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
