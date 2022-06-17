using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            if (!HasElementInCollection())
            {
                return 0;
            }

            var animalsToRemove = Animals.Where(x => x.Species == species).ToList();

            Animals.RemoveAll(x => x.Species == species);

            return animalsToRemove.Count();
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            if (!HasElementInCollection())
            {
                return null;
            }

            return Animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight) => Animals
            .Where(x => x.Weight == weight)
            .FirstOrDefault();

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var searchedAnimals = Animals
                .Where(x => x.Length >= minimumLength && x.Length <= maximumLength)
                .ToList();

            return $"There are {searchedAnimals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }


        private bool HasElementInCollection()
        {
            if (!Animals.Any())
            {
                return false;
            }

            return true;
        }
    }
}
