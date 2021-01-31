using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }
        public void Add(Car car)
        {
            _carDAL.Add(car);
        }

        public void Delete(Car car)
        {
            _carDAL.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _carDAL.GetAllByBrand(brandId);
        }

        public List<Brand> GetAllBrands()
        {
            return _carDAL.GetAllBrands();
        }

        public void Update(Car car)
        {
            _carDAL.Update(car);
        }
    }
}
