using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double initialFuelAvailable = 65;
        private const double fuelConsumption = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, fuelConsumption, initialFuelAvailable)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int) Math.Round(HorsePower * 0.97);
        }
    }
}
