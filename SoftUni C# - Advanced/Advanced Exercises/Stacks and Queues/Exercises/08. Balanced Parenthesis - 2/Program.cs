using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            char[] brackets = { '(', '{', '[' };
            char[] input = Console.ReadLine().ToCharArray();
            bool valid = true;

            foreach (var bracket in input)
            {
                if (brackets.Contains(bracket))
                {
                    stack.Push(bracket);
                    continue;
                }
                if (stack.Count == 0)
                {
                    valid = false;
                    break;
                }
                if (stack.Peek() == '(' && bracket == ')')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '[' && bracket == ']')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && bracket == '}')
                {
                    stack.Pop();
                }
                else
                {

                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}