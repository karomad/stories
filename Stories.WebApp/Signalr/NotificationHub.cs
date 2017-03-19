using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Stories.WebApp.Signalr
{
    public class NotificationHub : Hub
    {
        private static ConcurrentDictionary<int, List<string>> userConnections = new ConcurrentDictionary<int, List<string>>();
        static object _disconnectLock = new object();
        public static List<string> GetUsersConnections(List<int> userIds)
        {
            return userConnections.Where(x => userIds.Contains(x.Key)).SelectMany(x => x.Value).ToList();
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            lock (_disconnectLock)
            {
                var user = userConnections.FirstOrDefault(x => x.Value.Contains(Context.ConnectionId));
                if (user.Value != null)
                {
                    user.Value.Remove(Context.ConnectionId);
                }
                return base.OnDisconnected(stopCalled);
            }
        }

        public void Register(int userId)
        {
            if (userConnections.ContainsKey(userId))
            {
                userConnections[userId].Add(Context.ConnectionId);
            }
            else
            {
                userConnections.TryAdd(userId, new List<string> { Context.ConnectionId });
            }
        }
    }
}