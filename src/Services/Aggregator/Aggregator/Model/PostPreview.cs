using Generator;

namespace Aggregator.Model
{
    public partial class PostPreview : global::System.IEquatable<Posts_Posts_Edges_Node_Post>
    {
        public PostPreview(int id, global::System.String title, global::System.String slug, global::System.String excerpt, global::System.String content, global::System.String featuredImageUrl, global::System.Boolean isFeaturedPost, global::System.Int32 authorId, global::System.DateTimeOffset created_At,
            global::System.DateTimeOffset updated_At, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.IEnumerable<global::Generator.Posts_Posts_Edges_Node_Categories_Category>>? categories)
        {
            Id = id;
            Title = title;
            Slug = slug;
            Excerpt = excerpt;
            Content = content;
            FeaturedImageUrl = featuredImageUrl;
            IsFeaturedPost = isFeaturedPost;
            AuthorId = authorId;
            Created_At = created_At;
            Updated_At = updated_At;
            Categories = categories;
        }

        public global::System.Int32 Id { get; }

        public global::System.String Title { get; }

        public global::System.String Slug { get; }

        public global::System.String Excerpt { get; }

        public global::System.String Content { get; }

        public global::System.String FeaturedImageUrl { get; }

        public global::System.Boolean IsFeaturedPost { get; }

        public global::System.Int32 AuthorId { get; }

        public global::System.DateTimeOffset Created_At { get; }

        public global::System.DateTimeOffset Updated_At { get; }

        public Author Author{ get; set; }
        public IEnumerable<Comment> Comments { get; set; }


        /// <summary>
        /// This is the list of categories
        /// </summary>
        public global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.IEnumerable<global::Generator.Posts_Posts_Edges_Node_Categories_Category>>? Categories { get; }

        public virtual global::System.Boolean Equals(Posts_Posts_Edges_Node_Post? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Id == other.Id) && Title.Equals(other.Title) && Slug.Equals(other.Slug) && Excerpt.Equals(other.Excerpt) && Content.Equals(other.Content) && FeaturedImageUrl.Equals(other.FeaturedImageUrl) && IsFeaturedPost == other.IsFeaturedPost && AuthorId == other.AuthorId && Created_At.Equals(other.Created_At) && Updated_At.Equals(other.Updated_At) && global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(Categories, other.Categories);
        }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Posts_Posts_Edges_Node_Post)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * Id.GetHashCode();
                hash ^= 397 * Title.GetHashCode();
                hash ^= 397 * Slug.GetHashCode();
                hash ^= 397 * Excerpt.GetHashCode();
                hash ^= 397 * Content.GetHashCode();
                hash ^= 397 * FeaturedImageUrl.GetHashCode();
                hash ^= 397 * IsFeaturedPost.GetHashCode();
                hash ^= 397 * AuthorId.GetHashCode();
                hash ^= 397 * Created_At.GetHashCode();
                hash ^= 397 * Updated_At.GetHashCode();
                if (Categories != null)
                {
                    foreach (var Categories_elm in Categories)
                    {
                        foreach (var Categories_elm_elm in Categories_elm)
                        {
                            hash ^= 397 * Categories_elm_elm.GetHashCode();
                        }
                    }
                }

                return hash;
            }
        }
    }
}
