// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: warp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Tradency.Warp.Grpc {

  /// <summary>Holder for reflection information generated from warp.proto</summary>
  public static partial class WarpReflection {

    #region Descriptor
    /// <summary>File descriptor for warp.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WarpReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp3YXJwLnByb3RvEgR3YXJwIgcKBUVtcHR5IjoKB01lc3NhZ2USDwoHQ2hh",
            "bm5lbBgBIAEoCRIQCghNZXRhZGF0YRgCIAEoCRIMCgRCb2R5GAMgASgMIjIK",
            "EFN1YnNjcmliZVJlcXVlc3QSDwoHQ2hhbm5lbBgBIAEoCRINCgVHcm91cBgC",
            "IAEoCSKiAQoHUmVxdWVzdBIKCgJJRBgBIAEoCRIPCgdDaGFubmVsGAIgASgJ",
            "EhAKCE1ldGFkYXRhGAMgASgJEgwKBEJvZHkYBCABKAwSFAoMUmVwbHlDaGFu",
            "bmVsGAUgASgJEg8KB1RpbWVvdXQYBiABKAUSEAoIQ2FjaGVLZXkYByABKAkS",
            "EAoIQ2FjaGVUVEwYCCABKAUSDwoHQ29udGV4dBgJIAEoDCJ2CghSZXNwb25z",
            "ZRIRCglSZXF1ZXN0SUQYASABKAkSFAoMUmVwbHlDaGFubmVsGAIgASgJEhAK",
            "CE1ldGFkYXRhGAMgASgJEgwKBEJvZHkYBCABKAwSEAoIQ2hhY2hIaXQYBSAB",
            "KAgSDwoHQ29udGV4dBgGIAEoDDLGAgoEd2FycBIrCgtTZW5kTWVzc2FnZRIN",
            "LndhcnAuTWVzc2FnZRoLLndhcnAuRW1wdHkiABIzChFTZW5kTWVzc2FnZVN0",
            "cmVhbRINLndhcnAuTWVzc2FnZRoLLndhcnAuRW1wdHkiACgBEj8KElN1YnNj",
            "cmliZVRvQ2hhbm5lbBIWLndhcnAuU3Vic2NyaWJlUmVxdWVzdBoNLndhcnAu",
            "TWVzc2FnZSIAMAESLgoLU2VuZFJlcXVlc3QSDS53YXJwLlJlcXVlc3QaDi53",
            "YXJwLlJlc3BvbnNlIgASLQoMU2VuZFJlc3BvbnNlEg4ud2FycC5SZXNwb25z",
            "ZRoLLndhcnAuRW1wdHkiABI8ChVSZXF1ZXN0UmVzcG9uc2VTdHJlYW0SDi53",
            "YXJwLlJlc3BvbnNlGg0ud2FycC5SZXF1ZXN0IgAoATABQhWqAhJUcmFkZW5j",
            "eS5XYXJwLkdycGNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Tradency.Warp.Grpc.Empty), global::Tradency.Warp.Grpc.Empty.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Tradency.Warp.Grpc.Message), global::Tradency.Warp.Grpc.Message.Parser, new[]{ "Channel", "Metadata", "Body" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Tradency.Warp.Grpc.SubscribeRequest), global::Tradency.Warp.Grpc.SubscribeRequest.Parser, new[]{ "Channel", "Group" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Tradency.Warp.Grpc.Request), global::Tradency.Warp.Grpc.Request.Parser, new[]{ "ID", "Channel", "Metadata", "Body", "ReplyChannel", "Timeout", "CacheKey", "CacheTTL", "Context" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Tradency.Warp.Grpc.Response), global::Tradency.Warp.Grpc.Response.Parser, new[]{ "RequestID", "ReplyChannel", "Metadata", "Body", "ChachHit", "Context" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Empty : pb::IMessage<Empty> {
    private static readonly pb::MessageParser<Empty> _parser = new pb::MessageParser<Empty>(() => new Empty());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Empty> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tradency.Warp.Grpc.WarpReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty(Empty other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty Clone() {
      return new Empty(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Empty);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Empty other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Empty other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class Message : pb::IMessage<Message> {
    private static readonly pb::MessageParser<Message> _parser = new pb::MessageParser<Message>(() => new Message());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Message> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tradency.Warp.Grpc.WarpReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Message() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Message(Message other) : this() {
      channel_ = other.channel_;
      metadata_ = other.metadata_;
      body_ = other.body_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Message Clone() {
      return new Message(this);
    }

    /// <summary>Field number for the "Channel" field.</summary>
    public const int ChannelFieldNumber = 1;
    private string channel_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Channel {
      get { return channel_; }
      set {
        channel_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Metadata" field.</summary>
    public const int MetadataFieldNumber = 2;
    private string metadata_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Metadata {
      get { return metadata_; }
      set {
        metadata_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Body" field.</summary>
    public const int BodyFieldNumber = 3;
    private pb::ByteString body_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Message);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Message other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Channel != other.Channel) return false;
      if (Metadata != other.Metadata) return false;
      if (Body != other.Body) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Channel.Length != 0) hash ^= Channel.GetHashCode();
      if (Metadata.Length != 0) hash ^= Metadata.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Channel.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Channel);
      }
      if (Metadata.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Metadata);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Body);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Channel.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Channel);
      }
      if (Metadata.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Metadata);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Body);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Message other) {
      if (other == null) {
        return;
      }
      if (other.Channel.Length != 0) {
        Channel = other.Channel;
      }
      if (other.Metadata.Length != 0) {
        Metadata = other.Metadata;
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Channel = input.ReadString();
            break;
          }
          case 18: {
            Metadata = input.ReadString();
            break;
          }
          case 26: {
            Body = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SubscribeRequest : pb::IMessage<SubscribeRequest> {
    private static readonly pb::MessageParser<SubscribeRequest> _parser = new pb::MessageParser<SubscribeRequest>(() => new SubscribeRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SubscribeRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tradency.Warp.Grpc.WarpReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRequest(SubscribeRequest other) : this() {
      channel_ = other.channel_;
      group_ = other.group_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRequest Clone() {
      return new SubscribeRequest(this);
    }

    /// <summary>Field number for the "Channel" field.</summary>
    public const int ChannelFieldNumber = 1;
    private string channel_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Channel {
      get { return channel_; }
      set {
        channel_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Group" field.</summary>
    public const int GroupFieldNumber = 2;
    private string group_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Group {
      get { return group_; }
      set {
        group_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SubscribeRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SubscribeRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Channel != other.Channel) return false;
      if (Group != other.Group) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Channel.Length != 0) hash ^= Channel.GetHashCode();
      if (Group.Length != 0) hash ^= Group.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Channel.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Channel);
      }
      if (Group.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Group);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Channel.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Channel);
      }
      if (Group.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Group);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SubscribeRequest other) {
      if (other == null) {
        return;
      }
      if (other.Channel.Length != 0) {
        Channel = other.Channel;
      }
      if (other.Group.Length != 0) {
        Group = other.Group;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Channel = input.ReadString();
            break;
          }
          case 18: {
            Group = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Request : pb::IMessage<Request> {
    private static readonly pb::MessageParser<Request> _parser = new pb::MessageParser<Request>(() => new Request());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Request> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tradency.Warp.Grpc.WarpReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request(Request other) : this() {
      iD_ = other.iD_;
      channel_ = other.channel_;
      metadata_ = other.metadata_;
      body_ = other.body_;
      replyChannel_ = other.replyChannel_;
      timeout_ = other.timeout_;
      cacheKey_ = other.cacheKey_;
      cacheTTL_ = other.cacheTTL_;
      context_ = other.context_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request Clone() {
      return new Request(this);
    }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private string iD_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ID {
      get { return iD_; }
      set {
        iD_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Channel" field.</summary>
    public const int ChannelFieldNumber = 2;
    private string channel_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Channel {
      get { return channel_; }
      set {
        channel_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Metadata" field.</summary>
    public const int MetadataFieldNumber = 3;
    private string metadata_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Metadata {
      get { return metadata_; }
      set {
        metadata_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Body" field.</summary>
    public const int BodyFieldNumber = 4;
    private pb::ByteString body_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ReplyChannel" field.</summary>
    public const int ReplyChannelFieldNumber = 5;
    private string replyChannel_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ReplyChannel {
      get { return replyChannel_; }
      set {
        replyChannel_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Timeout" field.</summary>
    public const int TimeoutFieldNumber = 6;
    private int timeout_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Timeout {
      get { return timeout_; }
      set {
        timeout_ = value;
      }
    }

    /// <summary>Field number for the "CacheKey" field.</summary>
    public const int CacheKeyFieldNumber = 7;
    private string cacheKey_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CacheKey {
      get { return cacheKey_; }
      set {
        cacheKey_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CacheTTL" field.</summary>
    public const int CacheTTLFieldNumber = 8;
    private int cacheTTL_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CacheTTL {
      get { return cacheTTL_; }
      set {
        cacheTTL_ = value;
      }
    }

    /// <summary>Field number for the "Context" field.</summary>
    public const int ContextFieldNumber = 9;
    private pb::ByteString context_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Context {
      get { return context_; }
      set {
        context_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Request);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Request other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ID != other.ID) return false;
      if (Channel != other.Channel) return false;
      if (Metadata != other.Metadata) return false;
      if (Body != other.Body) return false;
      if (ReplyChannel != other.ReplyChannel) return false;
      if (Timeout != other.Timeout) return false;
      if (CacheKey != other.CacheKey) return false;
      if (CacheTTL != other.CacheTTL) return false;
      if (Context != other.Context) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ID.Length != 0) hash ^= ID.GetHashCode();
      if (Channel.Length != 0) hash ^= Channel.GetHashCode();
      if (Metadata.Length != 0) hash ^= Metadata.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (ReplyChannel.Length != 0) hash ^= ReplyChannel.GetHashCode();
      if (Timeout != 0) hash ^= Timeout.GetHashCode();
      if (CacheKey.Length != 0) hash ^= CacheKey.GetHashCode();
      if (CacheTTL != 0) hash ^= CacheTTL.GetHashCode();
      if (Context.Length != 0) hash ^= Context.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ID);
      }
      if (Channel.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Channel);
      }
      if (Metadata.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Metadata);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(34);
        output.WriteBytes(Body);
      }
      if (ReplyChannel.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ReplyChannel);
      }
      if (Timeout != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Timeout);
      }
      if (CacheKey.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(CacheKey);
      }
      if (CacheTTL != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(CacheTTL);
      }
      if (Context.Length != 0) {
        output.WriteRawTag(74);
        output.WriteBytes(Context);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ID);
      }
      if (Channel.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Channel);
      }
      if (Metadata.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Metadata);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Body);
      }
      if (ReplyChannel.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ReplyChannel);
      }
      if (Timeout != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Timeout);
      }
      if (CacheKey.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CacheKey);
      }
      if (CacheTTL != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CacheTTL);
      }
      if (Context.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Context);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Request other) {
      if (other == null) {
        return;
      }
      if (other.ID.Length != 0) {
        ID = other.ID;
      }
      if (other.Channel.Length != 0) {
        Channel = other.Channel;
      }
      if (other.Metadata.Length != 0) {
        Metadata = other.Metadata;
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      if (other.ReplyChannel.Length != 0) {
        ReplyChannel = other.ReplyChannel;
      }
      if (other.Timeout != 0) {
        Timeout = other.Timeout;
      }
      if (other.CacheKey.Length != 0) {
        CacheKey = other.CacheKey;
      }
      if (other.CacheTTL != 0) {
        CacheTTL = other.CacheTTL;
      }
      if (other.Context.Length != 0) {
        Context = other.Context;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ID = input.ReadString();
            break;
          }
          case 18: {
            Channel = input.ReadString();
            break;
          }
          case 26: {
            Metadata = input.ReadString();
            break;
          }
          case 34: {
            Body = input.ReadBytes();
            break;
          }
          case 42: {
            ReplyChannel = input.ReadString();
            break;
          }
          case 48: {
            Timeout = input.ReadInt32();
            break;
          }
          case 58: {
            CacheKey = input.ReadString();
            break;
          }
          case 64: {
            CacheTTL = input.ReadInt32();
            break;
          }
          case 74: {
            Context = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Response : pb::IMessage<Response> {
    private static readonly pb::MessageParser<Response> _parser = new pb::MessageParser<Response>(() => new Response());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tradency.Warp.Grpc.WarpReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response(Response other) : this() {
      requestID_ = other.requestID_;
      replyChannel_ = other.replyChannel_;
      metadata_ = other.metadata_;
      body_ = other.body_;
      chachHit_ = other.chachHit_;
      context_ = other.context_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response Clone() {
      return new Response(this);
    }

    /// <summary>Field number for the "RequestID" field.</summary>
    public const int RequestIDFieldNumber = 1;
    private string requestID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RequestID {
      get { return requestID_; }
      set {
        requestID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ReplyChannel" field.</summary>
    public const int ReplyChannelFieldNumber = 2;
    private string replyChannel_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ReplyChannel {
      get { return replyChannel_; }
      set {
        replyChannel_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Metadata" field.</summary>
    public const int MetadataFieldNumber = 3;
    private string metadata_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Metadata {
      get { return metadata_; }
      set {
        metadata_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Body" field.</summary>
    public const int BodyFieldNumber = 4;
    private pb::ByteString body_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ChachHit" field.</summary>
    public const int ChachHitFieldNumber = 5;
    private bool chachHit_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool ChachHit {
      get { return chachHit_; }
      set {
        chachHit_ = value;
      }
    }

    /// <summary>Field number for the "Context" field.</summary>
    public const int ContextFieldNumber = 6;
    private pb::ByteString context_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Context {
      get { return context_; }
      set {
        context_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RequestID != other.RequestID) return false;
      if (ReplyChannel != other.ReplyChannel) return false;
      if (Metadata != other.Metadata) return false;
      if (Body != other.Body) return false;
      if (ChachHit != other.ChachHit) return false;
      if (Context != other.Context) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RequestID.Length != 0) hash ^= RequestID.GetHashCode();
      if (ReplyChannel.Length != 0) hash ^= ReplyChannel.GetHashCode();
      if (Metadata.Length != 0) hash ^= Metadata.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (ChachHit != false) hash ^= ChachHit.GetHashCode();
      if (Context.Length != 0) hash ^= Context.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RequestID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(RequestID);
      }
      if (ReplyChannel.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ReplyChannel);
      }
      if (Metadata.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Metadata);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(34);
        output.WriteBytes(Body);
      }
      if (ChachHit != false) {
        output.WriteRawTag(40);
        output.WriteBool(ChachHit);
      }
      if (Context.Length != 0) {
        output.WriteRawTag(50);
        output.WriteBytes(Context);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RequestID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RequestID);
      }
      if (ReplyChannel.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ReplyChannel);
      }
      if (Metadata.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Metadata);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Body);
      }
      if (ChachHit != false) {
        size += 1 + 1;
      }
      if (Context.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Context);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Response other) {
      if (other == null) {
        return;
      }
      if (other.RequestID.Length != 0) {
        RequestID = other.RequestID;
      }
      if (other.ReplyChannel.Length != 0) {
        ReplyChannel = other.ReplyChannel;
      }
      if (other.Metadata.Length != 0) {
        Metadata = other.Metadata;
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      if (other.ChachHit != false) {
        ChachHit = other.ChachHit;
      }
      if (other.Context.Length != 0) {
        Context = other.Context;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            RequestID = input.ReadString();
            break;
          }
          case 18: {
            ReplyChannel = input.ReadString();
            break;
          }
          case 26: {
            Metadata = input.ReadString();
            break;
          }
          case 34: {
            Body = input.ReadBytes();
            break;
          }
          case 40: {
            ChachHit = input.ReadBool();
            break;
          }
          case 50: {
            Context = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
