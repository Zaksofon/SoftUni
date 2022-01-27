using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunMagazineSize = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bullets = new Stack<int>(bulletsInput);

            int[] locksInput = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> locks = new Queue<int>(locksInput);

            int reward = int.Parse(Console.ReadLine());

            int loops = Math.Max(bulletsInput.Length, locksInput.Length);
            int costs = 0;
            while (true)
            {
                for (int i = 0; i < loops; i++)
                {
                    if (locks.Count == 0 && bullets.Count == 0)
                    {
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${reward - costs}");
                        return;
                    }

                    if (bullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }

                    if (i % gunMagazineSize == 0 && i != 0)
                    {
                        Console.WriteLine("Reloading!");
                        break;
                    }

                    if (locks.Count == 0)
                    {
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${reward - costs}");
                        return;
                    }

                    if (bullets.Peek() <= locks.Peek())
                    {
                        locks.Dequeue();
                        bullets.Pop();
                        Console.WriteLine("Bang!");
                        costs += bulletPrice;
                    }

                    else
                    {
                        bullets.Pop();
                        Console.WriteLine("Ping!");
                        costs += bulletPrice;
                    }
                }
            }
        }
    }
}
