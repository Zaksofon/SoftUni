using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _08.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
            .Select(x => new string(x, 1))
            .ToArray();

            Queue<char> parenthesesQueue = new Queue<char>();
            Stack<char> parenthesesStack = new Stack<char>();

            foreach (var symbol in input)
            {
                char currentInputSymbol = Convert.ToChar(symbol);

                switch (currentInputSymbol)
                {
                    case '(':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push(')');
                        break;

                    case ')':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push('(');
                        break;

                    case '[':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push(']');
                        break;

                    case ']':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push('[');
                        break;

                    case '{':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push('}');
                        break;

                    case '}':
                        parenthesesQueue.Enqueue(currentInputSymbol);
                        parenthesesStack.Push('{');
                        break;

                    default:
                        Console.WriteLine("NO");
                        return;
                }
            }

            int originalParenthesesCount = input.Length;
            int counter = 0;

            while (parenthesesQueue.Count != 0)
            {
                if (parenthesesQueue.Dequeue() == parenthesesStack.Pop())
                {
                    counter++;
                }
            }

            if (counter == originalParenthesesCount)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
