using Stories.DataAccessLayer.Abstract;
using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Impl
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(IDbContextWrapper dbContextWrapper) : base(dbContextWrapper)
        {
        }

        public async Task<IEnumerable<Group>> GetAllGroups(int userId, int first = 0, int pageSize = 0)
        {
            var groups = DbContext
                            .Groups
                            .Where(x => !x.Deleted)
                            .Select(x => new GroupForProjection
                            {
                                Description = x.Description,
                                Id = x.Id,
                                Name = x.Name,
                                MembersCount = x.Members.Count(),
                                StoriesCount = x.Stories.Count(),
                                IsInGroup = x.Members.Any(y => y.Id == userId)
                            }).OrderBy(x => x.Id).Skip(first);
            if (pageSize > 0)
            {
                groups = groups.Take(pageSize);
            }
            return await groups.ToListAsync();
        }

        public async Task JoinOrLeaveGroup(int userId, int groupId, bool join)
        {
            Group _group = await Get(x => x.Id == groupId, includes: "Members");

            if (join)
            {
                User _user = new User { Id = userId };
                DbContext.Users.Attach(_user);
                _group.Members.Add(_user);
            }
            else
            {
                _group.Members.Remove(_group.Members.SingleOrDefault(x => x.Id == userId));
            }
        }
    }
}
