# .NET Client for KubeMQ
.NET client SDK for KubeMQ. Simple interface to work with the KubeMQ server.

# What is KubeMQ:
KubeMQ is a messaging backend for distributed services architecture, delivered as a single Kubernetes service. Easily connects to services and clients, allowing high-scale and high-availability cluster, low-latency and secured implementation of pub-sub, queue messaging patterns and request/reply.

# General SDK description
The SDK implements all communication patterns available through the KubeMQ server:
- pub\sub
- req\rep

# Install via Nuget:
```
  Install-Package WarpTest
```

# Supports:
- .NET Framework 4.6.1
- .NET Standard 2.0


# Configurations
The only required configuration setting is the KubeMQ server address.

Configuration can be set by using one of the following:
- Environment Variable
- `appsettings.json` file
- `app.Config` or `Web.config` file
- Within the code


### Configuration via Environment Variable
Set `KubeMQServerAddress` to the KubeMQ Server Address


### Configuration via appsettings.json
Simply add the following to your appsettings.json:
```JSON
{
  "KubeMQ": {
    "serverAddress": "{YourServerAddress}:{YourServerPort}"
  }
}
```


### Configuration via app.Config
Simply add the following to your app.config:
```xml
<configuration>  
   <configSections>  
    <section name="KubeMQ" type="System.Configuration.NameValueSectionHandler"/>      
  </configSections>  
    
  <KubeMQ>  
    <add key="serverAddress" value="{YourServerAddress}:{YourServerPort}"/>
  </KubeMQ>  
</configuration>
```


### Configuration via code
When setting the KubeMQ server address within the code, simply pass the address as a parameter to the various constructors.
See exactly how in the code examples in this document.


# Usage: Main concepts
TODO: add content for what is unique about the concept of KubeMQ as opose to rabbit & kafka

- **Channel:** Represents the endpoint target. One-to-one or one-to-many. Real-Time Multicast.
- **Group:** Optional parameter when subscribing to a channel. A set of subscribers can define the same group so that only one of the subscribers within the group will receive a specific message. Used mainly for load balancing. Subscribing without the group parameter ensures receiving all the channel messages.
- **Metadata:** The metadata allows to pass additional information with the message. Can be in any form that can be presented as a string, i.e. struct, JSON, XML and many more.
- **Body:** The actual content of the message. Can be in any form that is serializable into byte array, i.e. string, struct, JSON, XML, Collection, binary file and many more.
- **Client Display Name:** Optional field, Displayed in logs, tracing and KubeMQ dashboard.


# Usage: pub\sub
Employing several variations of point to point pub-sub communication style patterns.
Allows to connect a publisher to one or a set of subscribers
- Subscribe to messages
- Send stream
- Send single message

