using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_2.Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(@#+)([A-Z][A-Za-z\d]{4,}[A-Z])\1";

            Regex barcode = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match validBarcode = barcode.Match(input);

                if (validBarcode.Success)
                {
                    string result = validBarcode.Groups[2].Value;

                    string num = new String(result.Where(Char.IsDigit).ToArray());

                    if (num == "")
                    {
                        num = "00";
                    }

                    Console.WriteLine($"Product group: {num}");
                    continue;
                }

                Console.WriteLine("Invalid barcode");
            }
        }
    }
}
