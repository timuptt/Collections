using Microsoft.AspNetCore.SignalR;

namespace Collections.Web.Hubs;

public class CommentsHub : Hub
{
    public Task JoinGroup(string group)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, group);
    }

    public Task SendMessageToGroup(string group, int userProfileId, string userName, string body)
    {
        return Clients.OthersInGroup(group).SendAsync("ReceiveMessage", userProfileId, userName, body);
    }
}