using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<int> sets = new List<int>();

            while (hats.Count > 0 || scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();
                int currentSet = 0;

                if (currentHat > currentScarf)
                {
                    hats.Pop();
                    scarfs.Dequeue();
                    currentSet += currentHat + currentScarf;
                    sets.Add(currentSet);
                }

                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                }

                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    int lastHat = hats.Pop();
                    hats.Push(lastHat + 1);
                }

                if (hats.Count == 0 || scarfs.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.Write(string.Join(" ", sets));
            Console.WriteLine();
        }
    }
}
