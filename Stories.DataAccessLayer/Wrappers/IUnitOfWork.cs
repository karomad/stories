using Stories.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        int Save();
        Task<IList<T>> SqlQueryAsync<T>(string sql, params object[] args);
       
        IUserRepository UserRepository { get; }
        IStoryRepository StoryRepository { get; }
        IGroupRepository GroupRepository { get; }
    }
}
