# laget.Azure.Enqueuer
Takes the hassle out of enqueueing simple string messages on an Azure Queue.

Great when you only need to push a simle string, or a dynamic object on a queue, and then forget about it.

![Nuget](https://img.shields.io/nuget/v/laget.Azure.Enqueuer)
![Nuget](https://img.shields.io/nuget/dt/laget.Azure.Enqueuer)

## Usage
```c#
var enqueuer = new laget.Azure.Enqueuer(connectionString, queueName);
```

```c#
var enqueuer = new laget.Azure.Enqueuer(connectionString);
```

```c#
var enqueuer = new laget.Azure.Enqueuer(connectionString, new QueueClientOptions());
```

```c#
using(var enqueuer = new laget.Azure.Enqueuer(connectionString)) {
}
```

```c#
using(var enqueuer = new laget.Azure.Enqueuer(connectionString, new QueueClientOptions())) {
}
```

### Methods
```c#
void Enqueue(dynamic payload);
Task EnqueueAsync(dynamic payload);
void Enqueue(string payload);
Task EnqueueAsync(string payload);
```
