using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDAL : IEntityRepository<Rental>
    {
        Rental GetById(int id);
        List<RentalDetailDTO> GetRentalDetails(Expression<Func<RentalDetailDTO, bool>> filter = null);
    }
}
