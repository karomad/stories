using Stories.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.DataModels.Entities;

namespace Stories.DataAccessLayer
{
    public class DbContextWrapper : IDbContextWrapper
    {
        private StoriesDbContext dbContext;
        public StoriesDbContext InitContext()
        {
            return dbContext ?? (dbContext = new StoriesDbContext());
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue && dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
