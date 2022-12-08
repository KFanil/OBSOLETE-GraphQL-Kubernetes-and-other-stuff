using System.ComponentModel.DataAnnotations;

namespace Post.Api.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Excerpt { get; set; }
        [Required]
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool IsFeaturedPost { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public DateTimeOffset Created_At{ get; set; }

        public DateTimeOffset Updated_At{ get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
}