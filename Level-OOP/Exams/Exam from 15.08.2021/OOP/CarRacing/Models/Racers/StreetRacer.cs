namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int DrivingExpIncreaser = 5;
        private const int StreetRacerDrivingExperience = 10;
        private const string StreetRacerRacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car) 
            : base(username, StreetRacerRacingBehavior, StreetRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += DrivingExpIncreaser;
        }
    }
}
