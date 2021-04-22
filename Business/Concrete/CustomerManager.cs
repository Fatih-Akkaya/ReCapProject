using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDAL _customerDAL;
        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDAL.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDAL.GetAll(), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDAL.GetByUserId(id));
        }

        [CacheAspect]
        public IDataResult<List<CustomerDetailDTO>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDTO>>(_customerDAL.GetCustomerDetails(), Messages.CustomersListed);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDAL.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
