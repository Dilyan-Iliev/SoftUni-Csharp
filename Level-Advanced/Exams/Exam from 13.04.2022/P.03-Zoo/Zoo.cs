using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

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

            if (Animals.Count >= this.Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var removedAnimals = Animals.FindAll(animal => animal.Species == species).ToList();
            Animals.RemoveAll(x => x.Species == species);

            return removedAnimals.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var filteredByDietAnimals = Animals.FindAll(x => x.Diet == diet);

            return filteredByDietAnimals.ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var filteredAnimalsByLength = Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength).ToList();

            return $"There are {filteredAnimalsByLength.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
