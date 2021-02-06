using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL : ICarDAL
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDAL()
        {
            _colors = new List<Color> { new Color { Id = 1, Name = "Black" },
            new Color { Id = 2, Name = "Silver" },
            new Color { Id = 3, Name = "Red" },
            new Color { Id = 4, Name = "Blue" },
            new Color { Id = 5, Name = "White" }};
            _brands = new List<Brand> { new Brand { Id=1, Name="Lamborghini"},
            new Brand { Id=2, Name="Maserati"},
            new Brand { Id=3, Name="Bentley"},
            new Brand { Id=4, Name="Aston Martin"}};
            _cars = new List<Car> { new Car { Id=1, BrandId=1, ColorId=1, ModelYear=2019, DailyPrice=125000, Description="One door" },
            new Car { Id=2, BrandId=1, ColorId=2, ModelYear=2021, DailyPrice=135000, Description="Four door" },
            new Car { Id=3, BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=120000, Description="Four door" },
            new Car { Id=4, BrandId=3, ColorId=1, ModelYear=2019, DailyPrice=130000, Description="One door" },
            new Car { Id=5, BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=155000, Description="Four door" },
            new Car { Id=6, BrandId=4, ColorId=3, ModelYear=2017, DailyPrice=140000, Description="One door" },
            new Car { Id=7, BrandId=4, ColorId=4, ModelYear=2021, DailyPrice=160000, Description="One door" }};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
