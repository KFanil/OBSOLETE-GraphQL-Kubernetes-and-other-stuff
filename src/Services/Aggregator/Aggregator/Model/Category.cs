namespace Aggregator.Model
{
    public class Category
    {
        public Category(global::System.Int32 id, global::System.String name, global::System.String slug, global::System.Collections.Generic.IReadOnlyList<global::System.Collections.Generic.IReadOnlyList<global::Generator.Categories_Categories_Posts_Post>>? posts)
        {
            Id = id;
            Name = name;
            Slug = slug;
            Posts = posts;
        }

        public global::System.Int32 Id { get; }

        public global::System.String Name { get; }

        public global::System.String Slug { get; }

        /// <summary>
        /// This is the list of categories
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::System.Collections.Generic.IReadOnlyList<global::Generator.Categories_Categories_Posts_Post>>? Posts { get; }

        public virtual global::System.Boolean Equals(Category? other)
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

            return (Id == other.Id) && Name.Equals(other.Name) && Slug.Equals(other.Slug) && global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(Posts, other.Posts);
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

            return Equals((Category)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * Id.GetHashCode();
                hash ^= 397 * Name.GetHashCode();
                hash ^= 397 * Slug.GetHashCode();
                if (Posts != null)
                {
                    foreach (var Posts_elm in Posts)
                    {
                        foreach (var Posts_elm_elm in Posts_elm)
                        {
                            hash ^= 397 * Posts_elm_elm.GetHashCode();
                        }
                    }
                }

                return hash;
            }
        }
    }
}
