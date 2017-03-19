using Stories.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataAccessLayer.Abstract
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllGroups(int userId, int first = 0, int pageSize = 0);
        Task JoinOrLeaveGroup(int userId, int groupId, bool join);
    }
}
