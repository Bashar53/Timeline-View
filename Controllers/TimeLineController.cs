using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TimeLineViwer.Data;
using TimeLineViwer.Hub;

namespace TimeLineViwer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLineController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        private readonly TimeLineDBContext _context;


        public TimeLineController(IHubContext<MessageHub, IMessageHubClient> _messageHub, TimeLineDBContext context)
        {
            messageHub = _messageHub;
            context = _context;

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
