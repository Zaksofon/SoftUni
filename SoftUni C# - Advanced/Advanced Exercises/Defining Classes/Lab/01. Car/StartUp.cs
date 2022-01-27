using System;
using System.Xml.Schema;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.Make = "Honda";
            myCar.Model = "CR-V";
            myCar.Year = 2007;
            myCar.FuelQuantity = 200;
            myCar.FuelConsumption = 200;
            myCar.Drive(2000);

            Console.WriteLine(myCar.WhoAmI());

            //Console.WriteLine($"Make: {myCar.Make}\nModel: {myCar.Model}\nYear: {myCar.Year}");
        }
    }
}
