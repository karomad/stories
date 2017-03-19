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
    public class GroupService : ServiceBase, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Group> CreateGroup(Group group)
        {
            group.Id = await _UnitOfWork.GroupRepository.AddOrAttach(group, true);
            return group;
        }

        public async Task<IList<Group>> GetAllGroups(int userId, int first = 0, int pageSize = 0)
        {
            var groups = await _UnitOfWork.GroupRepository.GetAllGroups(userId, first: first, pageSize: pageSize);
            return groups.ToList();
        }

        public async Task<IList<int>> GetGroupsUsers(IEnumerable<int> groupIds)
        {
            return await _UnitOfWork.SqlQueryAsync<int>($"select distinct UserId from GroupUsers where GroupId in ({string.Join(",", groupIds.Select(x => x.ToString()))})");
        }

        public async Task<int> JoinOrLeaveGroup(int userId, int groupId, bool join)
        {
            await _UnitOfWork.GroupRepository.JoinOrLeaveGroup(userId, groupId, join);
            await _UnitOfWork.SaveAsync();
            return join ? 1 : -1;
        }

        public async Task<IList<Group>> SearchGroup(string searchText)
        {
            return await _UnitOfWork.GroupRepository.GetAll(x => x.Name.Contains(searchText));
        }
    }
}
