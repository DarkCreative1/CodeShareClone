using Microsoft.AspNetCore.SignalR;
using CodeShareClone.Models;

namespace CodeShareClone.Hubs
{
    public class CodeHub : Hub
    {
        private readonly AppDbContext _context;

        public CodeHub(AppDbContext context)
        {
            _context = context;
        }

        public async Task JoinRoom(string codeId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, codeId);
        }

        public async Task BroadcastContent(string codeId, string content)
        {
            await Clients.OthersInGroup(codeId).SendAsync("ReceiveContent", content);
        }

        public async Task PersistContent(string codeId, string content)
        {
            if (Guid.TryParse(codeId, out var guid))
            {
                var code = await _context.Codes.FindAsync(guid);
                if (code != null)
                {
                    code.Content = content;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}