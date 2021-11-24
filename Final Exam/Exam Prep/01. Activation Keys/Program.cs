using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem_1.Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                List<string> parts = new List<string>(Console.ReadLine()
                    .Split(new[] {">>>"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList());

                string command = parts[0];

                if (command == "Generate")
                {
                    Console.WriteLine($"Your activation key is: {activationKey}");
                    break;
                }

                switch (command)
                {
                    case "Contains":
                        string substring = parts[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                            continue;
                        }
                        Console.WriteLine($"Substring not found!");
                        break;

                    case "Flip":
                        string letterCase = parts[1];
                        int startIndex = Convert.ToInt32(parts[2]);
                        int endIndex = Convert.ToInt32(parts[3]);

                        string substringToReplace = activationKey.Substring(startIndex, endIndex - startIndex);

                        if (letterCase == "Upper")
                        {
                            activationKey = activationKey.Replace(substringToReplace, substringToReplace.ToUpper());
                            Console.WriteLine(activationKey);
                            continue;
                        }
                        activationKey = activationKey.Replace(substringToReplace, substringToReplace.ToLower());
                        Console.WriteLine(activationKey);
                        break;

                    case "Slice":
                        int startIndexSlice = Convert.ToInt32(parts[1]);
                        int endIndexSlice = Convert.ToInt32(parts[2]);
                        activationKey = activationKey.Remove(startIndexSlice, endIndexSlice - startIndexSlice);
                        Console.WriteLine(activationKey);
                        break;
                }
            }
        }
    }
}
