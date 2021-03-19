using Microsoft.AspNetCore.SignalR;
using SignalRSampleService.Hubs.Handlers;
using System;
using System.Threading.Tasks;

namespace SignalRSampleService.Hubs.Hubs
{
    public class ViewHub : Hub
    {
        public static int ViewCount { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }


        public async Task NotifyWatching()
        {
            ViewCount = UserHandler.ConnectedIds.Count;

            // notify EVERYONE about new view count
            await Clients.All.SendAsync("viewCountUpdate", ViewCount);
        }
    }
}
