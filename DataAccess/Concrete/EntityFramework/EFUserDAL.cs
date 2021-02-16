using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDAL : EFEntityRepositoryBase<User, ReCapContext>, IUserDAL
    {
        public User GetByEmail(string email)
        {
                using (ReCapContext context = new ReCapContext())
                {
                    return context.Users.SingleOrDefault(b => b.EMail.Equals(email));
                }
        }
    }
}
