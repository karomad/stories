using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.ServiceLayer.Abstract
{
    public interface IGroupService
    {
        Task<IList<Group>> GetAllGroups(int userId, int first = 0, int pageSize = 0);
        Task<int> JoinOrLeaveGroup(int userId, int groupId, bool join);
        Task<Group> CreateGroup(Group group);
        Task<IList<Group>> SearchGroup(string searchText);
        Task<IList<int>> GetGroupsUsers(IEnumerable<int> groupIds);
    }
}
