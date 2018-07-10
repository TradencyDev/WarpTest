# .NET Client for Navio
.NET client SDK for Navio. Simple interface to work with the Navio server.

# What is Navio:
Navio is a messaging backend for distributed services architecture, delivered as a single Kubernetes service. Easily connects to services and clients, allowing high-scale and high-availability cluster, low-latency and secured implementation of pub-sub, queue messaging patterns and request/reply.

# General SDK description
The SDK implements all communication patterns available through the Navio server:
- pub\sub
- req\rep

# Install via Nuget:
```
  Install-Package WarpTest
```


# Configurations
The only required configuration setting is the Navio server address.

Configuration can be set by using one of the following:
- Environment Variable
- `appsettings.json` file
- `app.Config` or `Web.config` file
- Within the code


### Configuration via Environment Variable
Set `NavioServerAddress` to the Navio Server Address


### Configuration via appsettings.json
Simply add the following to your appsettings.json:
```JSON
{
  "Navio": {
    "serverAddress": "ServerAddress:ServerPort"
  }
}
```


### Configuration via app.Config
Simply add the following to your app.config:
```xml
<configuration>  
   <configSections>  
    <section name="Navio" type="System.Configuration.NameValueSectionHandler"/>      
  </configSections>  
    
  <Navio>  
    <add key="serverAddress" value="ServerAddress:ServerPort"/>
  </Navio>  
</configuration>
```


### Configuration via code
When setting the Navio server address within the code, simply pass the address as a parameter to the various constructors.
See exactly how in the code examples in this document.


# Usage: Main concepts
TODO: add content for what is unique about the concept of Navio as opose to rabbit & kafka

- Channel: Represents the endpoint target. One-to-one or one-to-many. Real-Time Multicast.
- Group: Logical grouping. Only one endpoint in each group will receive the message. Endpoint may be configured with no group value to always receive the channel messages.
- Metadata: The metadata allows to pass additional information with the message. Can be in any form that can be presented as a string, i.e. struct, JSON, XML and many more.
- Body: The actual content of the message. Can be in any form that is serializable into byte array, i.e. string, struct, JSON, XML, Collection, binary file and many more.
- Client Display Name: Optional field, Displayed in logs, tracing and Navio dashboard.


# Usage: pub\sub
Employing several variations of point to point pub-sub communication style patterns.
Allows to connect a publisher to one or a set of subscribers
- Subscribe to messages
- Send stream
- Send single message

### The `Message` object:
Struct used to send and receive messages using the pub\sub patterns. Contains the following fields (See Main concepts for more details on each field):
- Channel
- Metadata
- Body

### Method: Subscribe
This method allows to subscribe to messages. Both single and stream of messages.
Simply pass a delegate (callback) that will handle the incoming message(s).
The implementation uses `await` and does not block the continuation of the code execution.

**Parameters**:
- handler - Mandatory. Delegate (callback) that will handle the incoming messages
- Channel - Mandatory. See Main concepts
- Group - Optional. See Main concepts
- clientDisplayName - Optional. See Main concepts

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
- clientDisplayName - Optional. See Main concepts

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
Request reply communication pattern. Allows to cache the response at the Navio server.
- Subscribe to requests
- Send request
 
### Cache mechanism
Navio server allows to store each response in a dedicated cache system. Each request can specify whether or not to use the cache.
In case the cache is used, the Navio server will try to return the response directly from cache and reduce latency.

To use the cache mechanism, add the following parameters to each `Request`:
- CacheKey - Unique key to store the response in the Navio cache mechanism.
- CacheTTL - Cahce data Time to live in milliseconds per CacheKey.

In the `Response` object you will receive an indication whether it was returned from cache:
- CacheHit - Indication if the response was returned from Navio cache.

### The `Request` object:
Struct used to send the request under the req\rep pattern. Contains the following fields (See Main concepts for more details on some field):
- ID - Used to match Request to Response. If neglected it will be set internally. 
- Channel - The channel that the `Responder` subscribed on.
- Reply Channel - Read only, Set internally.
- Timeout - Max time for the response to return. Set per request. If exceeded an exception is thrown.
- CacheKey
- CacheTTL
- Metadata
- Body

### The `Response` object:
Struct used to send the response under the req\rep pattern. 

The `Response` Constructors requires the corresponding 'Request' object.

Contains the following fields (See Main concepts for more details on some field):
- RequestID - Set internally, used to match Request to Response.
- CacheHit - Indication if the response was returned from Navio cache.
- Metadata
- Body

### Method: Subscribe to requests
This method allows to subscribe to receive requests.

**parameters**:
- Handler - Mandatory. Delegate (callback) that will handle the incoming requests.
- Channel - Mandatory. This sets the channel to send requests to.
- Group - Optional. See Main concepts
- clientDisplayName - Optional. See Main concepts

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

### Method: send request
This method allows to send a request to the `Responder`

**parameters**:
- Request - Mandatory. The `Request` object to send.
- clientDisplayName - Optional. See Main concepts

Initialize `Initiator` with server address from code (also can be initialized using config file):
```C#
string serverAddress = "localhost:50000";
Initiator initiator = new Initiator(serverAddress);
```

Send Request
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
            
Response response = initiator.SendRequest(request);

// can also add clientDisplayName param: 
Response response = initiator.SendRequest(request, "clientDisplayName");
```

# Tools
The Navio SDK supplies converters to convert from and to the `body` that is in byte array format.
```C#
// Convert the request Body to a string
string strBody = Tools.Converter.FromByteArray(request.Body).ToString();
    
// Convert a string to the request Body
Body = Tools.Converter.ToByteArray("A Simple Request."),
```

# Supports:
- .NET Framework 4.6.1
- .NET Standard 2.0

# History
**v1.0**
- first version
