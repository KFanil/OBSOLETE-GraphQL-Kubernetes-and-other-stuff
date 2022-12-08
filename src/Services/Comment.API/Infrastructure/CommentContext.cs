using Microsoft.EntityFrameworkCore;

namespace Comment.API.Infrastructure
{
    public class CommentContext: DbContext
    {
        public DbSet<Model.Comment>? Comments { get; set; }

        public CommentContext(DbContextOptions options) : base(options)
        {

        }
    }
}
