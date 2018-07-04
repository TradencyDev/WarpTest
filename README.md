# .NET Client for Navio
.NET client SDK for Navio. Simple interface to work with the Navio server.


# General description
text to describe general functionality
- pub\sub
- req\rep

# Supports:
- .NET Framework 4.6.1
- .NET Standard 2.0

# Install via nuget:
```
  Install-Package WarpTest
```
# Configuration
The Navio Server Address can be set in the code or via Configuration.
Configuration can be set by using one of the following:
- Environment Variable
- `appsettings.json` file
- `app.Config` file

### Configuration via Environment Variable
 Set `NavioServerAddress` to the Navio Server Address

### Configuration via appsettings.json
Configuration may be done via your appsettings.json.
```JSON
{
  "Navio": {
    "serverAddress": "localhost:50000"
  }
}
```

### Configuration via app.Config
Configuration may be done via your app.config. The only config required is `serverAddress`:
```xml
<configuration>  
   <configSections>  
    <section name="Navio" type="System.Configuration.NameValueSectionHandler"/>      
  </configSections>  
    
  <Navio>  
    <add key="serverAddress" value="localhost:50000"/>
  </Navio>  
</configuration>
```

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
