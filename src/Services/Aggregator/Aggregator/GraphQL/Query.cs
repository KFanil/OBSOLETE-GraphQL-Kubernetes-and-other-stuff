using Generator;

namespace Aggregator.GraphQL
{
    public class Query
    {
        private IAuthorAPIClient _authorAPIClient { get; set; }
        private ICommentAPIClient _commentAPIClient{ get; set; }
        private IPostAPIClient _postAPIClient { get; set; }

        public Query(IAuthorAPIClient authorAPIClient, ICommentAPIClient commentAPIClient, IPostAPIClient postAPIClient)
        {
            _authorAPIClient = authorAPIClient;
            _commentAPIClient = commentAPIClient;
            _postAPIClient = postAPIClient;
        }

        //[UseFiltering]
        //[UseSorting]
        public async Task<IQueryable<Model.Author>> GetAuthorsAsync() 
        {
            var result = await _authorAPIClient.Authors.ExecuteAsync();
            IReadOnlyList<Model.Author>? authors = Mapper.MapIReadOnlyListIAuthors_AuthorsToModelAuthors(result.Data.Authors);
            return authors.AsQueryable();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<IQueryable<Model.Comment>> GetCommentsAsync()
        {
            var result = await _commentAPIClient.Comments.ExecuteAsync();
            var comments = Mapper.MapIReadOnlyListIComments_CommentsToModelAuthors(result.Data.Comments);
            return comments.AsQueryable();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Model.PostPreview>> GetPostsAsync()
        {
            var result = await _postAPIClient.Posts.ExecuteAsync();
            var t = Mapper.MapIReadOnlyListIPosts_Posts_EdgesToModelAuthors(result.Data.Posts.Edges);
            return t.AsQueryable();
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Model.Category>> GetCategoriesAsync()
        {
            var result = await _postAPIClient.Categories.ExecuteAsync();
            var t = Mapper.MapIReadOnlyListICategories_CategoriesToModelAuthors(result.Data.Categories);
            return t.AsQueryable();
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Model.Comment>> GetCommentByPostId(int postId)
        {
            StrawberryShake.IOperationResult<IGetCommentsByPostIdResult>? result = await _commentAPIClient.GetCommentsByPostId.ExecuteAsync(postId);
            var comments = Mapper.MapIGetCommentsByPostId_CommentsByPostIdToModelAuthors(result.Data.CommentsByPostId);
            return comments.AsQueryable();
        }
    }
}
