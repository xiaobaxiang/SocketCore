// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: settingsTimeSpan.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from settingsTimeSpan.proto</summary>
  public static partial class SettingsTimeSpanReflection {

    #region Descriptor
    /// <summary>File descriptor for settingsTimeSpan.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SettingsTimeSpanReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZzZXR0aW5nc1RpbWVTcGFuLnByb3RvEglTb2NrZXRDbWQibQoQU2V0dGlu",
            "Z3NUaW1lU3BhbhIPCgdjbWRDb2RlGAEgASgJEhAKCGlkZW50aXR5GAIgASgJ",
            "EhIKCm9wcG9zaXRlSWQYAyABKAkSEAoIc2VydmVySWQYBiABKA0SEAoIdGlt",
            "ZVNwYW4YGCABKA1iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.SettingsTimeSpan), global::SocketCmd.SettingsTimeSpan.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ServerId", "TimeSpan" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SettingsTimeSpan : pb::IMessage<SettingsTimeSpan> {
    private static readonly pb::MessageParser<SettingsTimeSpan> _parser = new pb::MessageParser<SettingsTimeSpan>(() => new SettingsTimeSpan());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SettingsTimeSpan> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.SettingsTimeSpanReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsTimeSpan() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsTimeSpan(SettingsTimeSpan other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      serverId_ = other.serverId_;
      timeSpan_ = other.timeSpan_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsTimeSpan Clone() {
      return new SettingsTimeSpan(this);
    }

    /// <summary>Field number for the "cmdCode" field.</summary>
    public const int CmdCodeFieldNumber = 1;
    private string cmdCode_ = "";
    /// <summary>
    ///命令号
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CmdCode {
      get { return cmdCode_; }
      set {
        cmdCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "identity" field.</summary>
    public const int IdentityFieldNumber = 2;
    private string identity_ = "";
    /// <summary>
    ///socket对象标识
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Identity {
      get { return identity_; }
      set {
        identity_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "oppositeId" field.</summary>
    public const int OppositeIdFieldNumber = 3;
    private string oppositeId_ = "";
    /// <summary>
    ///操作对端对象标识[可选]
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OppositeId {
      get { return oppositeId_; }
      set {
        oppositeId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "serverId" field.</summary>
    public const int ServerIdFieldNumber = 6;
    private uint serverId_;
    /// <summary>
    ///string timeToken = 4;//时间戳yyyy-MM-dd HH:mm:ss.fff
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ServerId {
      get { return serverId_; }
      set {
        serverId_ = value;
      }
    }

    /// <summary>Field number for the "timeSpan" field.</summary>
    public const int TimeSpanFieldNumber = 24;
    private uint timeSpan_;
    /// <summary>
    ///设置上报时间间隔
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TimeSpan {
      get { return timeSpan_; }
      set {
        timeSpan_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SettingsTimeSpan);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SettingsTimeSpan other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CmdCode != other.CmdCode) return false;
      if (Identity != other.Identity) return false;
      if (OppositeId != other.OppositeId) return false;
      if (ServerId != other.ServerId) return false;
      if (TimeSpan != other.TimeSpan) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      if (TimeSpan != 0) hash ^= TimeSpan.GetHashCode();
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
      if (CmdCode.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CmdCode);
      }
      if (Identity.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Identity);
      }
      if (OppositeId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(OppositeId);
      }
      if (ServerId != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(ServerId);
      }
      if (TimeSpan != 0) {
        output.WriteRawTag(192, 1);
        output.WriteUInt32(TimeSpan);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CmdCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CmdCode);
      }
      if (Identity.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Identity);
      }
      if (OppositeId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OppositeId);
      }
      if (ServerId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ServerId);
      }
      if (TimeSpan != 0) {
        size += 2 + pb::CodedOutputStream.ComputeUInt32Size(TimeSpan);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SettingsTimeSpan other) {
      if (other == null) {
        return;
      }
      if (other.CmdCode.Length != 0) {
        CmdCode = other.CmdCode;
      }
      if (other.Identity.Length != 0) {
        Identity = other.Identity;
      }
      if (other.OppositeId.Length != 0) {
        OppositeId = other.OppositeId;
      }
      if (other.ServerId != 0) {
        ServerId = other.ServerId;
      }
      if (other.TimeSpan != 0) {
        TimeSpan = other.TimeSpan;
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
            CmdCode = input.ReadString();
            break;
          }
          case 18: {
            Identity = input.ReadString();
            break;
          }
          case 26: {
            OppositeId = input.ReadString();
            break;
          }
          case 48: {
            ServerId = input.ReadUInt32();
            break;
          }
          case 192: {
            TimeSpan = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
