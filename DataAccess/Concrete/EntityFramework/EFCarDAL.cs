using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDAL : EFEntityRepositoryBase<Car, ReCapContext>, ICarDAL
    {
        public List<CarDetailDTO> GetCarDetails(Expression<Func<CarDetailDTO, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDTO
                             {
                                 CarId=c.Id,
                                 CarName = c.Name,
                                 BrandId=c.BrandId,
                                 BrandName = b.Name,
                                 ColorId=c.ColorId,
                                 ColorName = cl.Name,
                                 ModelYear=c.ModelYear,
                                 DailyPrice = c.DailyPrice
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }

        }
    }
}
