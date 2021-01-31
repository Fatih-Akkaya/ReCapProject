using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReCapConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDAL());
            foreach (var car in carManager.GetAll())
            {
                string brand = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == car.BrandId).BrandName;
                Console.WriteLine("Brand : " + brand + " Model : " + car.ModelYear + " Price : " + car.DailyPrice);
            }
        }
    }
}
