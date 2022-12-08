using Microsoft.EntityFrameworkCore;
using Post.Api;

namespace Post.Api.GraphQL.Type
{
    public class PostType: ObjectType<Model.Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Model.Post> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Description("Represents the post.");

            descriptor
                .Field(p => p.Categories)
                .ResolveWith<Resolvers>(p => p.GetCategories(default!, default!))
                .UseDbContext<PostContext>()
                .Description("This is the list of categories");

        }

        private class Resolvers
        {
            public IQueryable<ICollection<Model.Category>>? GetCategories([Parent] Model.Post post, [ScopedService ]PostContext context)
            {
                IQueryable<ICollection<Model.Category>>? categories = context.Posts.Include(p => p.Categories).Where(x => x.Id == post.Id).Select(x => x.Categories);
                return categories;
            }
        }
    }
}
