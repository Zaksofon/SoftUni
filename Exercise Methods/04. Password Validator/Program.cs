using System;
using System.Diagnostics.Tracing;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = true;

            if (!HasValidLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!HasValidCharecters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!ContainsTwoDigits(password, 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ContainsTwoDigits(string password, int count)
        {
            int digitCounter = 0;

            foreach (var character in password)
            {
                if (char.IsDigit(character))
                {
                    digitCounter += 1;

                    if (digitCounter >= 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasValidCharecters(string password)
        {
            foreach (var character in password)
            {
                if (!char.IsLetterOrDigit(character))
                {
                   return false;
                }
            }

            return true;
        }

        private static bool HasValidLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}
