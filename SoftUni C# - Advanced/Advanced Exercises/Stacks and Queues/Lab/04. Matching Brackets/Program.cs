using System;
using System.Collections.Generic;

namespace _4.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            string result = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = Convert.ToChar(input[i]);

                switch (currentSymbol)
                {
                    case '(':
                        indexes.Push(i);
                        break;

                    case ')':
                    {
                        int index = indexes.Pop();

                        result = input.Substring(index, i - index + 1);
                        Console.WriteLine(result);
                        break;
                    }
                }
            }
        }
    }
}