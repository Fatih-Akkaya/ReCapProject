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
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            RentalManager rentalManager = new RentalManager(new EFRentalDAL());
            var rental = rentalManager.GetById(4);
            if (rental.Success)
            {
                rental.Data.ReturnDate = DateTime.Today;
            }
            
            var rentalResult = /*rentalManager.Update(rental.Data);
            Console.WriteLine(rentalResult.Message);*/
            rentalManager.Add(new Rental { CarId = 5, CustomerId = 4, RentDate = DateTime.Today });

            Console.WriteLine(rentalResult.Message);
            
            
        }
    }
}
