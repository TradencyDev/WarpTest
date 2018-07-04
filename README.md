# .NET Client for Navio
.NET client SDK for Navio. Simple interface to work with the Navio server.

# What is Navio:
Navio is a messaging backend for distributed services architecture, delivered as a single Kubernetes service. Easily connects to services and clients, allowing high-scale and high-availability cluster, low-latency and secured implementation of pub-sub, queue messaging patterns and request/reply.

# General SDK description
The SDK implements all communication patterns available through the Navio server:
- pub\sub
- req\rep

# Supports:
- .NET Framework 4.6.1
- .NET Standard 2.0

# Install via nuget:
```
  Install-Package WarpTest
```


# Configurations
The only required configuration setting is the Navio server address.

Configuration can be set by using one of the following:
- Environment Variable
- `appsettings.json` file
- `app.Config` file
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

- Channel: 
- Group: 
- Metadata: the metadata allows to pass additional information with the message.
- Body: the actual content of the message. can be in any form that is serializable into byte array, i.e. string, struct, JSON, XML, Collection and many more.


# Usage: pub\sub
Employing several variations of point to point pub-sub communication style patterns.
- Subscribe to messages
- Send stream
- Send single message

### Method: subscribe
This method allows to subscribe to messages. Both single and stream of messages.

```C#
// init
string serverAddress = "localhost:50000";
Subscriber wrapper = new Subscriber(serverAddress);

// Subscribe
string channel = "Sample.test1";
wrapper.SubscribeToMessages(HandleIncomingMessage, channel);
            
private void HandleIncomingMessage(Message message)
{
}
```

### Method: send single
This method allows to subscribe to stream of messages

```C#
 // init
 string serverAddress = "localhost:50000";
 Sender wrapper = new Sender(serverAddress);
 
 // SendMessage
Message message1 = new Message()
{
    Channel = "Sample.test1",
    Metadata = "A sample string Metadata",
    Body = Tools.Converter.ToByteArray("Pubsub test message")
};
wrapper.SendMessage(message1);
```

### Method: send stream
This method allows to subscribe to stream of messages

```C#
 
```

# Usage: req\rep
This allows to do something
- subscribe to requests
- send request

### Method: subscribe to requests
This method allows to subscribe to stream of messages

```C#
// init
string serverAddress = "localhost:50000";
Responder listener = new Responder(serverAddress);

// Subscribe
string channel = "MyChannel.SimpleRequest";
listener.SubscribeToRequestsAsync(HandleIncomingRequests, channel);

private Response HandleIncomingRequests(Request request)
{
...
}

```

### Method: send request
This method allows to subscribe to stream of messages

```C#
 // init
string serverAddress = "localhost:50000";
Initiator wrapper = new Initiator(serverAddress);

// Send Request
Request request = new Request()
            {
                Channel = "MyChannel.SimpleRequest",
                Metadata = "MyMetadata",
                Body = Tools.Converter.ToByteArray("A Simple Request."),
                Timeout = 5000,
                CacheKey = "",
                CacheTTL = 0
            };
            
Response response = wrapper.SendRequest(request);

```

# History
**v1.0**
- first version
