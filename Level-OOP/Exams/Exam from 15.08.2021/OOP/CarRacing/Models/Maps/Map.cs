namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneChanceOfWinning = 0;
            double racingBehaviorMultiplier = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplier;

            double racerTwoChanceOfWinning = 0;

            if (racerTwo.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplier;

            string result = racerOneChanceOfWinning > racerTwoChanceOfWinning ? $"{racerOne.Username}" : $"{racerTwo.Username}";

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, result);
        }
    }
}
