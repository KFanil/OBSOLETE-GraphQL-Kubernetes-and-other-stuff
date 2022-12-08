using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityService
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _factory = serviceScope.ServiceProvider.GetService<IDbContextFactory<BlogContext>>();
                if(_factory != null)
                {
                    using (var context = _factory.CreateDbContext())
                    {
                        SeedData(context, isProd);

                    }
                }
            }
        }

        private static void SeedData(BlogContext context, bool isProd)
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
        }
    }
}