using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DefiningClasses;

namespace DefiningClass
{
    public class Family
    {
        public List<Person> Members { get; set; }

        public Family()
        {
            Members = new List<Person>();
        }

        public void AddFamilyMember(Person person)
        {
            this.Members.Add(person);
        }

        public Person GetOldestMember()
        {
            Person person = this.Members
                .OrderByDescending(p => p.Age)
                .First();

            return person;
        }
    }
}