using System;
using AnimalFarm.Exceptions;
using System.Collections.Generic;

namespace AnimalFarm
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new InvalidInputException();
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidInputException();
                }
                age = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new InvalidInputException();
                }
                gender = value;

            }
        }

        public string ProduceSound(string type)
        {
            string sound = "";
            var animalSounds = new Dictionary<string, string>();

            animalSounds.Add("Dog", "Woof!");
            animalSounds.Add("Cat", "Meow meow");
            animalSounds.Add("Frog", "Ribbit");
            animalSounds.Add("Kittens", "Meow");
            animalSounds.Add("Tomcat", "MEOW");

            if (animalSounds.ContainsKey(type))
            {
                sound = animalSounds[type];
            }

            return sound;

        }

    }
}
