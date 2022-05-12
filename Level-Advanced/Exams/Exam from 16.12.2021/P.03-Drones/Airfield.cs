using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name)
                || string.IsNullOrEmpty(drone.Brand)
                || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            if (Drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            bool result = Drones.FirstOrDefault(x => x.Name == name) != null;

            if (result)
            {
                Drone drone = Drones.Where(x => x.Name == name).First();
                Drones.Remove(drone);

                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var filteredDronesByBrand = Drones.FindAll(x => x.Brand == brand).ToList();

            if (filteredDronesByBrand.Any()) // > 0
            {
                Drones.RemoveAll(x => x.Brand == brand);

                return filteredDronesByBrand.Count;
            }

            return 0;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = null;

            if (Drones.Any(x => x.Name == name))
            {
                drone = Drones.Where(x => x.Name == name).First();
                drone.Available = false;

                return drone;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var filteredFlyDrones = Drones.FindAll(x => x.Range >= range).ToList();

            foreach (var drone in filteredFlyDrones)
            {
                drone.Available = false;
            }

            return filteredFlyDrones;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
