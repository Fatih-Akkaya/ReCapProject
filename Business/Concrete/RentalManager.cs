using Business.Abstract;
using Business.Constants;
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

        public IResult Delete(Rental rental)
        {
            _rentalDAL.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDAL.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.GetById(id));
        }
        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.GetAll(r=>r.CarId==carId).OrderByDescending(item => item.Id).First());            
        }

        public IResult Update(Rental rental)
        {
            _rentalDAL.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
