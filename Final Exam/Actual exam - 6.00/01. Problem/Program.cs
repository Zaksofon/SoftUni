using System;
using System.Linq;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Sign up")
                {
                    break;
                }

                string[] parts = line
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                switch (command)
                {
                    case "Case":
                        string lowerUpper = parts[1];

                        if (lowerUpper == "upper")
                        {
                            username = username.ToUpper();
                            Console.WriteLine(username);
                            continue;
                        }
                        username = username.ToLower();
                        Console.WriteLine(username);
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(parts[1]);
                        int endIndex = int.Parse(parts[2]);

                        if (startIndex >= 0 && endIndex <= username.Length)
                        {
                            string substringToReverse = username.Substring(startIndex, (endIndex + 1) - startIndex);
                            var myReversedString = new string(substringToReverse.Reverse().ToArray());
                            Console.WriteLine(string.Concat(myReversedString));
                        }
                        break;

                    case "Cut":
                        string substringToCut = parts[1];

                        if (username.Contains(substringToCut))
                        {
                            username = username.Replace(substringToCut, "");
                            Console.WriteLine(username);
                            continue;
                        }
                        Console.WriteLine($"The word {username} doesn't contain {substringToCut}.");
                        break;

                    case "Replace":
                        char charReplacement = char.Parse(parts[1]);

                            if (username.Contains(charReplacement))
                            {
                                username = username.Replace(charReplacement, '*');
                            }
                        
                        Console.WriteLine(username);
                        break;

                    case "Check":
                        char includedChar = char.Parse(parts[1]);

                        if (username.Contains(includedChar))
                        {
                            Console.WriteLine("Valid");
                            continue;
                        }

                        Console.WriteLine($"Your username must contain {includedChar}.");
                        break;
                }
            }
        }
    }
}
