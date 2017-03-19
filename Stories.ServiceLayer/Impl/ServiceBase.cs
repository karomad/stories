using Stories.ServiceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Stories.DataModels.Entities;
using Stories.DataAccessLayer;

namespace Stories.ServiceLayer.Impl
{
    public class ServiceBase
    {
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        protected readonly IUnitOfWork _UnitOfWork;

        public async Task<int> SaveAsync()
        {
           return await _UnitOfWork.SaveAsync();
        }

        public int Save()
        {
            return _UnitOfWork.Save();
        }
    }
}
