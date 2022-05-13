using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Ski { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Ski = new List<Ski>();
        }

        public int Count => Ski.Count;

        public void Add(Ski ski)
        {
            if (Ski.Count < Capacity)
            {
                Ski.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Ski.Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .FirstOrDefault();

            if (ski != null)
            {
                Ski.Remove(ski);

                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (Ski.Count == 0)
            {
                return null;
            }

            int newestYear = int.MinValue;
            Ski ski = null;

            foreach (var item in Ski)
            {
                if (item.Year > newestYear)
                {
                    newestYear = item.Year;
                    ski = item;
                }
            }

            return ski;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Ski.Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .FirstOrDefault();

            if (ski != null)
            {
                return ski;
            }

            return null;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var item in Ski)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
