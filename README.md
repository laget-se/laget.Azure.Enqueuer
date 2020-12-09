# laget.Azure.Enqueuer
Takes the hassle out of enqueueing simple string messages on a Azure queue.

Great when you only need to push a simle string, or a dynamic object on a queue, and then forget about it.

```c#
var enqueuer = new laget.Azure.Enqueuer(connectionString);
```

```c#
var enqueuer = new laget.Azure.Enqueuer(connectionString, new ueueClientOptions());
```

```c#
using(var enqueuer = new laget.Azure.Enqueuer(connectionString)) {
}
```

```c#
using(var enqueuer = new laget.Azure.Enqueuer(connectionString, new ueueClientOptions())) {
}
```

### Methods
```c#
void Enqueue(dynamic payload);
Task EnqueueAsync(dynamic payload);
void Enqueue(string payload);
Task EnqueueAsync(string payload);
```