using Comment.API.Infrastructure;

namespace Comment.API.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(CommentContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Comment> GetComments([ScopedService] CommentContext context) => context.Comments;

        [UseDbContext(typeof(CommentContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Comment> GetCommentsByAuthorId([ScopedService] CommentContext context, int authorId)
        {
            return context.Comments.Where(x => x.AuthorId == authorId);
        }

        [UseDbContext(typeof(CommentContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Comment> GetCommentById([ScopedService] CommentContext context, int id)
        {
            return context.Comments.Where(x => x.Id == id);
        }
        
        [UseDbContext(typeof(CommentContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Comment> GetCommentsByPostId([ScopedService] CommentContext context, int postId)
        {
            return context.Comments.Where(x => x.PostId == postId);
        }
    }
}
