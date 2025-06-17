using System.ComponentModel.DataAnnotations;

namespace TimeLineViwer.Models
{
    public class User
    {
        [Key]   
        public int UserId { get; set; }
        public string UserName { get; set; }
       
    }
}
