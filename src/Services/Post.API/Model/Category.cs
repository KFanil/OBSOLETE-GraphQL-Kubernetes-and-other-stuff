using System.ComponentModel.DataAnnotations;

namespace Post.Api.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}