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
            if (car.Description.Length < 2 && car.DailyPrice>0)
            {
                throw new NotImplementedException("Ürün ismi kurallara uygun değil.");
            }
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

        public void Update(Car car)
        {
            _carDAL.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDAL.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDAL.GetAll(p => p.ColorId == id);
        }
    }
}
