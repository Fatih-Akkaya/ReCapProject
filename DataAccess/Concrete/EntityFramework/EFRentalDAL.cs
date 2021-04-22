using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDAL : EFEntityRepositoryBase<Rental, ReCapContext>, IRentalDAL
    {
        public Rental GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Rentals.SingleOrDefault(b => b.Id == id);
            }
        }

        public List<RentalDetailDTO> GetRentalDetails(Expression<Func<RentalDetailDTO, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join u in context.Users
                             on c.UserId equals u.Id
                             join cr in context.Cars
                             on r.CarId equals cr.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             select new RentalDetailDTO
                             {
                                 RentalId=r.Id,
                                 CustomerId = c.Id,
                                 CompanyName = c.CompanyName,
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 EMail = u.EMail,
                                 CarId=r.CarId,
                                 CarName=cr.Name,
                                 BrandId=cr.BrandId,
                                 BrandName=b.Name,
                                 ColorId=cr.ColorId,
                                 ColorName=cl.Name,
                                 ModelYear=cr.ModelYear,
                                 DailyPrice=cr.DailyPrice,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
