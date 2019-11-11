using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : IIdentifiable,IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = food;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public string Group
        {
            get => group;
            set => group = value;
        }

        //unused
        public string Id { get; }
        public string Birthdate { get; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food = 5;
        }
    }
}
