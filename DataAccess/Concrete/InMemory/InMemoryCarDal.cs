using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //Oracle,Sql server,Postgress,MongoDb veritabanından geliyormuş gibi
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=150000,Description="A"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=160000,Description="B"},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear=2019,DailyPrice=125000,Description="C"},
                new Car{Id=4,BrandId=2,ColorId=4,ModelYear=2018,DailyPrice=110000,Description="D"},
                new Car{Id=5,BrandId=2,ColorId=5,ModelYear=2017,DailyPrice=100000,Description="E"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
             Car carToDelete = _cars.SingleOrDefault(c => c.Id==car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            var expression = filter.Compile();
            var car = _cars.SingleOrDefault(expression);
            return car;
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var expression = filter.Compile();
            return filter == null ? _cars : _cars.Where(expression).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            Console.WriteLine("InMemory' de SQL işlemleri yapılamaz.");
            return null;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
