
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int initialDrivingExp = 10;
        private const string behavior = "aggressive";

        public StreetRacer(string username, ICar car) 
            : base(username, behavior, initialDrivingExp, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
