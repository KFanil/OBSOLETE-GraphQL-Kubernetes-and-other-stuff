using Aggregator.GraphQL;
using Aggregator.GraphQL.Types;
using Generator;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<AuthorType>()
    .AddType<CommentType>()
    .AddType<PostPreviewType>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();;

builder.Services
    .AddAuthorAPIClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{builder.Configuration["AuthorAPI"]}graphql"));

builder.Services
    .AddCommentAPIClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{builder.Configuration["CommentAPI"]}graphql"));

builder.Services
    .AddPostAPIClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{builder.Configuration["PostAPI"]}graphql"));
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder =>
    builder
      .WithOrigins("http://localhost:3000")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials()
  );

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.MapGet("/", () => "Hello World!");

app.Run();
