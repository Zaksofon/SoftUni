using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> calcStack = new Queue<string>(input);
            int result = 0;

            while (calcStack.Count > 1)
            {
                int a = Convert.ToInt32(calcStack.Dequeue());
                string op = calcStack.Dequeue();
                int b = Convert.ToInt32(calcStack.Dequeue());

                if (op == "+")
                {
                    result += a + b;
                    continue;
                }

                result += a - b;

                if (calcStack.Peek() == "+" || calcStack.Peek() == "-")
                {
                    calcStack.Dequeue();
                }
            }

            Console.WriteLine(result);
        }
    }
}