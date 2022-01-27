using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.Simple_Text_Editor_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, string[]> text = new Dictionary<int, string[]>();

            text.Add(0, new []{string.Empty});

            for (int i = 1; i <= n; i++)
            {
                string line = Console.ReadLine();

                if (line == "4")
                {
                    text.Remove(text.Count - 1);
                    continue;
                }

                string[] parts = line
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                switch (command)
                {
                    case "1":
                        string[] toAdd = parts[1]
                            .Select(x => new string(x, 1))
                            .ToArray();
                        text.Add(i, toAdd);
                        break;

                    case "2":
                        int toRemove = Convert.ToInt32(parts[1]);
                        while (text[1].Length != 0)
                        {
                            
                        }
                        break;

                    case "3":
                        break;
                }
            }
        }
    }
}
