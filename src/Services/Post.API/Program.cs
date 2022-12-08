using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Post.Api.Infrastructure;
using Post.Api.GraphQL;
using Post.Api.GraphQL.Type;
using Post.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<PostContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
                )
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PostType>()
                .AddType<CategoryType>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();

var app = builder.Build();
//app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});
app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
