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
                var result = from u in context.Users
                             where u.EMail == email
                             select u;
                             
                return result.SingleOrDefault();
                
                }
        }
    }
}
