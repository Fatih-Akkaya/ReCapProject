using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDAL : EFEntityRepositoryBase<Customer, ReCapContext>, ICustomerDAL
    {
        public Customer GetByUserId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Customers.SingleOrDefault(b => b.UserId==id);
            }
        }
    }
}
