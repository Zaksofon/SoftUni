using System;
using System.Collections.Generic;

namespace _07.String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> postExplosionInputOrder = new List<string>();

            char bomb = '>';
            int bombPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == bomb)
                {
                    postExplosionInputOrder.Add(Convert.ToString(symbol));
                    bombPower += input[i + 1] - '0';
                }

                else if (bombPower > 0)
                {
                    bombPower -= 1;
                }

                else
                {
                    postExplosionInputOrder.Add(Convert.ToString(symbol));
                }
            }

            Console.WriteLine(string.Concat(postExplosionInputOrder));
        }
    }
}
