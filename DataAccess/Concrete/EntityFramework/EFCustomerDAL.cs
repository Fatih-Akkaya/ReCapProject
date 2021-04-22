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
    public class EFCustomerDAL : EFEntityRepositoryBase<Customer, ReCapContext>, ICustomerDAL
    {
        public Customer GetByUserId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Customers.SingleOrDefault(b => b.UserId==id);
            }
        }

        public List<CustomerDetailDTO> GetCustomerDetails(Expression<Func<CustomerDetailDTO, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDTO
                             {
                                 CustomerId = c.Id,
                                 CompanyName = c.CompanyName,
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 EMail = u.EMail
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }

        }
    }
}
