namespace Formula1.Models
{
    using System;
    using System.Text;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;

    public class Race : IRace
    {
        private string raceName;
        private int numOfLaps;
        private IList<IPilot> pilots;


        public Race()
        {
            pilots = new List<IPilot>();
        }

        public Race(string raceName, int numberOfLaps)
            : this()
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) 
                    || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }

                numOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string result = TookPlace ? "Yes" : "No";

            var sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.Append($"Took place: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}
