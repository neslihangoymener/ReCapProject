﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [SecuredOperation("user.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Add")]
        [TransactionScopeAspect]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("user.delete,admin")]

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult AddTransactionTest(User user)
        {
            throw new NotImplementedException();
        }
    }
}
