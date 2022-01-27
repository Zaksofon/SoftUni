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
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            
            Stack<string> calcStack = new Stack<string>(input);

            while (calcStack.Count > 1)
            {
                int a = Convert.ToInt32(calcStack.Pop());
                string op = calcStack.Pop();
                int b = Convert.ToInt32(calcStack.Pop());


                int result;
                if (op == "+")
                {
                    result = a + b;
                    calcStack.Push(Convert.ToString(result));
                    continue;
                }

                result = a - b;
                calcStack.Push(Convert.ToString(result));
            }

            Console.WriteLine(calcStack.Peek());
        }
    }
}
