using _5.Models;

namespace _5.Core.Interfaces
{
    public interface IController
    {
        Dough CreateDough(string flourType, string bakingTechnique, double weight);
        Topping CreateTopping(string type, double weight);
        Pizza CreatePizza(string name, Dough dough);
    }
}
