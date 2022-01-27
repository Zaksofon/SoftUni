
using System;
using System.Reflection;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars = new CarRepository();
        private RacerRepository racers = new RacerRepository();
        private IMap map;

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            switch (type)
            {
                case nameof(SuperCar): car = new SuperCar(make, model, VIN, horsePower); break;

                case nameof(TunedCar): car = new TunedCar(make, model, VIN, horsePower); break;

                default: throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            switch (type)
            {
                case nameof(ProfessionalRacer): racer = new ProfessionalRacer(username, car); break;

                case nameof(StreetRacer): racer = new StreetRacer(username, car); break;

                default: throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            throw new System.NotImplementedException();
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }
    }
}
