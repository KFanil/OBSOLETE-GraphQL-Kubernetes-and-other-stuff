using Microsoft.AspNetCore.SignalR;

namespace Comments.SignalrHub.Hubs
{
    public class CommentsNotificationsHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Message", "Successfully connected");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Caller.SendAsync("Message", "Successfully disconnected");
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SubscribePost(int postId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Post-{postId}");
            await Clients.Caller.SendAsync("Message", "Successfully subscribed");
        }
        public async Task UnsubscribePost(int postId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Post-{postId}");
            await Clients.Caller.SendAsync("Message", "Successfully unsubscribed");
        }
    }
}