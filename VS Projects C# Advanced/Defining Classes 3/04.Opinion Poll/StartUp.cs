using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> members = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = line[0];
                int age = int.Parse(line[1]);

                Person currPerson = new Person(name, age);
                members.Add(currPerson);
            }

            members = members
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var person in members)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
