using Microsoft.AspNetCore.SignalR;

namespace TimeLineViwer.Hub;

public class MessageHub : Hub<IMessageHubClient>
{
    public async Task SendOffersToUser(List<string> message)
    {
        await Clients.All.SendOffersToUser(message);
    }
}
