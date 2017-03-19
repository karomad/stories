using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.ServiceLayer.Abstract
{
    public interface IStoryService
    {
        Task<IList<Story>> GetUserStories(int userId, int first, int pagesize);
        Task<Story> GetStoryDetails(int storyId);
        Task<int> AddOrEditStory(Story item);
    }
}
