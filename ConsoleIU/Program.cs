using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarTest();

            //EfCarTest();
            //EfBrandTest();
            //EfColorTest();

            //CarDetailTest();
            //CarAddToDbTest();
            //CarUpdateTest();
            //CarDeleteTest();
            //RentalAddToDbTest();
            RentalDetailTest();
        }

        private static void RentalAddToDbTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 4,
                CustomerId = 2,
                RentDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(2),
            });
            Console.WriteLine(result.Message);
        }

        private static void RentalDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            Console.WriteLine("İsim Soyisim\tMarka\t\tGünlük Kira\tKiralama Tarihi\t\tİade Tarihi\n");
            foreach (var rentalDetail in result.Data)
            {
                Console.WriteLine(rentalDetail.CustomerFirstName + " " +
                    rentalDetail.CustomerLastName + "\t" + rentalDetail.BrandName + "\t\t"
                    + rentalDetail.CarDailyPrice.ToString() + "\t\t" + rentalDetail.RentDate.ToString()
                    + "\t" + rentalDetail.ReturnDate.ToString());
            }
            Console.WriteLine(result.Message);
        }
        private static void CarDeleteTest()
        {
            Console.WriteLine("Araba\tRenk\tGünlük Kirası\tAçıklama\n");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 15, BrandId = 1, ColorId = 8, DailyPrice = 200, ModelYear = 2018, Description = "Opel Vectra" });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var category in result.Data)
                {
                    Console.WriteLine(category.BrandName + "\t" + category.CarColor
                    + "\t" + category.CarDailyPrice.ToString() + "\t\t" + category.CarDescription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarUpdateTest()
        {
            Console.WriteLine("Araba\tRenk\tGünlük Kirası\tAçıklama\n");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 16, BrandId = 5, ColorId = 3, DailyPrice = 250, ModelYear = 2019, Description = "Fiat Punto" });
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.BrandName + "\t" + carDetail.CarColor
                        + "\t" + carDetail.CarDailyPrice.ToString() + "\t\t" + carDetail.CarDescription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }

        private static void CarAddToDbTest()
        {
            Console.WriteLine("Araba\tRenk\tGünlük Kirası\tAçıklama\n");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 17, BrandId = 1, ColorId = 1, DailyPrice = 110, ModelYear = 2004, Description = "Opel Corsa" });

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.BrandName + "\t" + carDetail.CarColor
                        + "\t" + carDetail.CarDailyPrice.ToString() + "\t\t" + carDetail.CarDescription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarDetailTest()
        {
            Console.WriteLine("Araba\tRenk\tGünlük Kirası\tAçıklama\n");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.BrandName + "\t" + carDetail.CarColor
                        + "\t" + carDetail.CarDailyPrice.ToString() + "\t\t" + carDetail.CarDescription);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void EfBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brandDetail in result.Data)
                {
                    Console.WriteLine(brandDetail.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void EfColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var colorDetail in result.Data)
                {
                    Console.WriteLine(colorDetail.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void EfCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 18, Description = "aanana", DailyPrice = -5 });
            Console.WriteLine("\n");

            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "\nGünlük Kirası: " + car.DailyPrice);
                }
            }

            Console.WriteLine("\nSiyah Renkli Arabalar\n");

            var result2 = carManager.GetAllByColorId(4);
            if (result.Success == true)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine(car.Description + "\nGünlük Kirası: " + car.DailyPrice);
                }
            }
            
        }

        private static void InMemoryCarTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAllByModelYear(2019);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "\nGünlük Kirası: " + car.DailyPrice);
                }
            }

            
        }
    }
}