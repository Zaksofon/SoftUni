using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();

            Person personTwo = new Person();
            personTwo.Age = 25;

            Person personThree = new Person();
            personThree.Name = "Pesho";
            personThree.Age = 30;
            ;
        }
    }
}