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
    public DateTime TimeStamp { get; set; }


}

public class PostVM
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public int UserName { get; set; }   
    public string Content { get; set; }
    public string MediaURL { get; set; }
    public DateTime TimeStamp { get; set; }


}

