using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDAL : IEntityRepository<Customer>
    {
        Customer GetByUserId(int id);
        List<CustomerDetailDTO> GetCustomerDetails(Expression<Func<CustomerDetailDTO, bool>> filter = null);
    }
}
