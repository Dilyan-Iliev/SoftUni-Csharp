using _7.Core.Interfaces;
using _7.Models;

namespace _7.Core
{
    public class Controller : IController
    {
        public Citizen CreateCitizien(string name, int age, string id)
         => new Citizen(name, age, id);

        public Robot CreateRobot(string model, string id)
         => new Robot(model, id);
    }
}
