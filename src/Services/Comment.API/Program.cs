using Comment.API.EventBus;
using Comment.API.GraphQL;
using Comment.API.GraphQL.Types;
using Comment.API.Infrastructure;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<CommentContext>(opt =>
                    opt.UseNpgsql(builder.Configuration.GetConnectionString("CommandConStr"))
                )
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<CommentType>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

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

app.MapGet("/", () => "Hello World!");

PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
