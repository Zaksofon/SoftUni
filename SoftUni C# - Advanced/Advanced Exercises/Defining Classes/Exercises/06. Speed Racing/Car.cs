using System;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public Car()
        {
          
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double traveledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TraveledDistance = traveledDistance;
        }
        
        public bool Move(double distance)
        {
            if (FuelAmount < (FuelConsumptionPerKilometer * distance))
            {
                return false;
            }

            FuelAmount -= (FuelConsumptionPerKilometer * distance);
            TraveledDistance += distance;
            return true;
        }
        
    }
}
