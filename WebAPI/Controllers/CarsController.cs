using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        [SecuredOperation("car.list,admin")]
        //[Authorize()]//Bu operasyonun çalışabilmesi için kullanıcının authontantice olması yeterlidir
        public IActionResult GetAll()
        {

            //Dependency chain --
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetAllByColorId")]

        //https://localhost:44367/api/cars/GetAllByColorId?id=2
        public IActionResult GetAllByColorId(int colorid)
        {
            var result = _carService.GetCarsDetailByColorId(colorid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByModelYear")]

        //https://localhost:44367/api/cars/GetAllByModelYear?year=2020
        public IActionResult GetAllByModelYear(int year)
        {
            var result = _carService.GetAllByModelYear(year);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllByBrandId")]

        //https://localhost:44367/api/cars/GetAllByBrandId?year=2020
        public IActionResult GetAllByBrandId(int brandid)
        {
            var result = _carService.GetCarsDetailByBrandId(brandid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarDetails")]

        //https://localhost:44367/api/cars/GetCarDetails
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandandcolor")]
        public IActionResult GetByBrandAndColor(int brandId, int colorId)
        {
            var result = _carService.GetCarsDetailByBrandIdAndColorId(brandId, colorId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

            [HttpPost("add")]
        [SecuredOperation("car.add,admin")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        [SecuredOperation("car.update,admin")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        [SecuredOperation("car.delete,admin")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

