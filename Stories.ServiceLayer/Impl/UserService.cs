using Stories.ServiceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.DataAccessLayer;
using Stories.DataModels.Entities;

namespace Stories.ServiceLayer.Impl
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<User> Login(string name)
        {
            return await _UnitOfWork.UserRepository.Get(x => x.Name == name);
        }
    }
}
