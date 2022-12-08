using Aggregator.Model;
using Generator;

namespace Aggregator.GraphQL.Types
{
    public class CommentType:ObjectType<Model.Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Model.Comment> descriptor)
        {
            base.Configure(descriptor);
            descriptor
                .Field(f => f.Author)
                .ResolveWith<Resolvers>(r => r.GetAuthors(default!));
        }

        private class Resolvers
        {
            private IAuthorAPIClient _authorAPIClient { get; set; }
            public Resolvers(IAuthorAPIClient authorAPIClient)
            {
                _authorAPIClient = authorAPIClient;
            }
            public async Task<IQueryable<Author>> GetAuthors([Parent] Comment comment)
            {
                var result = await _authorAPIClient.GetAuthorById.ExecuteAsync(comment.AuthorId);
                var authors = new List<Author>(result.Data.AuthorById.Count);

                foreach (var authorById in result.Data.AuthorById)
                {
                    authors.Add(new Author(authorById.Id, authorById.Name, authorById.Bio, authorById.PhotoUrl));
                }
                return authors.AsQueryable();
            }
        }
    }
}
