using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _03.The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string piece = Convert.ToString(input[0]);
                string composer = Convert.ToString(input[1]);
                string key = Convert.ToString(input[2]);

                pieces.Add(piece, new []{composer, key});
            }

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                if (command == "Stop")
                {
                    break;
                }
                string piece = parts[1];

                switch (command)
                {
                    case "Add":
                        string composer = parts[2];
                        string key = parts[3];
                        if (pieces.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                            continue;
                        }
                        pieces.Add(piece, new []{composer, key});
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        break;
                    case "Remove":
                        if (pieces.ContainsKey(piece))
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                            continue;
                        }
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                    case "ChangeKey":
                        string newKey = parts[2];
                        if (pieces.ContainsKey(piece))
                        {
                            pieces[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                            continue;
                        }
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                }
            }
            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value[0])
                .ToDictionary(x => x.Key, k => k.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
