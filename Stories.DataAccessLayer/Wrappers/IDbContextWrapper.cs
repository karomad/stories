using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer
{
    public interface IDbContextWrapper: IDisposable
    {
        StoriesDbContext InitContext();
    }
}
