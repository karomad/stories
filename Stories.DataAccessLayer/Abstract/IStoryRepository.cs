using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Abstract
{
    public interface IStoryRepository : IRepository<Story>
    {
        Task<int> AddOrEditStory(Story story);
    }
}
