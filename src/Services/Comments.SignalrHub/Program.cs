using Comments.SignalrHub.EventProcessing;
using Comments.SignalrHub.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddSingleton<IEventProcessor, EventProcessor>();

builder.Services.AddHostedService<MessageBusSubscriber>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapRazorPages();
app.MapHub<CommentsNotificationsHub>("/hub/commentsnotificationhub");

app.Run();