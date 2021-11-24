using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pathToFile = Console.ReadLine()
                .Split(new []{"\\"}, StringSplitOptions.RemoveEmptyEntries)
                .Last()
                .Split(new []{"."}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine($"File name: {pathToFile[0]}");
            Console.WriteLine($"File extension: {pathToFile[1]}");
        }
    }
}
