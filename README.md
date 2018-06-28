# .NET Client for Warp
.NET client SDK for Warp. Simple interface to work with the Warp server. Install via nuget with
```
  Install-Package WarpTest
```
Supports 
- .NET Framework 4.6.1
- .NET Standard 2.0

# Configuration via app.Config
Configuration may be done via your app.config. The only config required is `serverAddress`:
```
<configuration>
  <name="serverAddress" value="localhost:50000"/>
</configuration>
```

# General description
text to describe general functionality
- pub\sub
- req\rep

# Usage: pub\sub
This allows to do something
- subscribe
- send

### Method: subscribe
This method allows to subscribe to stream of messages

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

### Method: send
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
