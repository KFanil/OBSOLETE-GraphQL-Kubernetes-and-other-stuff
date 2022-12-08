using Generator;

namespace Aggregator.GraphQL.Types
{
    public class AuthorType:ObjectType<Model.Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Model.Author> descriptor)
        {
            base.Configure(descriptor);
            descriptor
                .Field(f => f.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!));
        }

        private class Resolvers
        {
            private ICommentAPIClient _commentAPIClient { get; set; }
            public Resolvers(ICommentAPIClient commentAPIClient)
            {
                _commentAPIClient = commentAPIClient;
            }
            public async Task<IQueryable<GetCommentsByAuthorId_CommentsByAuthorId_Comment>> GetComments([Parent] Model.Author author)
            {
                var result = await _commentAPIClient.GetCommentsByAuthorId.ExecuteAsync(author.Id);
                var comments = result.Data.CommentsByAuthorId.Cast<GetCommentsByAuthorId_CommentsByAuthorId_Comment>();
                return comments.AsQueryable();
            }
        }
    }
}
