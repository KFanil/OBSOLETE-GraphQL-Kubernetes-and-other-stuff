namespace Aggregator.Model
{
    public record AddCommentInput(int PostId, int AuthorId, string Content, DateTimeOffset Created_At, DateTimeOffset Updated_At);
}
