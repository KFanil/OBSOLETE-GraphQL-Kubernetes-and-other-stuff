using Aggregator.Model;
using Generator;

namespace Aggregator.GraphQL.Types
{
    public class PostPreviewType: ObjectType<PostPreview>
    {
        protected override void Configure(IObjectTypeDescriptor<PostPreview> descriptor)
        {
            base.Configure(descriptor);
            descriptor
                .Field(f => f.Author)
                .ResolveWith<Resolvers>(r => r.GetAuthors(default!));
            descriptor
                .Field(f => f.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!));
        }

        private class Resolvers
        {
            private ICommentAPIClient _commentAPIClient { get; set; }
            private IAuthorAPIClient _authorAPIClient{ get; set; }
            public Resolvers(ICommentAPIClient commentAPIClient, IAuthorAPIClient authorAPIClient)
            {
                _commentAPIClient = commentAPIClient;
                _authorAPIClient = authorAPIClient;
            }
            public async Task<IQueryable<Comment>> GetComments([Parent] PostPreview postPreview)
            {
                var result = await _commentAPIClient.GetCommentsByPostId.ExecuteAsync(postPreview.Id);
                var comments = new List<Comment>(result.Data.CommentsByPostId.Count);
                foreach (var comment in result.Data.CommentsByPostId)
                {
                    comments.Add(new Comment(comment.Id, comment.AuthorId, comment.PostId, comment.Content, comment.Created_At, comment.Updated_At, comment.Path));
                }
                return comments.AsQueryable();
            }
            public async Task<IQueryable<Author>> GetAuthors([Parent] PostPreview postPreview)
            {
                var result = await _authorAPIClient.GetAuthorById.ExecuteAsync(postPreview.AuthorId);
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
