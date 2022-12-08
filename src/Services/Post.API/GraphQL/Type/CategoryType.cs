using Microsoft.EntityFrameworkCore;

namespace Post.Api.GraphQL.Type
{
    public class CategoryType: ObjectType<Model.Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Model.Category> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Description("Represents the post.");

            descriptor
                .Field(p => p.Posts)
                .ResolveWith<Resolvers>(p => p.GetPosts(default!, default!))
                .UseDbContext<PostContext>()
                .Description("This is the list of categories");

        }

        private class Resolvers
        {
            public IQueryable<ICollection<Model.Post>>? GetPosts([Parent] Model.Category category, [ScopedService ]PostContext context)
            {
                IQueryable<ICollection<Model.Post>>? posts = context.Categories.Include(p => p.Posts).Where(x => x.Id == category.Id).Select(x => x.Posts);
                return posts;
            }
        }
    }
}
