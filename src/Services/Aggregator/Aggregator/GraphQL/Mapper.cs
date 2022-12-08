using Generator;

namespace Aggregator.GraphQL
{
    public class Mapper
    {
        public static IReadOnlyList<Model.Author> MapIReadOnlyListIAuthors_AuthorsToModelAuthors(IReadOnlyList<IAuthors_Authors> authors_Authors)
        {
            List<Model.Author> authors = new List<Model.Author>(authors_Authors.Count);
            foreach (var author in authors_Authors)
            {
                authors.Add(new Model.Author(author.Id, author.Name, author.Bio, author.PhotoUrl));
            }
            return authors;
        }

        public static IReadOnlyList<Model.Comment> MapIReadOnlyListIComments_CommentsToModelAuthors(IReadOnlyList<IComments_Comments> comments_Comments)
        {
            List<Model.Comment> comments = new List<Model.Comment>(comments_Comments.Count);
            foreach (var comment in comments_Comments)
            {
                comments.Add(new Model.Comment(comment.Id, comment.AuthorId, comment.PostId,
                    comment.Content, comment.Created_At, comment.Updated_At, comment.Path));
            }
            return comments;
        }
        public static IReadOnlyList<Model.Comment> MapIGetCommentsByPostId_CommentsByPostIdToModelAuthors(IReadOnlyList<IGetCommentsByPostId_CommentsByPostId> comments_Comments)
        {
            List<Model.Comment> comments = new List<Model.Comment>(comments_Comments.Count);
            foreach (var comment in comments_Comments)
            {
                comments.Add(new Model.Comment(comment.Id, comment.AuthorId, comment.PostId,
                    comment.Content, comment.Created_At, comment.Updated_At, comment.Path));
            }
            return comments;
        }

        public static IReadOnlyList<Model.PostPreview> MapIReadOnlyListIPosts_Posts_EdgesToModelAuthors(IReadOnlyList<IPosts_Posts_Edges> posts_Posts_Edges)
        {
            List<Model.PostPreview> postPreviews = new(posts_Posts_Edges.Count);
            foreach (var post in posts_Posts_Edges)
            {
                List<List<Posts_Posts_Edges_Node_Categories_Category>>? categories = new();
                if (post.Node.Categories != null)
                {
                    foreach (var Categories_elm in post.Node.Categories)
                    {
                        var list = new List<Posts_Posts_Edges_Node_Categories_Category>(Categories_elm.Count);
                        foreach (var Category in Categories_elm)
                        {
                            Posts_Posts_Edges_Node_Categories_Category posts_Posts_Edges_Node_Categories_Category = new(Category.Id, Category.Name, Category.Slug);
                            list.Add(posts_Posts_Edges_Node_Categories_Category);
                        }
                        categories.Add(list);
                    }
                }
                postPreviews.Add(new Model.PostPreview(post.Node.Id, post.Node.Title, post.Node.Slug, post.Node.Excerpt, post.Node.Content, post.Node.FeaturedImageUrl,
                    post.Node.IsFeaturedPost, post.Node.AuthorId, post.Node.Created_At, post.Node.Updated_At, categories));
            }
            return postPreviews;
        }
        public static IReadOnlyList<Model.Category> MapIReadOnlyListICategories_CategoriesToModelAuthors(IReadOnlyList<global::Generator.ICategories_Categories> categories_Categories)
        {
            List<Model.Category> categories = new(categories_Categories.Count);
            foreach (var category in categories_Categories)
            {
                List<List<Categories_Categories_Posts_Post>>? posts = new();
                if (category.Posts != null)
                {
                    foreach (var category_posts in category.Posts)
                    {
                        var list = new List<Categories_Categories_Posts_Post>(category_posts.Count);
                        foreach (var post in category_posts)
                        {
                            Categories_Categories_Posts_Post posts_Posts_Edges_Node_Categories_Category = new(post.Id,post.Title,post.Slug,post.Excerpt,post.Content,
                                post.FeaturedImageUrl,post.IsFeaturedPost,post.AuthorId,post.Created_At,post.Updated_At);
                            list.Add(posts_Posts_Edges_Node_Categories_Category);
                        }
                        posts.Add(list);
                    }
                }

                categories.Add(new Model.Category(category.Id, category.Name,category.Slug, posts));
            }
            return categories;
        }
    }
}
