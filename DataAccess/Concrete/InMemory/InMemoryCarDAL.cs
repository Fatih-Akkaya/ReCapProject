using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _colors = new List<Color> { new Color { ColorId = 1, ColorName = "Black" },
            new Color { ColorId = 2, ColorName = "Silver" },
            new Color { ColorId = 3, ColorName = "Red" },
            new Color { ColorId = 4, ColorName = "Blue" },
            new Color { ColorId = 5, ColorName = "White" }};
            _brands = new List<Brand> { new Brand { BrandId=1, BrandName="Lamborghini"},
            new Brand { BrandId=2, BrandName="Maserati"},
            new Brand { BrandId=3, BrandName="Bentley"},
            new Brand { BrandId=4, BrandName="Aston Martin"}};
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

        public List<Car> GetAll()
        {
            return _cars;
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
