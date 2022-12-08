using System;
using System.Text.Json;
using Comments.SignalrHub.Dtos;
using Comments.SignalrHub.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Comments.SignalrHub.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHubContext<CommentsNotificationsHub> _commentsNotificationsHub;

        public EventProcessor(IServiceScopeFactory scopeFactory, IHubContext<CommentsNotificationsHub> commentsNotificationsHub)
        {
            _scopeFactory = scopeFactory;
            _commentsNotificationsHub = commentsNotificationsHub;
        }

        public async Task ProcessEventAsync(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.NewCommentCreated:
                    await newCommentAddedAsync(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch (eventType.Event)
            {
                case "New_Comment_Created":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.NewCommentCreated;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private async Task newCommentAddedAsync(string newCommentCreated)
        {
            using (var scope = _scopeFactory.CreateScope())
            {

                var newCommentCreatedDto = JsonSerializer.Deserialize<NewCommentCreated>(newCommentCreated);

                try
                {
                    if(newCommentCreatedDto!= null)
                        await _commentsNotificationsHub.Clients.Group($"Post-{newCommentCreatedDto.PostId}").SendAsync("ReceiveComment", newCommentCreatedDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        NewCommentCreated,
        Undetermined
    }
}