using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> pets;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>();
        }
        public int Capacity { get; private set; }
        public IReadOnlyList<Pet> Pets => pets.AsReadOnly();
        public int Count => this.pets.Count;

        public void Add(Pet pet)
        {
            if (this.Capacity > pets.Count)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.Where(x => x.Name == name).FirstOrDefault();

            if (pet != null)
            {
                this.pets.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner) => pets
            .Where(x => x.Name == name && x.Owner == owner)
            .FirstOrDefault();

        public Pet GetOldestPet() => pets
            .OrderByDescending(x => x.Age)
            .First();

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
