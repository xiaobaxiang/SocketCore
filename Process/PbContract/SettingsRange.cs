// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: settingsRange.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from settingsRange.proto</summary>
  public static partial class SettingsRangeReflection {

    #region Descriptor
    /// <summary>File descriptor for settingsRange.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SettingsRangeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNzZXR0aW5nc1JhbmdlLnByb3RvEglTb2NrZXRDbWQikQEKDVNldHRpbmdz",
            "UmFuZ2USDwoHY21kQ29kZRgBIAEoCRIQCghpZGVudGl0eRgCIAEoCRISCgpv",
            "cHBvc2l0ZUlkGAMgASgJEhAKCHNlcnZlcklkGAYgASgNEhAKCGxvd1ZhbHVl",
            "GBkgASgFEhIKCmhlaWdoVmFsdWUYGiABKAUSEQoJY2VsbEFkZHJzGCUgAygN",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.SettingsRange), global::SocketCmd.SettingsRange.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ServerId", "LowValue", "HeighValue", "CellAddrs" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SettingsRange : pb::IMessage<SettingsRange> {
    private static readonly pb::MessageParser<SettingsRange> _parser = new pb::MessageParser<SettingsRange>(() => new SettingsRange());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SettingsRange> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.SettingsRangeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsRange() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsRange(SettingsRange other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      serverId_ = other.serverId_;
      lowValue_ = other.lowValue_;
      heighValue_ = other.heighValue_;
      cellAddrs_ = other.cellAddrs_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SettingsRange Clone() {
      return new SettingsRange(this);
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

    /// <summary>Field number for the "lowValue" field.</summary>
    public const int LowValueFieldNumber = 25;
    private int lowValue_;
    /// <summary>
    ///设置下限值
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LowValue {
      get { return lowValue_; }
      set {
        lowValue_ = value;
      }
    }

    /// <summary>Field number for the "heighValue" field.</summary>
    public const int HeighValueFieldNumber = 26;
    private int heighValue_;
    /// <summary>
    ///设置上限值
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int HeighValue {
      get { return heighValue_; }
      set {
        heighValue_ = value;
      }
    }

    /// <summary>Field number for the "cellAddrs" field.</summary>
    public const int CellAddrsFieldNumber = 37;
    private static readonly pb::FieldCodec<uint> _repeated_cellAddrs_codec
        = pb::FieldCodec.ForUInt32(298);
    private readonly pbc::RepeatedField<uint> cellAddrs_ = new pbc::RepeatedField<uint>();
    /// <summary>
    ///repeated string lightNos = 36;//路灯标识
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<uint> CellAddrs {
      get { return cellAddrs_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SettingsRange);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SettingsRange other) {
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
      if (LowValue != other.LowValue) return false;
      if (HeighValue != other.HeighValue) return false;
      if(!cellAddrs_.Equals(other.cellAddrs_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      if (LowValue != 0) hash ^= LowValue.GetHashCode();
      if (HeighValue != 0) hash ^= HeighValue.GetHashCode();
      hash ^= cellAddrs_.GetHashCode();
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
      if (LowValue != 0) {
        output.WriteRawTag(200, 1);
        output.WriteInt32(LowValue);
      }
      if (HeighValue != 0) {
        output.WriteRawTag(208, 1);
        output.WriteInt32(HeighValue);
      }
      cellAddrs_.WriteTo(output, _repeated_cellAddrs_codec);
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
      if (LowValue != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LowValue);
      }
      if (HeighValue != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(HeighValue);
      }
      size += cellAddrs_.CalculateSize(_repeated_cellAddrs_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SettingsRange other) {
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
      if (other.LowValue != 0) {
        LowValue = other.LowValue;
      }
      if (other.HeighValue != 0) {
        HeighValue = other.HeighValue;
      }
      cellAddrs_.Add(other.cellAddrs_);
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
          case 200: {
            LowValue = input.ReadInt32();
            break;
          }
          case 208: {
            HeighValue = input.ReadInt32();
            break;
          }
          case 298:
          case 296: {
            cellAddrs_.AddEntriesFrom(input, _repeated_cellAddrs_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
