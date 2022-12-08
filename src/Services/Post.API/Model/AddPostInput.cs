namespace Post.Api.Model
{
    public record AddPostInput(string title, string slug, string excerpt, string content, string featuredImageUrl, int[] catregoriesId = null);
}