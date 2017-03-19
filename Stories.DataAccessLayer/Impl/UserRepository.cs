using Stories.DataAccessLayer.Abstract;
using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContextWrapper dbContextWrapper) : base(dbContextWrapper)
        {
        }
    }
}
