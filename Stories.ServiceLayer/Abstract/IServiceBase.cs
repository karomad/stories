using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stories.ServiceLayer.Abstract
{
    public interface IServiceBase
    {
        Task<int> SaveAsync();
        int Save();
    }
}
