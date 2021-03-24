using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId=car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear=car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                                 
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 CarId = p.Id
                             };
                return result.ToList();
            }
        }
    }
}