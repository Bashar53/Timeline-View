using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Resources;
using TimeLineViwer.Data;
using TimeLineViwer.Hub;
using TimeLineViwer.Models;

namespace TimeLineViwer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLineController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> _messageHub;
        private readonly TimeLineDBContext _context;
        public TimeLineController(IHubContext<MessageHub, IMessageHubClient> messageHub, TimeLineDBContext context)
        {
            _messageHub = _messageHub;
            _context = context;

        }
        [HttpGet("{userid:int}")]
        public async Task<ActionResult<PostVM>> GetPost(int userid)
        {
            var result =  await _context.Posts.Where(x => x.UserId == userid).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("posts")]
        public async Task<ActionResult<Post>> CraetePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = post.PostId }, post);
        }
    }
}
