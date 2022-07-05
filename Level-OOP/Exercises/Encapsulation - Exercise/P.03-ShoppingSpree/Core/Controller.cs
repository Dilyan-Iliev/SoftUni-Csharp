using _7.Core.Interfaces;
using _7.Models;

namespace _7.Core
{
    public class Controller : IController
    {
        public Person CreatePerson(string name, decimal money)
         => new Person(name, money);

        public Product CreateProduct(string name, decimal cost)
         => new Product(name, cost);
    }
}
