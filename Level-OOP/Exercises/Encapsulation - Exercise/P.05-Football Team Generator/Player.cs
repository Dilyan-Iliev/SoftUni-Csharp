using System;

namespace P._05_Football_Team_Generator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) //includes null, white space and string.Empty
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateData(value, nameof(Endurance));

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateData(value, nameof(Sprint));

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateData(value, nameof(Dribble));

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateData(value, nameof(Passing));

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateData(value, nameof(Shooting));

                this.shooting = value;
            }
        }

        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) /  5.0;

        private void ValidateData(int value, string statsName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statsName} should be between 0 and 100.");
            }
        }
    }
}
