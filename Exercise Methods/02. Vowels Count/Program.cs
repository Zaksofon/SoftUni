using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int vowelsCount = GetTheVowelsCount(word);

            Console.WriteLine(vowelsCount);
        }

        private static int GetTheVowelsCount(string word)
        {
            int counter = 0;

            word = word.ToLower();

            foreach (var letter in word)
            {
                if (letter == 'a'||
                    letter == 'o'||
                    letter == 'u'||
                    letter == 'i'||
                    letter == 'y'||
                    letter == 'e')
                {
                    counter += 1;
                }
            }

            return counter;
        }
    }
}
