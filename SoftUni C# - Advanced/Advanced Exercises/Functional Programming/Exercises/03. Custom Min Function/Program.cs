using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Min();

            Console.WriteLine(numbers);
        }
    }
}
