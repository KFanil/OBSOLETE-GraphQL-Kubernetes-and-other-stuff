namespace Comment.API.Dtos
{
    public class NewCommentCreated
    {
        public int AuthorId { get; set; }
        public int PostId { get; set; }

        public string Content { get; set; }
        public DateTimeOffset Created_At { get; set; }

        public DateTimeOffset Updated_At { get; set; }
        public string Path { get; set; }
        public string Event { get; set; }
    }
}
