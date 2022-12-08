using Generator;

namespace Aggregator.Model
{
    /// <summary>
    /// Represents the author.
    /// </summary>
    public class Author: Authors_Authors_Author
    {
        public Author(int id, string name, string bio, string photoUrl) : base(id, name, bio, photoUrl)
        {
        }

        ///// <summary>
        ///// Represents the unique ID for the author.
        ///// </summary>
        //[Key]
        //public int Id { get; set; }

        ///// <summary>
        ///// Represents the name for the author.
        ///// </summary>
        //[Required]
        //public string Name { get; set; }

        ///// <summary>
        ///// Represents the bio for the author.
        ///// </summary>
        //public string Bio{ get; set; }

        public List<Comment> Comments { get; set; }
    }
}
