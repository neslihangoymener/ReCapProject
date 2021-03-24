using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carImageService = carImageService;
            _carDal = carDal;
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Add")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
           _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
        [CacheAspect]
        [SecuredOperation("car.list,admin")]
        [ValidationAspect(typeof(CarValidator))]
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByModelYear(int year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == year));
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorid));

        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandid));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId)
        {
            var result = _carDal.GetCarDetails();
            var imageResult = _carImageService.GetByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailAndImagesDto>(Messages.ErrorCarMessage);
            }

            var carDetailAndImagesDto = new CarDetailAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarDetailAndImagesDto>(carDetailAndImagesDto, Messages.SuccessCarMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int brandId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarsDetails(p => p.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ErrorCarMessage);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarsDetails(p => p.BrandId == brandId && p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ErrorCarMessage);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByColorId(int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarsDetails(p => p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ErrorCarMessage);
            }
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 0)
            {
                throw new Exception();
            }
            Add(car);
            return null;

        } 

    }
}
