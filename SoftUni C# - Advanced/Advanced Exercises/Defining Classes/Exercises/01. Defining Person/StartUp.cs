using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();
            personOne.Name = "Pesho";
            personOne.Age = 24;

            Person personTwo = new Person()
            {
                Name = "Gosho",
                Age = 25
            };
        }
    }
}
