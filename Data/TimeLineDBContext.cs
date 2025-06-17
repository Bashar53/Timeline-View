using Microsoft.EntityFrameworkCore;
using TimeLineViwer.Models;

namespace TimeLineViwer.Data
{
    public class TimeLineDBContext : DbContext
    {
        public TimeLineDBContext(DbContextOptions<TimeLineDBContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }  
    }
}
