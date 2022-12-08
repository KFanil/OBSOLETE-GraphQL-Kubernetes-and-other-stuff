using Comment.API.Dtos;
using Comment.API.EventBus;
using Comment.API.Infrastructure;

namespace Comment.API.GraphQL
{
    public class Mutation
    {
        private IMessageBusClient _messageBusClient;

        public Mutation(IMessageBusClient messageBusClient)
        {
            _messageBusClient = messageBusClient;
        }

        [UseDbContext(typeof(CommentContext))]
        public async Task<Model.Comment> AddCommentAsync(Model.AddCommentInput commentInput, [ScopedService] CommentContext context)
        {
            var comment = new Model.Comment{PostId = commentInput.PostId, AuthorId = commentInput.AuthorId, Content = commentInput.Content,
            Created_At = commentInput.Created_At, Updated_At = commentInput.Created_At, Path = ""};
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            try
            {
                var newCommentCreated = new NewCommentCreated { AuthorId = comment.AuthorId, PostId = comment.PostId, Content = comment.Content, 
                    Created_At = comment.Created_At, Updated_At = comment.Updated_At};
                newCommentCreated.Event = "New_Comment_Created";
                _messageBusClient.PublishNewComment(newCommentCreated);
            }
            catch (Exception ex)
            {

            }
            return comment;
        }
    }
}
