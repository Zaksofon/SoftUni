using System;
using System.Collections.Generic;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playList = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> playListQueue = new Queue<string>(playList);
            string song = "";

            while (playListQueue.Count != 0)
            {
                string command = Console.ReadLine();

                if (command.Contains(" "))
                {
                     song = command.Remove(0, 4);
                     command = command.Substring(0, 3);
                }

                switch (command)
                {
                    case "Play":
                        playListQueue.Dequeue();
                        break;

                    case "Add":
                        if (playListQueue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            break;
                        }
                        playListQueue.Enqueue(song);
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", playListQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
