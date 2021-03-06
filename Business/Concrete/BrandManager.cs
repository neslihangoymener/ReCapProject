﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
   
        [SecuredOperation("brand.list,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Add")]
        [TransactionScopeAspect]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult< List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int brandid)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandid));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Brand brand)
        {
            Add(brand);
            if (brand.BrandName.Length < 2)
            {
                throw new Exception();
            }
            Add(brand);
            return null;

        }
    }
}