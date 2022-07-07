using _7.Models.Interfaces;

namespace _7.Models
{
    public class Citizen : ICitizenType
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
    }
}
