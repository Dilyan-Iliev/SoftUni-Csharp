using _7.Models.Interfaces;

namespace _7.Models
{
    public class Robot : ICitizenType
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
