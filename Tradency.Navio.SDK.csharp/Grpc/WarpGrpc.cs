// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: warp.proto
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace Tradency.Navio.Grpc {
  public static partial class warp
  {
    static readonly string __ServiceName = "warp.warp";

    static readonly grpc::Marshaller<global::Tradency.Navio.Grpc.Message> __Marshaller_Message = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Tradency.Navio.Grpc.Message.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Tradency.Navio.Grpc.Empty> __Marshaller_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Tradency.Navio.Grpc.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Tradency.Navio.Grpc.SubscribeRequest> __Marshaller_SubscribeRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Tradency.Navio.Grpc.SubscribeRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Tradency.Navio.Grpc.Request> __Marshaller_Request = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Tradency.Navio.Grpc.Request.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Tradency.Navio.Grpc.Response> __Marshaller_Response = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Tradency.Navio.Grpc.Response.Parser.ParseFrom);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty> __Method_SendMessage = new grpc::Method<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendMessage",
        __Marshaller_Message,
        __Marshaller_Empty);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty> __Method_SendMessageStream = new grpc::Method<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "SendMessageStream",
        __Marshaller_Message,
        __Marshaller_Empty);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.SubscribeRequest, global::Tradency.Navio.Grpc.Message> __Method_SubscribeToChannel = new grpc::Method<global::Tradency.Navio.Grpc.SubscribeRequest, global::Tradency.Navio.Grpc.Message>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeToChannel",
        __Marshaller_SubscribeRequest,
        __Marshaller_Message);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.Request, global::Tradency.Navio.Grpc.Response> __Method_SendRequest = new grpc::Method<global::Tradency.Navio.Grpc.Request, global::Tradency.Navio.Grpc.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendRequest",
        __Marshaller_Request,
        __Marshaller_Response);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Empty> __Method_SendResponse = new grpc::Method<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendResponse",
        __Marshaller_Response,
        __Marshaller_Empty);

    static readonly grpc::Method<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Request> __Method_RequestResponseStream = new grpc::Method<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Request>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "RequestResponseStream",
        __Marshaller_Response,
        __Marshaller_Request);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Tradency.Navio.Grpc.WarpReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of warp</summary>
    public abstract partial class warpBase
    {
      /// <summary>
      /// SendMessage - publish single message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// message_timeout - Optional, set timeout in millisecnd for verification of delivery
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Tradency.Navio.Grpc.Empty> SendMessage(global::Tradency.Navio.Grpc.Message request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// SendMessageStream - publish constant stream of pub Message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Tradency.Navio.Grpc.Empty> SendMessageStream(grpc::IAsyncStreamReader<global::Tradency.Navio.Grpc.Message> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// SubscribeToChannel - listening to pub messages
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task SubscribeToChannel(global::Tradency.Navio.Grpc.SubscribeRequest request, grpc::IServerStreamWriter<global::Tradency.Navio.Grpc.Message> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// SendRequest - sending request with timeout
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Tradency.Navio.Grpc.Response> SendRequest(global::Tradency.Navio.Grpc.Request request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// SendResponse - sending single response in case a client cannot support bi-di streaming
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Tradency.Navio.Grpc.Empty> SendResponse(global::Tradency.Navio.Grpc.Response request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// RequestResponseStream - bi-di streams of getting request / sending replies
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// channel - the channel we subscribe for getting requests
      /// group - the gropu we subscirbe for getting requests
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task RequestResponseStream(grpc::IAsyncStreamReader<global::Tradency.Navio.Grpc.Response> requestStream, grpc::IServerStreamWriter<global::Tradency.Navio.Grpc.Request> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for warp</summary>
    public partial class warpClient : grpc::ClientBase<warpClient>
    {
      /// <summary>Creates a new client for warp</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public warpClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for warp that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public warpClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected warpClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected warpClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// SendMessage - publish single message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// message_timeout - Optional, set timeout in millisecnd for verification of delivery
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Empty SendMessage(global::Tradency.Navio.Grpc.Message request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendMessage(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendMessage - publish single message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// message_timeout - Optional, set timeout in millisecnd for verification of delivery
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Empty SendMessage(global::Tradency.Navio.Grpc.Message request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendMessage, null, options, request);
      }
      /// <summary>
      /// SendMessage - publish single message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// message_timeout - Optional, set timeout in millisecnd for verification of delivery
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Empty> SendMessageAsync(global::Tradency.Navio.Grpc.Message request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendMessageAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendMessage - publish single message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// message_timeout - Optional, set timeout in millisecnd for verification of delivery
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Empty> SendMessageAsync(global::Tradency.Navio.Grpc.Message request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendMessage, null, options, request);
      }
      /// <summary>
      /// SendMessageStream - publish constant stream of pub Message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty> SendMessageStream(grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendMessageStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendMessageStream - publish constant stream of pub Message
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::Tradency.Navio.Grpc.Message, global::Tradency.Navio.Grpc.Empty> SendMessageStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_SendMessageStream, null, options);
      }
      /// <summary>
      /// SubscribeToChannel - listening to pub messages
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::Tradency.Navio.Grpc.Message> SubscribeToChannel(global::Tradency.Navio.Grpc.SubscribeRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SubscribeToChannel(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SubscribeToChannel - listening to pub messages
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::Tradency.Navio.Grpc.Message> SubscribeToChannel(global::Tradency.Navio.Grpc.SubscribeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeToChannel, null, options, request);
      }
      /// <summary>
      /// SendRequest - sending request with timeout
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Response SendRequest(global::Tradency.Navio.Grpc.Request request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendRequest(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendRequest - sending request with timeout
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Response SendRequest(global::Tradency.Navio.Grpc.Request request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendRequest, null, options, request);
      }
      /// <summary>
      /// SendRequest - sending request with timeout
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Response> SendRequestAsync(global::Tradency.Navio.Grpc.Request request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendRequestAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendRequest - sending request with timeout
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Response> SendRequestAsync(global::Tradency.Navio.Grpc.Request request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendRequest, null, options, request);
      }
      /// <summary>
      /// SendResponse - sending single response in case a client cannot support bi-di streaming
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Empty SendResponse(global::Tradency.Navio.Grpc.Response request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendResponse(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendResponse - sending single response in case a client cannot support bi-di streaming
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Tradency.Navio.Grpc.Empty SendResponse(global::Tradency.Navio.Grpc.Response request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendResponse, null, options, request);
      }
      /// <summary>
      /// SendResponse - sending single response in case a client cannot support bi-di streaming
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Empty> SendResponseAsync(global::Tradency.Navio.Grpc.Response request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SendResponseAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// SendResponse - sending single response in case a client cannot support bi-di streaming
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Tradency.Navio.Grpc.Empty> SendResponseAsync(global::Tradency.Navio.Grpc.Response request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendResponse, null, options, request);
      }
      /// <summary>
      /// RequestResponseStream - bi-di streams of getting request / sending replies
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// channel - the channel we subscribe for getting requests
      /// group - the gropu we subscirbe for getting requests
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Request> RequestResponseStream(grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return RequestResponseStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// RequestResponseStream - bi-di streams of getting request / sending replies
      /// Metadata Paramters:
      /// client_tag - a string that represent the client connection
      /// channel - the channel we subscribe for getting requests
      /// group - the gropu we subscirbe for getting requests
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Tradency.Navio.Grpc.Response, global::Tradency.Navio.Grpc.Request> RequestResponseStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_RequestResponseStream, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override warpClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new warpClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(warpBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendMessage, serviceImpl.SendMessage)
          .AddMethod(__Method_SendMessageStream, serviceImpl.SendMessageStream)
          .AddMethod(__Method_SubscribeToChannel, serviceImpl.SubscribeToChannel)
          .AddMethod(__Method_SendRequest, serviceImpl.SendRequest)
          .AddMethod(__Method_SendResponse, serviceImpl.SendResponse)
          .AddMethod(__Method_RequestResponseStream, serviceImpl.RequestResponseStream).Build();
    }

  }
}
#endregion