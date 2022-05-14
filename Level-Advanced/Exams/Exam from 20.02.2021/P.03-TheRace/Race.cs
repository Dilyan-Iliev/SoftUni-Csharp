using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Racers { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity; //the maximum allowed number of racers
            this.Racers = new List<Racer>();
        }
        public int Count => this.Racers.Count;
        public void Add(Racer racer)
        {
            if (Racers.Count < this.Capacity)
            {
                Racers.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer racer = Racers.Where(x => x.Name == name).FirstOrDefault();

            if (racer != null)
            {
                Racers.Remove(racer);
                return true;
            }

            return false;
        }
        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(x => x.Age).First();

            //    int maxAge = int.MinValue;
            //    Racer racer = null;

            //    foreach (var item in Racers)
            //    {
            //        if (item.Age > maxAge)
            //        {
            //            maxAge = item.Age;
            //            racer = item;
            //        }
            //    }

            //    return racer;
        }
        public Racer GetRacer(string name)
        {
            Racer racer = Racers.Where(x => x.Name == name).FirstOrDefault();

            if (racer != null)
            {
                return racer;
            }
            return null;
        }
        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(x => x.Car.Speed).First();

            //int maxSpeed = int.MinValue;
            //Racer racer = null;

            //foreach (var item in Racers)
            //{
            //    if (item.Car.Speed > maxSpeed)
            //    {
            //        maxSpeed = item.Car.Speed;
            //        racer = item;
            //    }
            //}
            //return racer;
        }
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var item in Racers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
