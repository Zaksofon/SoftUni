using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentThread >= currentTask && tasks.Peek() != taskToBeKilled)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                else if (currentThread < currentTask && tasks.Peek() != taskToBeKilled)
                {
                    threads.Dequeue();
                }

                else if (tasks.Peek() == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToBeKilled}");
                    Console.WriteLine(string.Join(" ", threads));
                    break;
                }
            }
        }
    }
}
