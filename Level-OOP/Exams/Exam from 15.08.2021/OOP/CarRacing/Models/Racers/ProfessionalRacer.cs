namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int DrivingExpIncreaser = 10;
        private const int ProfessionalRacerDrivingExperience = 30;
        private const string ProfessionalRacerRacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, ProfessionalRacerRacingBehavior, ProfessionalRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += DrivingExpIncreaser;
        }
    }
}
