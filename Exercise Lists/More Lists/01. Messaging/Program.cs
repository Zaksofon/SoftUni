using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Channels;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> code = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            string realMessage = " ";

            for (int i = 0; i < code.Count; i++)
            {
                int currentCode = code[i];

                int index = 0;

                for (int j = 0; j < currentCode; j++)
                {
                    index += currentCode % 10;
                    currentCode /= 10;
                }
                string currentChar = " ";

                for (int k = 0; k < text.Length; k++)
                {
                    if (index > text.Length)
                    {
                        index = index - text.Length;
                    }
                    currentChar = Convert.ToString(text[index]);
                    break;
                }

                text = text.Remove(index, 1);
                realMessage += currentChar;
            }

            Console.WriteLine(realMessage.TrimStart());
        }
    }
}
