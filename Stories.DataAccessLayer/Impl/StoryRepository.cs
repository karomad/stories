using Stories.DataAccessLayer.Abstract;
using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Impl
{
    public class StoryRepository : Repository<Story>, IStoryRepository
    {
        public StoryRepository(IDbContextWrapper dbContextWrapper) : base(dbContextWrapper)
        {
        }

        public async Task<int> AddOrEditStory(Story story)
        {
            if (story.IsNew)
            {
                foreach (var group in story.Groups)
                {
                    DbContext.Groups.Attach(group);
                }
                return await AddOrAttach(story, true);
            }
            else
            {
                var dbstory = DbContext.Stories.Include("Groups").SingleOrDefault(x => x.Id == story.Id);
                var deletedGroups = dbstory.Groups.Select(x => x.Id).Except(story.Groups.Select(x => x.Id)).ToList();

                foreach (var group in story.Groups)
                {
                    if (group.IsNew)
                    {
                        dbstory.Groups.Add(group);
                    }
                    else
                    {
                        if (!dbstory.Groups.Any(x => x.Id == group.Id))
                        {
                            DbContext.Groups.Attach(group);
                            dbstory.Groups.Add(group);
                        }
                    }
                }
                foreach (var gid in deletedGroups)
                {
                    dbstory.Groups.Remove(dbstory.Groups.FirstOrDefault(x => x.Id == gid));
                }
                await ModifyEntity(story, dbstory, true);

                return story.Id;
            }
        }
    }
}
