using Author.GraphQL;
using Author.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using Author.GraphQL.Type;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<AuthorContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
                )
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<AuthorType>()
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
