using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> countByCourse = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> sortedCountByCourses = null;

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = parts[0];

                if (courseName == "end")
                {
                    foreach (var kvp in sortedCountByCourses)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                        kvp.Value.Sort();

                        foreach (var student in kvp.Value)
                        {
                            Console.WriteLine($"-- {student}");
                        }
                    }
                    return;
                }
                string studentName = parts[1];

                if (!countByCourse.ContainsKey(courseName))
                {
                    countByCourse.Add(courseName, new List<string>());
                }
                countByCourse[courseName].Add(studentName);

                sortedCountByCourses = countByCourse
                     .OrderByDescending(c => c.Value.Count)
                     .ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}
