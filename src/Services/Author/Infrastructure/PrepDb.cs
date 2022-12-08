using Microsoft.EntityFrameworkCore;

namespace Author.Infrastructure
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _factory = serviceScope.ServiceProvider.GetService<IDbContextFactory<AuthorContext>>();
                using (var context = _factory.CreateDbContext())
                {
                    SeedData(context, isProd);

                }
            }
        }

        private static void SeedData(AuthorContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> 222222222222222222222222222Context is null ..." + (context == null).ToString());
                Console.WriteLine("--> context.Database is null ..." + (context.Database == null).ToString());
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.Authors.Any())
            {
                Console.WriteLine("--> 1Seeding Data...");

                context.Authors.AddRange(
                    new Model.Author() { Name = "First Author Name", Bio = "First Author Bio", PhotoUrl= "https://thumbs.dreamstime.com/b/continuous-one-line-drawing-abstract-face-minimalism-162885946.jpg" },
                    new Model.Author() { Name = "Second Author Name", Bio = "Second Author Bio", PhotoUrl = "https://thumbs.dreamstime.com/b/continuous-one-line-drawing-abstract-face-minimalism-162885946.jpg" },
                    new Model.Author() { Name = "Third Author Name", Bio = "Third Author Bio", PhotoUrl = "https://thumbs.dreamstime.com/b/continuous-one-line-drawing-abstract-face-minimalism-162885946.jpg" }
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