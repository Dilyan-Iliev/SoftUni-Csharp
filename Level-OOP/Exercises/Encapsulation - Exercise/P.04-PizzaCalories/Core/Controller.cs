using _5.Core.Interfaces;
using _5.Models;

namespace _5.Core
{
    public class Controller : IController
    {
        public Dough CreateDough(string flourType, string bakingTechnique, double weight)
         => new Dough(flourType, bakingTechnique, weight);

        public Pizza CreatePizza(string name, Dough dough)
         => new Pizza(name, dough);

        public Topping CreateTopping(string type, double weight)
         => new Topping(type, weight);  
    }
}
