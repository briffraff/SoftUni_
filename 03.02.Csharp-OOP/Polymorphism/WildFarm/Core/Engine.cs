using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using WildFarm.Animals;
using WildFarm.Animals.Birds.Factory;
using WildFarm.Animals.Birds.Interfaces;
using WildFarm.Animals.Interfaces;
using WildFarm.Animals.Mammals.Factory;
using WildFarm.Animals.Mammals.Feline;
using WildFarm.Animals.Mammals.Feline.Factory;
using WildFarm.Foods;
using WildFarm.Foods.Factory;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Core
{
    public class Engine
    {
        private MammalFactory mammalFactory;
        private BirdFactory birdFactory;
        private FelineFactory felineFactory;
        private FoodFactory foodFactory;
        private Animal animal;
        private List<Animal> animals;

        public Engine()
        {
            this.mammalFactory = new MammalFactory();
            this.birdFactory = new BirdFactory();
            this.felineFactory = new FelineFactory();
            this.foodFactory = new FoodFactory();

            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalInfoSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string animalType = animalInfoSplit[0].ToLower();
                    string animalName = animalInfoSplit[1];
                    double animalWeight = double.Parse(animalInfoSplit[2]);

                    string[] foodInfoSplit = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (animalType == "hen" || animalType == "owl")
                    {
                        double animalWingSize = double.Parse(animalInfoSplit[3]);

                        animal = this.birdFactory.CreateBird(animalType, animalName, animalWeight, animalWingSize);
                    }
                    else if (animalType == "cat" || animalType == "tiger")
                    {
                        string animalLivingRegion = animalInfoSplit[3];
                        string animalBreed = animalInfoSplit[4];

                        animal = this.felineFactory
                            .CreateFeline(animalType, animalName, animalWeight, animalLivingRegion, animalBreed);

                    }
                    else if (animalType == "dog" || animalType == "mouse")
                    {
                        string animalLivingRegion = animalInfoSplit[3];

                        animal = this.mammalFactory
                            .CreateMammal(animalType, animalName, animalWeight, animalLivingRegion);
                    }

                    animal.ProduceSound();

                    if (foodInfoSplit.Length == 2)
                    {
                        string foodType = foodInfoSplit[0];
                        int foodQuantity = int.Parse(foodInfoSplit[1]);

                        IFood food = foodFactory.CreateFood(foodType, foodQuantity);

                        animal.Eat(food);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
