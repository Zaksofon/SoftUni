
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
   public class ProfessionalRacer : Racer
   {
       private const int initialDrivingExp = 30;
       private const string behavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, behavior, initialDrivingExp, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
   }
}
