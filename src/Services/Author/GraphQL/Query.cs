using Author.Infrastructure;

namespace Author.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AuthorContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Author> GetAuthors([ScopedService] AuthorContext context) => context.Authors;


        [UseDbContext(typeof(AuthorContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Author> GetAuthorById([ScopedService] AuthorContext context, int id)
        {
            return context.Authors.Where(x => x.Id == id);
        }
    }
}
