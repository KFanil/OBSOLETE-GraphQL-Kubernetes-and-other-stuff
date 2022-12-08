namespace Author.GraphQL.Type
{
    public class AuthorType: ObjectType<Model.Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Model.Author> descriptor)
        {
            descriptor.Description("Represents the author.");
            // descriptor.Field(a => a.Id).Ignore();
            base.Configure(descriptor);
        }
    }
}
