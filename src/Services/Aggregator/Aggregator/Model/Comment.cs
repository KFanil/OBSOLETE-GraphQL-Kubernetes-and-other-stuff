using Generator;

namespace Aggregator.Model
{
    /// <summary>
    /// Represents the comment.
    /// </summary>
    public class Comment: Comments_Comments_Comment
    {
        public Comment(int id, int authorId, int postId, string content, DateTimeOffset created_At, DateTimeOffset updated_At, string path) : base(id, authorId, postId, content, created_At, updated_At, path)
        {
        }
        public Author Author { get; set; } 
    }
}
