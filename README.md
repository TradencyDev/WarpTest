# .NET Client for Navio
.NET client SDK for Navio. Simple interface to work with the Navio server.

# What is Navio:
Navio is a messaging backend for distributed services architecture, delivered as a single Kubernetes service. Easily connects to services and clients, allowing high-scale and high-availability cluster, low-latency and secured implementation of pub-sub, queue messaging patterns and request/reply.

# General SDK description
The SDK implements all communication patterns available through the Navio server:
- pub\sub
- req\rep

# Install via nuget:
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

- Channel: represents the endpoint/s target/s. One-to-one or one-to-many. Real-Time Multicast
- Group: logical grouping. One of the group for each and every group. all endpoints with no group (the Empty group)
- Metadata: the metadata allows to pass additional information with the message. can be in any form that can be presented as a string, i.e. struct, JSON, XML and many more.

- Body: the actual content of the message. can be in any form that is serializable into byte array, i.e. string, struct, JSON, XML, Collection, binary file and many more.

- Client Display Name. optional. Displayed by API


# Usage: pub\sub
Employing several variations of point to point pub-sub communication style patterns.
Allows to connects a publisher to one or a set of subscribers
- Subscribe to messages.
- Send stream
- Send single message

### Method: subscribe
This method allows to subscribe to messages. Both single and stream of messages.
Pass a delegte (cllback) that will handle the incoming messages
The implementation wait for a message ("awit for a task", not bloking not polling)
parameters:
handler - mandatory. delegte (cllback) that will handle the incoming messages
Channel - mandatory. see Main concepts
Group  - optional. see Main concepts
clientDisplayName - optional. Client Display Name.

```C#
// init
string serverAddress = "localhost:50000";
Subscriber subscriber = new Subscriber(serverAddress);

// if you set the serverAddress in  config
Subscriber subscriber = new Subscriber();

// Subscribe
string channel = "Sample.test1";
subscriber.SubscribeToMessages(HandleIncomingMessage, channel);

// delegate to handle the incoming messages
private void HandleIncomingMessage(Message message)
{
...
}
```

### Method: send single
This method allows to send a single message
parameters:
Message - mandatory. Message to send. 
clientDisplayName - optional. Client Display Name.

Message object fields:
Channel
Metadata
Body

```C#
 // initialize Sender with server address or use configuration
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
This method allows to send messages to stream
use case: a very large file in chunks or very frequently message sending rate 

```C#
 // init with server address in code 
 string serverAddress = "localhost:50000";
 Sender sender = new Sender(serverAddress);
 
 // TODO: add creation of many messages... 
 sender.StreamMessage(message);
 sender.ClosesMessageStreamAsync()
 
```

# Usage: req\rep
Two way communication patteren, enables Cache stored at Navio server.
- subscribe to requests
- send request
 
### Cache mechanism
Cache, CacheKey, CacheTTL, CacheHit
- CacheKey  Key to store cache
- CacheTTL  Cahce data Time to live
- CacheHit  Flag of the retuned data origin


### The Request objet:
explain here all the Request objet fields:
Reply Channel is set internally, no need to do it  
Timeout
Cache, CacheKey, CacheTTL, CacheHit
ID - set internally used to mutch RequestID to Response
Channel, Metadata, Body

### Response object:
explain here all the Response objet fields:
RequestID - set internally, For read use only
ReplyChannel - Reply Channel is set internally, no need to do it  
CacheHit - Flag of the retuned data origin
Metadata
Body

### Method: subscribe to requests
This method allows to subscribe to stream of messages. 
parameters:
handler - mandatory. delegte (cllback) that will handle the incoming requests
Channel - mandatory. see Main concepts
Group  - optional. see Main concepts
clientDisplayName - optional. Client Display Name.


```C#
// init with server address in code:
string serverAddress = "localhost:50000";
Responder responder = new Responder(serverAddress);

// if you set the serverAddress in  config
Responder responder = new Responder();


// Subscribe
string channel = "MyChannel.SimpleRequest";
responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel);

// Same, With more params:
responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel, "Group1", "clientDisplayName");

// delegate to handle the incoming requests
private Response HandleIncomingRequests(Request request)
{
...
}

```

### Method: send request
This method allows to subscribe to stream of messages

```C#
 // init with server address in code:
string serverAddress = "localhost:50000";
Initiator initiator = new Initiator(serverAddress);

// init with server address set in configuration:
Initiator initiator = new Initiator();

// Send Request
Request request = new Request()
            {
                Channel = "MyChannel.SimpleRequest",
                Metadata = "MyMetadata",
                Body = Tools.Converter.ToByteArray("A Simple Request."),
                Timeout = 5000, // Need to explain this
                CacheKey = "", // Need to explain this
                CacheTTL = 0 // Need to explain this
            };
            
Response response = initiator.SendRequest(request);

// can also add clientDisplayName param: 
Response response = initiator.SendRequest(request, "clientDisplayName");

```
# Supports:
- .NET Framework 4.6.1
- .NET Standard 2.0

# History
**v1.0**
- first version
