using System.ComponentModel.DataAnnotations;

namespace TimeLineViwer.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }
    public int UserId { get; set; }
    [Required(ErrorMessage = "Content is required.")]
    [StringLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
    public string Content { get; set; }
    [StringLength(500, ErrorMessage = "MediaURL cannot exceed 500 characters.")]
    public string MediaURL { get; set; }    
    public string TimeStamp { get; set; }
    public ICollection<User>? Users { get; set; }   


}
