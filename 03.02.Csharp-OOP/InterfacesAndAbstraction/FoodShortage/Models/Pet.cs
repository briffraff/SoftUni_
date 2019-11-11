using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Interfaces;

namespace FoodShortage
{
    public class Pet : IIdentifiable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public string Birthdate
        {
            get => birthdate;
            private set => birthdate = value;
        }

        //unused properties
        public string Id => "";
    }
}
