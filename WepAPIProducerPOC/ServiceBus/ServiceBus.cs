using Azure.Messaging.ServiceBus;
using System.Text;
using System.Text.Json;

namespace WepAPIProducerPOC.ServiceBus
{
    public class ServiceBusSender : IServiceBusSender
    {
        private readonly string _connectionString = "Endpoint=sb://pocservicebus456.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8lvZ8CKkDV4qxMFXnEdM2ckVTitRVBN0R+ASbPrB61c=";
        private readonly string _queueName = "paymentqueue";


        public async Task SendMessageAsync<T>(T message)
        {
            await using (var client = new ServiceBusClient(_connectionString))
            {
                var sender = client.CreateSender(_queueName);
                var messageBody = JsonSerializer.Serialize(message);
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

                await sender.SendMessageAsync(serviceBusMessage);
            }
        }
    }
}
