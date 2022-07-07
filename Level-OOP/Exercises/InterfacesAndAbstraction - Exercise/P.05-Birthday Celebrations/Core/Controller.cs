using _7.Core.Interfaces;
using _7.Models;

namespace _7.Core
{
    public class Controller : IController
    {
        public Citizen CreateCitizien(string name, int age, string id, string birthdate)
         => new Citizen(name, age, id, birthdate);

        public Pet CreatePet(string name, string birthdate)
         => new Pet(name, birthdate);

        public Robot CreateRobot(string model, string id)
         => new Robot(model, id);
    }
}
