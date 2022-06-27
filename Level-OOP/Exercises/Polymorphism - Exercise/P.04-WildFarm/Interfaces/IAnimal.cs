using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_farm.Interfaces
{
    public interface IAnimal
    {
        string Name { get; set; }
        double Weight { get; set; }
        int FoodEaten { get; set; }
        string ProduceSound();
        void Eat(IFood food);
    }
}
