using Microsoft.EntityFrameworkCore;

namespace Comment.API.Infrastructure
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _factory = serviceScope.ServiceProvider.GetService<IDbContextFactory<CommentContext>>();
                using (var context = _factory.CreateDbContext())
                {
                    SeedData(context, isProd);

                }
            }
        }

        private static void SeedData(CommentContext context, bool isProd)
        {
            return;
            if (isProd)
            {
                Console.WriteLine("--> 2Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.Comments.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Comments.AddRange(
                    new Model.Comment()
                    {
                        AuthorId = 1,
                        PostId = 1,
                        Content = "First Comment Content",
                        Created_At = DateTimeOffset.Parse("2004-10-19 10:23:54"),
                        Updated_At = DateTimeOffset.Parse("2004-10-19 19:23:54"),
                        Path = "First Comment Path"
                    },
                    new Model.Comment()
                    {
                        AuthorId = 1,
                        PostId= 1,
                        Content = "Second Comment Content",
                        Created_At = DateTimeOffset.Parse("2005-10-19 10:23:54"),
                        Updated_At = DateTimeOffset.Parse("2005-10-19 19:23:54"),
                        Path = "Second Comment Path"
                    },
                    new Model.Comment()
                    {
                        AuthorId = 1,
                        PostId  = 2,
                        Content = "Third Comment Content",
                        Created_At = DateTimeOffset.Parse("2006-10-19 10:23:54"),
                        Updated_At = DateTimeOffset.Parse("2006-10-19 19:23:54"),
                        Path = "Third Comment Path"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}