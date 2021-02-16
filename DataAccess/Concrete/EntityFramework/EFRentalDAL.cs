using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
