using Comment.API.Dtos;

namespace Comment.API.EventBus
{
    public interface IMessageBusClient
    {
        void PublishNewComment(NewCommentCreated newCommentCreated);
    }
}
