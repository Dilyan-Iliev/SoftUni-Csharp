using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Catalog
    {
        public Catalog() //добре е да си правя конструктор и да инициализирам тези Properties, когато става въпрос за колекции
                         //
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

    }
    internal class Program
    {
        static void Main()
        {
            Catalog catalogObj = new Catalog(); //листовете се съхраняват в class Catalog

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split('/', StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArgs[0];
                string brand = cmdArgs[1];
                string model = cmdArgs[2];
                int finalParam = int.Parse(cmdArgs[3]); //could be either horsePower or weight like below
                //int horsePower = int.Parse(cmdArgs[3]);
                //int weight = int.Parse(cmdArgs[3]);

                if (type == "Car")
                {
                    //Add car to the catalog

                    Car newCar = new Car(brand, model, finalParam);
                    catalogObj.Cars.Add(newCar);
                }
                else if (type == "Truck")
                {
                    //Add truck to the catalog

                    Truck newTruck = new Truck(brand, model, finalParam);
                    catalogObj.Trucks.Add(newTruck);
                }
            }

            Console.WriteLine("Cars:");
            List<Car> orderedCars = catalogObj.Cars.OrderBy(car => car.Brand).ToList();
            foreach (Car car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }


            Console.WriteLine("Trucks:");
            List<Truck> orderedTrucks = catalogObj.Trucks.OrderBy(truck => truck.Brand).ToList();
            foreach (Truck truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
