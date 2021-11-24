using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> gradeByStudents = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradeByStudents.ContainsKey(student))
                {
                    gradeByStudents.Add(student, new List<double>());
                }
                gradeByStudents[student].Add(grade);
                
            }
            Dictionary<string, List<double>> sortedStudents = gradeByStudents
                .Where(s => s.Value.Average() >= 4.50)
                .OrderByDescending(s => s.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():F2}");
            }
        }
    }
}
