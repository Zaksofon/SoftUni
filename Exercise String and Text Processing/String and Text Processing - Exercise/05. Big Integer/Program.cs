namespace MultiplyBigIntegers
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder bigInteger = new StringBuilder(Console.ReadLine());

            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            int inMind = 0;

            for (int i = bigInteger.Length - 1; i >= 0; i--)
            {
                int currentNum = int.Parse(bigInteger[i].ToString()) * multiplier + inMind;

                result.Insert(0, currentNum % 10);

                inMind = currentNum / 10;
            }

            var isInMindZero = inMind != 0 ? result.Insert(0, inMind) : null;

            while (result[0].ToString() == "0" && result.Length > 1)
            {
                result.Remove(0, 1);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
