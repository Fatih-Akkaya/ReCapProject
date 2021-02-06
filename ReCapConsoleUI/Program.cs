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

            foreach (var car in carManager.GetAll())
            {
                string brand = new EFBrandDAL().Get(b => b.Id == car.BrandId).Name;
                Console.WriteLine("Brand : " + brand + " Model : " + car.ModelYear + " Price : " + car.DailyPrice);
            }
        }
    }
}
