using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;
        public string Material { get; set; }    
        public int Capacity { get; set; }

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType)
                || fish.Length <= 0
                || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            bool release = Fish.FirstOrDefault(x => x.Weight == weight) != null;

            if (release)
            {
                Fish fish = Fish.Where(x => x.Weight == weight).First();
                Fish.Remove(fish);

                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.FirstOrDefault(x => x.FishType == fishType);

            if (fish != null)
            {
                return fish;
            }
            else
            {
                return null;
            }
        }

        public Fish GetBiggestFish()
        {
            double longestFish = double.MinValue;
            Fish fish = null;

            foreach (var item in Fish)
            {
                if (item.Length > longestFish)
                {
                    longestFish = item.Length;
                    fish = item;
                }
            }
            return fish;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
