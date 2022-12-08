using System.ComponentModel.DataAnnotations;

namespace Comment.API.Model
{
    /// <summary>
    /// Represents the comment.
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PostId { get;set; }
        [Required]
        public string Content { get; set; }
        public DateTimeOffset Created_At{ get; set; }
        public DateTimeOffset Updated_At{ get; set; }
        public string Path { get; set; }
    }
}
