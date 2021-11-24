using System;
using System.Text;

namespace _06.Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char letter = '\0';

            StringBuilder sb = new StringBuilder();

            foreach (var symbol in input)
            {
                if (letter != symbol)
                {
                    sb.Append(symbol);
                    letter = symbol;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
