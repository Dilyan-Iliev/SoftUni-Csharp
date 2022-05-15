using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public List<Car> Cars { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }
        public int Count => this.Cars.Count;
        public void Add(Car car)
        {
            if (Cars.Count < this.Capacity)
            {
                Cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = Cars.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();

            if (car != null)
            {
                Cars.Remove(car);
                return true;
            }

            return false;
        }
        public Car GetLatestCar()
        {
            return Cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return Cars.Where(x => x.Manufacturer == manufacturer && x.Model==model).FirstOrDefault();  
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in Cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