### The `Message` object:
Struct used to send and receive messages using the pub\sub patterns. Contains the following fields (See [Main concepts](#usage-main-concepts) for more details on each field):
- Channel
- Metadata
- Body

### Method: Subscribe
This method allows to subscribe to messages. Both single and stream of messages.
Simply pass a delegate (callback) that will handle the incoming message(s).
The implementation uses `await` and does not block the continuation of the code execution.

**Parameters**:
- Handler - Mandatory. Delegate (callback) that will handle the incoming messages
- Channel - Mandatory. [See Main concepts](#usage-main-concepts)
- Group - Optional. [See Main concepts](#usage-main-concepts)
- clientDisplayName - Optional. [See Main concepts](#usage-main-concepts)

Initialize `Subscriber` with server address from code:
```C#
string serverAddress = "localhost:50000";
Subscriber subscriber = new Subscriber(serverAddress);
```
Initialize `Subscriber` with server address set in configuration:
```C#
Subscriber subscriber = new Subscriber();
```

Subscribe:
```C#
string channel = "Sample.test1";
subscriber.SubscribeToMessages(HandleIncomingMessage, channel);

// delegate to handle the incoming messages
private void HandleIncomingMessage(Message message)
{
...
}
```

### Method: send single
This method allows to send a single message.

**parameters**:
- Message - Mandatory. The actual Message that will be sent
- clientDisplayName - Optional. [See Main concepts](#usage-main-concepts)

Initialize `Sender` with server address from code (also can be initialized using config file):
```C#
 string serverAddress = "localhost:50000";
 Sender sender = new Sender(serverAddress);
 
// Create the message
Message message1 = new Message()
{
    Channel = "Sample.test1",
    Metadata = "A sample string Metadata",
    Body = Tools.Converter.ToByteArray("Pubsub test message")
};
// SendMessage
sender.SendMessage(message1);
```

### Method: send stream
This method allows to send stream of messages.
Use case: a very large file in chunks or very frequently message sending rate.

Initialize `Sender` with server address from code (also can be initialized using config file):
```C#
string serverAddress = "localhost:50000";
Sender sender = new Sender(serverAddress);

Message message;

for (int i = 1; i < 11; i++)
{
    message = CreateSimpleStringMessage(i);
    
    sender.StreamMessage(message);

    Thread.Sleep(1000);
}
sender.ClosesMessageStreamAsync();

 
private Message CreateSimpleStringMessage(int i = 0)
{
    return new Message()
    {
        Channel = "Sample.test1",
        Metadata = "A sample string Metadata",
        Body = Tools.Converter.ToByteArray("Pubsub test message "+ i)
    };
}
```

# Usage: req\rep
Request reply communication pattern. Allows to cache the response at the KubeMQ server.
- Subscribe to requests
- Send request
 
### Cache mechanism
KubeMQ server allows to store each response in a dedicated cache system. Each request can specify whether or not to use the cache.
In case the cache is used, the KubeMQ server will try to return the response directly from cache and reduce latency.

To use the cache mechanism, add the following parameters to each `Request`:
- CacheKey - Unique key to store the response in the KubeMQ cache mechanism.
- CacheTTL - Cahce data Time to live in milliseconds per CacheKey.

In the `Response` object you will receive an indication whether it was returned from cache:
- CacheHit - Indication if the response was returned from KubeMQ cache.

### The `Request` object:
Struct used to send the request under the req\rep pattern. Contains the following fields (See Main concepts for more details on some field):
- ID - Optional. Used to match Request to Response. If omitted it will be set internally.
- Channel - Mandatory. The channel that the `Responder` subscribed on.
- Reply Channel - Read only, set internally.
- Timeout - Mandatory. Max time for the response to return. Set per request. If exceeded an exception is thrown.
- CacheKey - Optional.
- CacheTTL - Optional.
- Metadata - Mandatory.
- Body - Mandatory.

### The `Response` object:
Struct used to send the response under the req\rep pattern. 

The `Response` Constructors requires the corresponding 'Request' object.

Contains the following fields (See Main concepts for more details on some field):
- RequestID - Set internally, used to match Request to Response.
- CacheHit - Set internally, indication if the response was returned from KubeMQ cache.
- Metadata - Mandatory.
- Body - Mandatory.

### Method: Subscribe to requests
This method allows to subscribe to receive requests.

**parameters**:
- Handler - Mandatory. Delegate (callback) that will handle the incoming requests.
- Channel - Mandatory. This sets the channel to send requests to.
- Group - Optional. [See Main concepts](#usage-main-concepts)
- clientDisplayName - Optional. [See Main concepts](#usage-main-concepts)

Initialize `Responder` with server address from code:
```C#
string serverAddress = "localhost:50000";
Responder responder = new Responder(serverAddress);
```

Initialize `Responder` with server address set in configuration:
```C#
Responder responder = new Responder();
```

Subscribe
```C#
string channel = "MyChannel.SimpleRequest";
responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel);

// or with optional parameters:
responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel, "Group1", "clientDisplayName");
```
Handle requests and return responses
```C#
// delegate to handle the incoming requests
private Response HandleIncomingRequests(Request request)
{
    // Convert the request Body to a string
    string strBody = Tools.Converter.FromByteArray(request.Body).ToString();
    logger.LogDebug($"Respond to Request. ID:'{request.ID}', Channel:'{request.Channel}', Body:'{strBody}'");
    
    // Create the Response object
    return new Response(request)
    {
        Metadata = "Response Metadata",
        Body = Tools.Converter.ToByteArray($"A Response to {request.ID}"),
        CacheHit = false
    };
}
```

### Send request methods
The KubeMQ SDK comes with two similar methods to send a `Request` and wait for the `Response`
- `SendRequestAsync` returns the `Response` in a Task
- `SendRequest` returns the `Response` to the Delegate (callback) supplied as a parameter

### Method: send request Async
This method allows to send a request to the `Responder`, it awits for the `Response` and returns it in a Task

**parameters**:
- Request - Mandatory. The `Request` object to send.
- clientDisplayName - Optional. [See Main concepts](#usage-main-concepts)

Initialize `Initiator` with server address from code (also can be initialized using config file):
```C#
string serverAddress = "localhost:50000";
Initiator initiator = new Initiator(serverAddress);
```

Send Request and await for Response
```C#
Request request = new Request()
            {
                Channel = "MyChannel.SimpleRequest",
                Metadata = "MyMetadata",
                Body = Tools.Converter.ToByteArray("A Simple Request."),
                Timeout = 5000,
                CacheKey = "Simple.CacheKey",
                CacheTTL = 5000
            };
            
Response response = await initiator.SendRequest(request);

// can also add clientDisplayName param: 
Response response = await initiator.SendRequest(request, "clientDisplayName");
```
### Method: send request
This method allows to send a request to the `Responder`, and returns the `Response` to the Delegate (callback) supplied as a parameter

```C#
initiator.SendRequest(HandleResponse, request);

// Method to handle the responses
public void HandleResponse(Response response)
{
    ...
}
```

# Tools
The KubeMQ SDK supplies methods to convert from and to the `body` that is in byte array format.
```C#
// Convert the request Body to a string
string strBody = Tools.Converter.FromByteArray(request.Body).ToString();
    
// Convert a string to the request Body
Body = Tools.Converter.ToByteArray("A Simple Request."),
```

# History
**v1.0**
- first version 
