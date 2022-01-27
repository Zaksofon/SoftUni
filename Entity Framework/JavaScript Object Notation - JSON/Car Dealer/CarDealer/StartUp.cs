using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.InputModels;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersJsonAsString = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJsonAsString = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJsonAsString = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJsonAsString = File.ReadAllText("../../../Datasets/customers.json");
            //var salesJsonAsString = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersJsonAsString));
            //Console.WriteLine(ImportParts(context, partsJsonAsString));
            //Console.WriteLine(ImportCars(context, carsJsonAsString));
            //Console.WriteLine(ImportCustomers(context, customersJsonAsString));
            //Console.WriteLine(ImportSales(context, salesJsonAsString));
            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // 09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SuppliersInputDto> suppliers =
                JsonConvert.DeserializeObject<IEnumerable<SuppliersInputDto>>(inputJson);

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(mapperConfig);

            IEnumerable<Supplier> mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        // 10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var ids = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(s => ids.Contains(s.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // 11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<CarsInputDto> carsDto = JsonConvert.DeserializeObject<IEnumerable<CarsInputDto>>(inputJson);

            var cars = new List<Car>();
            var parts = new List<PartCar>();

            foreach (var car in carsDto)
            {
                var newCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId.Distinct())
                {
                    var newPart = new PartCar()
                    {
                        PartId = part,
                        Car = newCar
                    };

                    parts.Add(newPart);
                }

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {carsDto.Count()}.";
        }

        // 12. Import Customers 
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomersInputDto>>(inputJson);

            var configMapper = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(configMapper);

            IEnumerable<Customer> mappedCustomers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        // 13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SalaesInputDto>>(inputJson);

            var configMapper = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(configMapper);

            IEnumerable<Sale> mappedSales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        // 14. Export Ordered Customers 
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(customers, jsonSettings);

            return json;
        }

        // 15. Export Cars From Make Toyota 
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(t => t.Make == "Toyota")
                .Select(t => new
                {
                    t.Id,
                    t.Make,
                    t.Model,
                    t.TravelledDistance
                })
                .OrderBy(t => t.Model)
                .ThenByDescending(t => t.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return json;
        }

        // 16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        // 17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                            .Select(p => new
                            {
                                Name = p.Part.Name,
                                Price = p.Part.Price.ToString("F2")
                            })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);

            return json;
        }

        // 18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.SelectMany(p => p.Car.PartCars.Select(pc => pc.Part.Price)).Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        // 19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance,
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(s => s.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(s => s.Part.Price) - x.Car.PartCars.Sum(s => s.Part.Price) * (x.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}