using Stories.ServiceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.DataModels.Entities;
using Stories.DataAccessLayer;

namespace Stories.ServiceLayer.Impl
{
    public class StoryService : ServiceBase, IStoryService
    {
        public StoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> AddOrEditStory(Story item)
        {
            return await _UnitOfWork.StoryRepository.AddOrEditStory(item);
        }

        public async Task<Story> GetStoryDetails(int storyId)
        {
            return await _UnitOfWork.StoryRepository.Get(x => x.Id == storyId, includes: "Groups");
        }

        public async Task<IList<Story>> GetUserStories(int userId, int first, int pagesize)
        {
            return await _UnitOfWork.StoryRepository.GetAll(x => x.UserId == userId, first: first, pageSize: pagesize);
        }
    }
}
