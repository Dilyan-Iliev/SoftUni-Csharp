using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            racers = new List<Racer>();
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Racer> Racers => racers.AsReadOnly();
        public int Count => racers.Count;

        public void Add(Racer racer)
        {
            if (Capacity > racers.Count)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = racers.Where(x => x.Name == name).FirstOrDefault();

            if (racer != null)
            {
                racers.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer() => racers.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name) => racers.Where(x => x.Name == name).FirstOrDefault();

        public Racer GetFastestRacer() => racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
