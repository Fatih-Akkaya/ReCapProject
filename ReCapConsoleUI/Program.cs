using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            CarManager carManager = new CarManager(new EFCarDAL());
            /*int brandId = new EFBrandDAL().GetByName("Renault").Id;
            int colorId = new EFColorDAL().GetByName("Black").Id;
            carManager.Add(new Car { Name = "Megane", BrandId=brandId, ColorId=colorId, ModelYear=2018, DailyPrice=450 });*/
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}
