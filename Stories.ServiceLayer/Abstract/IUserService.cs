using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.ServiceLayer.Abstract
{
    public interface IUserService
    {
        Task<User> Login(string name);
    }
}
