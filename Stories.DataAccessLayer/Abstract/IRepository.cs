using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Get(Expression<Func<T, bool>> where, params string[] includes);
        Task<IList<T>> GetAll(Expression<Func<T, bool>> where = null, int first = 0, int pageSize = 0, params string[] includes);
        Task<int> AddOrAttach(T item, bool save = false);
        Task<bool> Delete(int id, bool save = false);
        Task ModifyEntity(T source, T destanition, bool save = false);
    }
}
