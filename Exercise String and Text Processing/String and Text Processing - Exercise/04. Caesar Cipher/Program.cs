using System;
using System.Linq;
using System.Text;

namespace _04.Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encodedText = new StringBuilder();

            foreach (var encryptedLetter in text.Select(letter => Convert.ToChar(letter + 3)))
            {
                encodedText.Append(encryptedLetter);
            }

            Console.WriteLine(encodedText);
        }
    }
}
