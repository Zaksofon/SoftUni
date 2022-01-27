using System;
using System.Collections.Generic;

namespace Lab_Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charStack = new Stack<char>();
            string input = Console.ReadLine();

            foreach (var t in input)
            {
                charStack.Push(t);
            }

            while (charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }

            Console.WriteLine();
        }
    }
}