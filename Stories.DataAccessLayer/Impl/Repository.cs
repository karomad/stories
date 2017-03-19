using Stories.DataAccessLayer.Abstract;
using Stories.DataModels.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Impl
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        IDbContextWrapper _DbContextWrapper;
        StoriesDbContext _DbContext;
        protected StoriesDbContext DbContext => _DbContext ?? (_DbContext = _DbContextWrapper.InitContext());

        public Repository(IDbContextWrapper dbContextWrapper)
        {
            _DbContextWrapper = dbContextWrapper;
        }
        public async Task<int> AddOrAttach(T item, bool save = false)
        {
            if (item.IsNew)
            {
                DbContext.Set<T>().Add(item);
            }
            else
            {
                DbContext.Set<T>().Attach(item);
            }
            if (save)
            {
                await DbContext.SaveChangesAsync();
            }
            return item.Id;
        }

        public async Task<bool> Delete(int id, bool save = false)
        {
            T item = await Get(x => x.Id == id);
            if (item == null)
            {
                return true;
            }
            item.Deleted = true;
            DbContext.Entry(item).State = EntityState.Modified;
            if (save)
            {
                await DbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<T> Get(Expression<Func<T, bool>> single, params string[] includes)
        {
            IQueryable<T> _set = DbContext.Set<T>();

            for (int i = 0; i < includes.Length; i++)
            {
                _set = _set.Include(includes[i]);
            }
            return await _set.Where(x => !x.Deleted).SingleOrDefaultAsync(single);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> multiple = null, int first = 0, int pageSize = 0, params string[] includes)
        {
            var _set = DbContext.Set<T>().Where(x => !x.Deleted);
            for (int i = 0; i < includes.Length; i++)
            {
                _set = _set.Include(includes[i]);
            }
            var _set_where = multiple == null ? _set : _set.Where(multiple);
            _set_where = pageSize <= 0 ? _set_where = _set_where.OrderBy(x => x.Id).Skip(first) : 
                                                      _set_where.OrderBy(x => x.Id).Skip(first).Take(pageSize);
            return await _set_where.ToListAsync();
        }

        public async Task ModifyEntity(T source, T destanition, bool save = false)
        {
            foreach (var p in typeof(T).GetProperties().Where(x => (x.PropertyType == typeof(string) ||
                                                                   !x.PropertyType.GetInterfaces().Contains(typeof(IEnumerable))) &&
                                                                    x.PropertyType.BaseType != typeof(EntityBase)))
            {
                object destValue = p.GetValue(destanition);
                object sourceValue = p.GetValue(source);
                if (destValue?.GetHashCode() != sourceValue?.GetHashCode())
                {
                    p.SetValue(destanition, sourceValue);
                }
            }
            if (save)
            {
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
