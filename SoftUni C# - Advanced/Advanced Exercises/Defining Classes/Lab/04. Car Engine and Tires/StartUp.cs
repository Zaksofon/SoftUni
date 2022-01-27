using System;
using System.Threading.Channels;
using System.Xml.Schema;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
            };

            var engine = new Engine(5600, 6300);
            var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}