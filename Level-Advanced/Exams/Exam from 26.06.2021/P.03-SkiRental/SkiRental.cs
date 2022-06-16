using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skiCollection;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            skiCollection = new List<Ski>();
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Ski> SkiCollection => skiCollection;
        public int Count => skiCollection.Count;

        public void Add(Ski ski)
        {
            if (Capacity > skiCollection.Count)
            {
                skiCollection.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = skiCollection
                .Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .FirstOrDefault();

            if (ski != null)
            {
                skiCollection.Remove(ski);

                return true;
            }

            return false;
        }

        public Ski GetNewestSki() => skiCollection
            .OrderByDescending(x => x.Year)
            .FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) => skiCollection
            .FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in skiCollection)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
