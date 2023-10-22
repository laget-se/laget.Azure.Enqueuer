using Azure.Storage.Queues;
using laget.Azure.Extensions;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace laget.Azure
{
    public interface IEnqueuer
    {
        void Enqueue(object payload, CancellationToken cancellationToken = default);
        Task EnqueueAsync(object payload, CancellationToken cancellationToken = default);
        void Enqueue(string payload, CancellationToken cancellationToken = default);
        Task EnqueueAsync(string payload, CancellationToken cancellationToken = default);
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

        public void Enqueue(object payload, CancellationToken cancellationToken = default)
        {
            Send(payload, cancellationToken);
        }

        public async Task EnqueueAsync(object payload, CancellationToken cancellationToken = default)
        {
            await SendAsync(payload, cancellationToken);
        }

        public void Enqueue(string payload, CancellationToken cancellationToken = default)
        {
            Send(payload, cancellationToken);
        }

        public async Task EnqueueAsync(string payload, CancellationToken cancellationToken = default)
        {
            await SendAsync(payload, cancellationToken);
        }

        private void Send(string payload, CancellationToken cancellationToken = default) =>
            _client.SendMessage(payload.ToBase64(), cancellationToken);

        private void Send(object payload, CancellationToken cancellationToken = default) =>
            _client.SendMessage(JsonConvert.SerializeObject(payload).ToBase64(), cancellationToken);

        private async Task SendAsync(string payload, CancellationToken cancellationToken = default) => await
            _client.SendMessageAsync(payload.ToBase64(), cancellationToken);

        private async Task SendAsync(object payload, CancellationToken cancellationToken = default) => await
            _client.SendMessageAsync(JsonConvert.SerializeObject(payload).ToBase64(), cancellationToken);

        public void Dispose()
        {
            _ = _client == null;
        }
    }
}
