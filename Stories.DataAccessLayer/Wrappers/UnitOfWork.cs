using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.DataAccessLayer.Abstract;
using Stories.DataModels.Entities;
using Stories.DataAccessLayer.Impl;

namespace Stories.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextWrapper _DbContextWrapper;
        StoriesDbContext _DbContext;
        public StoriesDbContext DbContext => _DbContext ?? (_DbContext = _DbContextWrapper.InitContext());

        public UnitOfWork(IDbContextWrapper dbContextWrapper)
        {
            _DbContextWrapper = dbContextWrapper;
        }
        #region Repositories

        IGroupRepository _GroupRepository;
        public IGroupRepository GroupRepository => _GroupRepository ?? (_GroupRepository = new GroupRepository(_DbContextWrapper));

        IStoryRepository _StoryRepository;
        public IStoryRepository StoryRepository => _StoryRepository ?? (_StoryRepository = new StoryRepository(_DbContextWrapper));

        IUserRepository _UserRepository;
        public IUserRepository UserRepository => _UserRepository ?? (_UserRepository = new UserRepository(_DbContextWrapper));

        #endregion

        public int Save()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> SqlQueryAsync<T>(string sql, params object[] args)
        {
            return await DbContext.Database.SqlQuery<T>(sql, args).ToListAsync();
        }
    }
}
