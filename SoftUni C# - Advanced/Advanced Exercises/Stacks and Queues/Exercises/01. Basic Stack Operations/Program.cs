using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pushPopPeek = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbersStack = new Stack<int>(numbers);

            int toPop = pushPopPeek[1];
            int toPeek = pushPopPeek[2];

            for (int i = 0; i < toPop; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Contains(toPeek))
            {
                Console.WriteLine("true");
                return;
            }

            if (!numbersStack.Contains(toPeek) && numbersStack.Count != 0)
            {
                Console.WriteLine(numbersStack.Min());
                return;
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}