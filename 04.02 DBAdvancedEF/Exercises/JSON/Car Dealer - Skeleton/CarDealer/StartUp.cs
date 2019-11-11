using CarDealer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.DTO;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile(new CarDealerProfile()));

            Insert();

            //QueryAndExport();       

        }

        public static void Insert()
        {
            string workPC = "borko";
            string HomePC = "RR";

            string Path = $@"C:\Users\{workPC}\Dropbox\SoftUni\04.02 DBAdvancedEF\Exercises\JSON\Car Dealer - Skeleton\CarDealer\Datasets\";

            string cars = "cars.json";
            string customers = "customers.json";
            string parts = "parts.json";
            string sales = "sales.json";
            string suppliers = "suppliers.json";

            string fullPath = Path + sales;

            if (File.Exists(fullPath))
            {
                var importData = File.ReadAllText(fullPath);

                using (var context = new CarDealerContext())
                {
                    //string result = ImportSales(context, importData);// import from json to database
                    //Console.WriteLine(result);
                    Console.WriteLine(GetCarsWithTheirListOfParts(context));//export info from database to json visual format
                }

            }
        }

        //MTHDS for review -not judged
        //private static bool IsValid(object @object)
        //{
        //    ICollection<ValidationResult> validations = new List<ValidationResult>();

        //    var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(@object);

        //    bool isValid = Validator.TryValidateObject(@object, validationContext, validations, true);

        //    return isValid;
        //}

        //public static void QueryAndExport()
        //{
        //    using (var context = new CarDealerContext())
        //    {
        //        //string result = GetSalesWithAppliedDiscount(context);
        //        //Console.WriteLine(result);
        //    }
        //}

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
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
                            Price = $"{p.Part.Price:F2}"
                        })
                        .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }
        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Select(c => new
                {
                    FullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s =>
                        s.Car.PartCars.Sum(pc =>
                            pc.Part.Price)
                        * (1 - s.Discount
                             - (c.IsYoungDriver ? 0.05M : 0M)))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Select(s => new
                {
                    car = new CarDto
                    {

                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    customerName = s.Customer.Name,
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 0.05M : 0M),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    priceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price)
                                        * (1 - s.Discount -
                                           (s.Customer.IsYoungDriver ? 0.05M : 0M))
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Include(s => s.Parts)
                .Where(c => c.IsImporter == false)
                .ToArray()
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarDto>()
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ToArray()
                .Select(c => new CustomerDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToArray();


            var jsSetting = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(customers, jsSetting);

            return json;
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            var Parts = new List<PartCar>();

            foreach (var car in cars)
            {
                //Add car


                //check for null values
                if (car.PartsId == null)
                {
                    continue;
                }

                //get the uniqe ids for parts
                car.PartsId = car
                    .PartsId
                    .Distinct()
                    .ToList();

                var newCar = Mapper.Map<Car>(car); //convert carDto back to Car
                context.Cars.Add(newCar); //add new car

                foreach (var i in car.PartsId) //write that part, in property - PartCars list , of 'Car'
                {
                    var newPart = new PartCar
                    {
                        Car = newCar, // add just a new car = carDto 
                        Part = context.Parts.Find(i) //then add founded parts
                    };

                    Parts.Add(newPart);
                }
            }

            context.PartCars.AddRange(Parts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            //var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
            //    .Where(x => context.Suppliers.Any(u => u.Id == x.SupplierId))
            //    .ToList();

            //context.Parts.AddRange(parts);
            //context.SaveChanges();
            //return $"Successfully imported {parts.Count}.";

            var suppliersInDataset = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => suppliersInDataset.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            suppliers.Where(x => x.Name != null && x.IsImporter == true)
            .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
    }
}