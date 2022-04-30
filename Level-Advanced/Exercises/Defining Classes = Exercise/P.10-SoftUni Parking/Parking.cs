using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P._10_SoftUni_Parking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.Capacity = capacity;
           // this.Cars = new List<Car>();
            this.Cars = new Dictionary<string, Car>();
        }

       // private List<Car> cars;
        private Dictionary<string, Car> cars;
        private int capacity;

        public Dictionary<string, Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public int Count => Cars.Count;
        

        public string AddCar(Car car)
        {
            if (this.Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.Cars.Count >= this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            //Car car = this.Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            //if (car == null)
            //{
            //    return "Car with that registration number, doesn't exist!";
            //}
            //Cars.Remove(car);
            //return $"Successfully removed {car.RegistrationNumber}";

            if (!Cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            Cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            //Car car = this.Cars.First(x => x.RegistrationNumber == registrationNumber);
            //return car;
            return Cars.FirstOrDefault(x => x.Key == registrationNumber).Value;
            //or
            //return Cars[registrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            //foreach (var registrationNumber in registrationNumbers)
            //{
            //    if (this.Cars.Any(x => x.RegistrationNumber == registrationNumber))
            //    {
            //        this.Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
            //    }
            //}

            foreach (var registrationNumber in registrationNumbers)
            {
                Cars.Remove(registrationNumber);
            }
        }
    }
}
