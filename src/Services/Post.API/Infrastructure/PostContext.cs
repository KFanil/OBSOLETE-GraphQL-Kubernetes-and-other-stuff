using Microsoft.EntityFrameworkCore;

namespace Post.Api
{
    public class PostContext: DbContext
    {

        public DbSet<Model.Post>? Posts { get; set; }
        public DbSet<Model.Category>? Categories { get; set; }

        public PostContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Model.Post>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Posts);

            modelBuilder
                .Entity<Model.Category>()
                .HasMany(p => p.Posts)
                .WithMany(p => p.Categories);
        }
    }
}
