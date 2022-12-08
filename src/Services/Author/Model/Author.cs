using System.ComponentModel.DataAnnotations;

namespace Author.Model
{
    /// <summary>
    /// Represents the author.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Represents the unique ID for the author.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the name for the author.
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        /// <summary>
        /// Represents the bio for the author.
        /// </summary>
        public string Bio{ get; set; }
    }
}
