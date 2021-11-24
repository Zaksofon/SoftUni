using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade :F2}";
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IList<Student> students = new List<Student>();
            Student student = null;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            IList<Student> sortedStudents = students.OrderByDescending(g => g.Grade).ToList();

            foreach (var name in sortedStudents)
            {
                Console.WriteLine(name);
            }
        }
    }
}
