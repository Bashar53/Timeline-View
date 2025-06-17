using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLineViwer.Models
{
    public class User
    {
        [Key]   
        public int UserId { get; set; }
        public string UserName { get; set; }
        

    }
}
