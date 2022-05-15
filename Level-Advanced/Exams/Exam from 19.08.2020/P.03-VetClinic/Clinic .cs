using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> Pets { get; set; }
        public int Capacity { get; set; }

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Pets = new List<Pet>();
        }
        public int Count => this.Pets.Count;
        public void Add(Pet pet)
        {
            if (Pets.Count < this.Capacity)
            {
                Pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = Pets.Where(x => x.Name == name).FirstOrDefault();

            if (pet != null)
            {
                Pets.Remove(pet);
                return true;
            }

            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return Pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return Pets.OrderByDescending(x => x.Age).First();
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in Pets)
            {
                var toAppend = $"Pet {pet.Name} with owner: {pet.Owner}";
                sb.AppendLine(toAppend);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
