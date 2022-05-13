using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public Dictionary<string, Car> Participants { get; set; }
        public string Name { get; set; } 
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; } //the maximum allowed number of participants in the race
        public int MaxHorsePower { get; set; } //the maximum allowed Horse Power of a Car in the Race

        public Race(string name, string type, int laps, int capacity, int maxHorsePower) 
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new Dictionary<string, Car>();
        }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate)
                && Participants.Count < Capacity
                && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = Participants[licensePlate];
            
            //Participants[licensePlate].LicensePlate 
            
            if(car.LicensePlate == licensePlate)
            {
                Participants.Remove(licensePlate);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = Participants[licensePlate];

            if (car.LicensePlate == licensePlate)
            {
                return car;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }

            int maxHP = int.MinValue;
            Car car = null;

            foreach (var item in Participants.Values)
            {
                if (item.HorsePower > maxHP)
                {
                    maxHP = item.HorsePower;
                    car = item;
                }
            }

            return car;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var item in Participants.Values)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
