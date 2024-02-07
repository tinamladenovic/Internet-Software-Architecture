public interface IMessageService
{
    Task StartAsync(CancellationToken cancellationToken);
}