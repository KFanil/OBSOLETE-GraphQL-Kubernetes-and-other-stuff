using Microsoft.EntityFrameworkCore;
using Author.Model;

namespace Author.Infrastructure
{
    public class AuthorContext: DbContext
    {
        public DbSet<Model.Author>? Authors { get; set; }

        public AuthorContext(DbContextOptions options) : base(options)
        {

        }
    }
}
