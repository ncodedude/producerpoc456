namespace WepAPIProducerPOC.ServiceBus
{
    public interface IServiceBusSender
    {
        Task SendMessageAsync<T>(T message);
    }
}
