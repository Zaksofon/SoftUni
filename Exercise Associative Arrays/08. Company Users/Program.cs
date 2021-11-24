using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> idByCompany = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string company = parts[0];

                if (company == "End")
                {
                    foreach (var kvp in idByCompany)
                    {
                        Console.WriteLine($"{kvp.Key}");

                        List<string> sortedEmployees = kvp.Value
                            .Distinct()
                            .ToList();

                        foreach (var employee in sortedEmployees)
                        {
                            Console.WriteLine($"-- {employee}");
                        }
                    }
                    break;
                }
                string id = parts[1];

                if (!idByCompany.ContainsKey(company))
                {
                    idByCompany.Add(company, new List<string>());
                }
                idByCompany[company].Add(id);
            }
        }
    }
}
