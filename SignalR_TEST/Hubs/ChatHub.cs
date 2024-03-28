using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace SignalR_TEST.Hubs
{
    internal class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, string> _onlineUsers = new ConcurrentDictionary<string, string>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            _onlineUsers.TryAdd(Context.ConnectionId, Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string connectionId;
            _onlineUsers.TryRemove(Context.ConnectionId, out connectionId!);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
