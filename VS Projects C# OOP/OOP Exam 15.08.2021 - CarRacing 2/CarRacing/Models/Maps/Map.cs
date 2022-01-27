
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double strictMultiplier = 1.2;
        private const double aggressiveMultiplier = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (racerTwo.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            racerOne.Race();
            racerTwo.Race();

            double winningChanceRacerOne = 0;
            double winningChanceRacerTwo = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                winningChanceRacerOne = (racerOne.Car.HorsePower * racerOne.DrivingExperience * strictMultiplier);
            }
            else
            {
                winningChanceRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * aggressiveMultiplier;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                winningChanceRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * strictMultiplier;
            }
            else
            { 
                winningChanceRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * aggressiveMultiplier;
            }

            if (winningChanceRacerOne > winningChanceRacerTwo)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }
    }
}
