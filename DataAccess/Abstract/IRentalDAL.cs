﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDAL : IEntityRepository<Rental>
    {
        Rental GetById(int id);
    }
}
