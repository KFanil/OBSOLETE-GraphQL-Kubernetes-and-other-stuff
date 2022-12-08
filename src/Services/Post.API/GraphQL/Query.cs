namespace Post.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(PostContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Post> GetPosts([ScopedService] PostContext context) => context.Posts;

        [UseDbContext(typeof(PostContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Category> GetCategories([ScopedService] PostContext context) => context.Categories;
    }
}
