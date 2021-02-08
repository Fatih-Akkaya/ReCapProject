using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFColorDAL : EFEntityRepositoryBase<Color, ReCapContext>, IColorDAL
    {
        public Color GetByName(string name)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Colors.SingleOrDefault(b => b.Name.Equals(name));
            }
        }
    }
}
