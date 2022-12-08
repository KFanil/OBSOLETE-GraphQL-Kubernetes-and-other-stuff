using Generator;

namespace Aggregator.GraphQL
{
    public class Mutation
    {

        private ICommentAPIClient _commentAPIClient { get; set; }
        public Mutation(ICommentAPIClient commentAPIClient)
        {
            _commentAPIClient = commentAPIClient;
        }

        public async Task<Model.Comment> AddCommentAsync(Model.AddCommentInput commentInput)
        {
            StrawberryShake.IOperationResult<IAddCommentResult>? result = await _commentAPIClient.AddComment.ExecuteAsync(commentInput.PostId, 
                commentInput.AuthorId, commentInput.Content, commentInput.Created_At, commentInput.Updated_At);
            IAddComment_AddComment? resultComment = result.Data.AddComment;
            var comment = new Model.Comment(resultComment.Id, resultComment.AuthorId,resultComment.PostId,
                resultComment.Content, resultComment.Created_At, resultComment.Updated_At, "");
            return comment;
        }
    }
}
