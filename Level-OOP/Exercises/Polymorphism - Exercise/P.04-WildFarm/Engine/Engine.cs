namespace _8.Engine
{
    using System;
    using _8.Factories;
    using _8.Exceptions;
    using _8.IO.Interfaces;
    using _8.Engine.Interfaces;
    using _8.Models.Interfaces;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        //controller

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            var animalFactory = new AnimalFactory();
            var foodFactory = new FoodFactory();
            var animals = new List<IAnimal>();

            string animalInfo;
            while ((animalInfo = reader.ReadLine()) != "End")
            {
                IAnimal animal = null;
                IFood food = null;

                var animalInfoArgs = animalInfo.Split();
                string animalType = animalInfoArgs[0];
                string animalName = animalInfoArgs[1];
                double animalWeight = double.Parse(animalInfoArgs[2]);

                try
                {
                    animal = CreateAnimal(animalFactory, animal, animalInfoArgs,
                        animalType, animalName, animalWeight);

                    var foodInfo = reader.ReadLine().Split();
                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);
                    food = foodFactory.Create(foodQuantity, foodType);

                    writer.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal);
            }
        }

        private static IAnimal CreateAnimal(AnimalFactory animalFactory, IAnimal animal,
            string[] animalInfoArgs, string animalType, string animalName, double animalWeight)
        {
            if (animalInfoArgs.Length == 4)
            {
                string thirdParam = animalInfoArgs[3];

                animal = animalFactory.Create(animalType, animalName, animalWeight, thirdParam);
            }
            else if (animalInfoArgs.Length == 5)
            {

                string thirdParam = animalInfoArgs[3];
                string fourthParam = animalInfoArgs[4];

                animal = animalFactory.Create(animalType, animalName, animalWeight, thirdParam, fourthParam);
            }
            else
            {
                throw new ArgumentException(ExceptionMessage.InvalidAnimalType);
            }

            return animal;
        }
    }
}
