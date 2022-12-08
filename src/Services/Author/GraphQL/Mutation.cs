using Author.Infrastructure;
using Author.Model;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace Author.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AuthorContext))]
        public async Task<Model.Author> AddAuthorAsync(Model.AddAuthorInput authorInput, [ScopedService] AuthorContext context)
        {
            var author = new Model.Author { Name = authorInput.Name, Bio = authorInput.Bio };
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }
    }
} 
