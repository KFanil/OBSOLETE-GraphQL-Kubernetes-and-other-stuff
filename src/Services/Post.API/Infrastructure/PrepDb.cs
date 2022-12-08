using Microsoft.EntityFrameworkCore;
using Post.Api;

namespace Post.Api.Infrastructure
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _factory = serviceScope.ServiceProvider.GetService<IDbContextFactory<PostContext>>();
                using (var context = _factory.CreateDbContext())
                {
                    SeedData(context, isProd);

                }
            }
        }

        private static void SeedData(PostContext context, bool isProd)
        {
            if (isProd)
            {
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

            if (!context.Posts.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Posts.AddRange(
                    new Model.Post()
                    {
                        Title = "React Testing",
                        Slug = "react-testing",
                        Excerpt = "You can test React components similar to testing other JavaScript code.",

                        Content = @"There are a few ways to test React components. Broadly, they divide into two categories:
Rendering component trees in a simplified test environment and asserting on their output.
Running a complete app in a realistic browser environment(also known as “end - to - end” tests).

This documentation section focuses on testing strategies for the first case. While full end - to - end tests can be very useful to prevent regressions to important workflows, such tests are not concerned with React components in particular, and are out of the scope of this section.
Tradeoffs
When choosing testing tools, it is worth considering a few tradeoffs:
Iteration speed vs Realistic environment: Some tools offer a very quick feedback loop between making a change and seeing the result, but don’t model the browser behavior precisely.Other tools might use a real browser environment, but reduce the iteration speed and are flakier on a continuous integration server.
How much to mock: With components, the distinction between a “unit” and “integration” test can be blurry.If you’re testing a form, should its test also test the buttons inside of it ? Or should a button component have its own test suite ? Should refactoring a button ever break the form test?

 Different answers may work for different teams and products.
 Recommended Tools
 Jest is a JavaScript test runner that lets you access the DOM via jsdom.While jsdom is only an approximation of how the browser works, it is often good enough for testing React components.Jest provides a great iteration speed combined with powerful features like mocking modules and timers so you can have more control over how the code executes.
React Testing Library is a set of helpers that let you test React components without relying on their implementation details.This approach makes refactoring a breeze and also nudges you towards best practices for accessibility.Although it doesn’t provide a way to “shallowly” render a component without its children, a test runner like Jest lets you do this by mocking.
Learn More
This section is divided in two pages:
Recipes: Common patterns when writing tests for React components.
Environments: What to consider when setting up a testing environment for React components.
",
                        FeaturedImageUrl = "https://media.tproger.ru/uploads/2020/12/react-roadmap-2021-cover-icon-original.png",
                        IsFeaturedPost = true,
                        AuthorId = 1,
                        Created_At = DateTimeOffset.Parse("2004-10-19 10:23:54"),
                        Updated_At = DateTimeOffset.Parse("2004-10-19 19:23:54"),
                    }
                );

                if (!context.Categories.Any())
                {
                    Console.WriteLine("--> Seeding Data...");

                    context.Categories.AddRange(
                        new Model.Category()
                        {
                            Name = "Web Development",
                            Slug = "webdev"
                        }
                    );
                    context.Categories.AddRange(
                        new Model.Category()
                        {
                            Name = "Web Testing",
                            Slug = "webtesting"
                        }
                    );
                }
                    context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}