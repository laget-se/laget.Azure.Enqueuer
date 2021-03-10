using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using laget.Azure.Extensions;
using Newtonsoft.Json;

namespace laget.Azure
{
    public interface IEnqueuer
    {
        void Enqueue(object payload);
        Task EnqueueAsync(object payload);
        void Enqueue(string payload);
        Task EnqueueAsync(string payload);
    }

    public class Enqueuer : IEnqueuer, IDisposable
    {
        private readonly QueueClient _client;

        public Enqueuer(string connectionString, string queueName)
        {
            _client = new QueueClient(connectionString, queueName);
        }

        public Enqueuer(string connectionString, QueueClientOptions options)
        {
            _client = new QueueClient(new Uri(connectionString), options);
        }

        public Enqueuer(string connectionString)
            : this(connectionString, new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 })
        {
        }

        public void Enqueue(object payload)
        {
            Send(payload);
        }

        public async Task EnqueueAsync(object payload)
        {
            await SendAsync(payload);
        }

        public void Enqueue(string payload)
        {
            Send(payload);
        }

        public async Task EnqueueAsync(string payload)
        {
            await SendAsync(payload);
        }

        private void Send(string payload) =>
            _client.SendMessage(payload.ToBase64());

        private void Send(object payload) =>
            _client.SendMessage(JsonConvert.SerializeObject(payload).ToBase64());

        private async Task SendAsync(string payload) => await
            _client.SendMessageAsync(payload.ToBase64());

        private async Task SendAsync(object payload) => await
            _client.SendMessageAsync(JsonConvert.SerializeObject(payload).ToBase64());

        public void Dispose()
        {
            _ = _client == null;
        }
    }
}
