using _7.Models;

namespace _7.Core.Interfaces
{
    public interface IController
    {
        Product CreateProduct(string name, decimal cost);
        Person CreatePerson(string name, decimal money);
    }
}
