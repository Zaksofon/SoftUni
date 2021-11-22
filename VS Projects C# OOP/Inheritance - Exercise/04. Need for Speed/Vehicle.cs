﻿
namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_COSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption => DEFAULT_FUEL_COSUMPTION;

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
