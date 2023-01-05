using ChatApp.DAL;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _context;

        public ChatHub(AppDbContext context)
        {
            _context=context;
        }


        public async Task SendMessage(string user, string userColor, string message ,string group)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(userColor) || string.IsNullOrEmpty(message))
            {
                return;
            }

            await _context.AddAsync(new Models.Message(user, userColor, message,group));
            await _context.SaveChangesAsync();

            await Clients.Group(group).SendAsync("ReceiveMessage", user, userColor, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }


        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
