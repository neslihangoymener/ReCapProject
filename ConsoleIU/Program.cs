using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("GetAll");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id +": " +car.DailyPrice +" TL "+ car.Description+ " "+car.ModelYear +" model yılı");
            }

            Console.WriteLine("GetById");
            foreach (var car in carManager.GetById())
            {
            Console.WriteLine("Araba ID: " + car.Id);
            }

            Console.ReadLine();
        }
    }
}
