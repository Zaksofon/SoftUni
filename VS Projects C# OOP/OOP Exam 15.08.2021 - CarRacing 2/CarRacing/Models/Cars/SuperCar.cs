using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double initialFuelAvailable = 80;
        private const double fuelConsumption = 10;

        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, fuelConsumption, initialFuelAvailable)
        {
        }
    }
}
