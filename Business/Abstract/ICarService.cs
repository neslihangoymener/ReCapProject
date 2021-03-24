using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByModelYear(int year);
        IDataResult<List<Car>> GetAllByColorId(int colorid);
        IDataResult<List<Car>> GetAllByBrandId(int brandid);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionTest(Car car);
    }
}
