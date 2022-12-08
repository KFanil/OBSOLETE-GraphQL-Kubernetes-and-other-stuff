namespace Comments.SignalrHub.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEventAsync(string message);
    }
}