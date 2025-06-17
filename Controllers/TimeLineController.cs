using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TimeLineViwer.Hub;

namespace TimeLineViwer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLineController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public TimeLineController(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;

        }
        [HttpPost]
        [Route("posts")]
        public string Get()
        {
            List<string> posts = new List<string>();
            
            messageHub.Clients.All.SendOffersToUser(posts);
            return "posts created!";
        }
    }
}
