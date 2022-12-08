namespace Post.Api.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(PostContext))]
        public async Task<Model.Post> AddAuthorAsync(Model.AddPostInput postInput, [ScopedService] PostContext context)
        {
            var author = new Model.Post { Title = postInput.title, Slug = postInput.slug, Excerpt = postInput.excerpt, 
                Content = postInput.content, FeaturedImageUrl = postInput.featuredImageUrl };
            context.Posts.Add(author);
            await context.SaveChangesAsync();
            return author;
        }
    }
} 
