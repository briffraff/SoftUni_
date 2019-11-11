using System;

    class Program
    {
        static void Main(string[] args)
        {

            Person personOne = new Person
            {
                Name = "Gosho",
                Age = 20
            };

            var personTwo = new Person();
            personTwo.Name = "Gosho";
            personTwo.Age = 18;

            var person3 = new Person
            {
                Name = "Stamat",
                Age = 43
            };
        }
    }

