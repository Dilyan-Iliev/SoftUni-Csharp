using PracticeForJudge.Models.Interfaces;

namespace PracticeForJudge.Models
{
    public class Chicken : IBird
    {
        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentNullException(nameof(value), "Name cannot be empty.");
                }

                name = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value < 0 || value > 15)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(value), "Age should be between 0 and 15.");
                }

                age = value;
            }
        }

        public override string ToString()
        {
            return $"Chicken {Name} (age {Age}) can produce 1 eggs per day.";
        }
    }
}
