using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDAL _rentalDAL;
        public RentalManager(IRentalDAL rentalDAL)
        {
            _rentalDAL = rentalDAL;
        }
        
        [SecuredOperation("rental.add,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var checkCarAvaibility = GetByCarId(rental.CarId);
            if (checkCarAvaibility.Success&&checkCarAvaibility.Data.ReturnDate== new DateTime(1900, 1, 1))
            {
                var car = checkCarAvaibility.Data;
                //Console.WriteLine(car.CarId + " / " + car.CustomerId + " / " + car.RentDate);
                return new ErrorResult(Messages.RentalNotAdded);
            }            

            _rentalDAL.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDAL.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDAL.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.GetById(id));
        }

        [CacheAspect]
        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.GetAll(r=>r.CarId==carId).OrderByDescending(item => item.Id).First());            
        }

        [SecuredOperation("rental.update,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDAL.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
