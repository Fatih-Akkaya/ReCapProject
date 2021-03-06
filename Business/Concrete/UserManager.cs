﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public IResult Add(User user)
        {
            _userDAL.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDAL.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDAL.Get(u => u.EMail == email));
        }

        public IResult Update(User user)
        {
            _userDAL.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDAL.GetClaims(user);
        }
    }
}
