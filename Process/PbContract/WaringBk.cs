// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: waringBk.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from waringBk.proto</summary>
  public static partial class WaringBkReflection {

    #region Descriptor
    /// <summary>File descriptor for waringBk.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WaringBkReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg53YXJpbmdCay5wcm90bxIJU29ja2V0Q21kIqABCghXYXJpbmdCaxIPCgdj",
            "bWRDb2RlGAEgASgJEhAKCGlkZW50aXR5GAIgASgJEhIKCm9wcG9zaXRlSWQY",
            "AyABKAkSEgoKcmVzdWx0Q29kZRgFIAEoBRIQCghzZXJ2ZXJJZBgGIAEoDRIP",
            "CgdsaWdodE5vGA0gASgJEhIKCndhcmluZ0NvZGUYHiABKAkSEgoKd2FyaW5n",
            "RGVzYxgfIAEoCWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.WaringBk), global::SocketCmd.WaringBk.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ResultCode", "ServerId", "LightNo", "WaringCode", "WaringDesc" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class WaringBk : pb::IMessage<WaringBk> {
    private static readonly pb::MessageParser<WaringBk> _parser = new pb::MessageParser<WaringBk>(() => new WaringBk());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WaringBk> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.WaringBkReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WaringBk() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WaringBk(WaringBk other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      resultCode_ = other.resultCode_;
      serverId_ = other.serverId_;
      lightNo_ = other.lightNo_;
      waringCode_ = other.waringCode_;
      waringDesc_ = other.waringDesc_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WaringBk Clone() {
      return new WaringBk(this);
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

    /// <summary>Field number for the "resultCode" field.</summary>
    public const int ResultCodeFieldNumber = 5;
    private int resultCode_;
    /// <summary>
    ///string timeToken = 4;//时间戳yyyy-MM-dd HH:mm:ss.fff
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
      }
    }

    /// <summary>Field number for the "serverId" field.</summary>
    public const int ServerIdFieldNumber = 6;
    private uint serverId_;
    /// <summary>
    ///会按照数据的大小使用合适的字节大小
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ServerId {
      get { return serverId_; }
      set {
        serverId_ = value;
      }
    }

    /// <summary>Field number for the "lightNo" field.</summary>
    public const int LightNoFieldNumber = 13;
    private string lightNo_ = "";
    /// <summary>
    ///路灯标识
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LightNo {
      get { return lightNo_; }
      set {
        lightNo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "waringCode" field.</summary>
    public const int WaringCodeFieldNumber = 30;
    private string waringCode_ = "";
    /// <summary>
    ///报警码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string WaringCode {
      get { return waringCode_; }
      set {
        waringCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "waringDesc" field.</summary>
    public const int WaringDescFieldNumber = 31;
    private string waringDesc_ = "";
    /// <summary>
    ///报警内容
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string WaringDesc {
      get { return waringDesc_; }
      set {
        waringDesc_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WaringBk);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WaringBk other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CmdCode != other.CmdCode) return false;
      if (Identity != other.Identity) return false;
      if (OppositeId != other.OppositeId) return false;
      if (ResultCode != other.ResultCode) return false;
      if (ServerId != other.ServerId) return false;
      if (LightNo != other.LightNo) return false;
      if (WaringCode != other.WaringCode) return false;
      if (WaringDesc != other.WaringDesc) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      if (LightNo.Length != 0) hash ^= LightNo.GetHashCode();
      if (WaringCode.Length != 0) hash ^= WaringCode.GetHashCode();
      if (WaringDesc.Length != 0) hash ^= WaringDesc.GetHashCode();
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
      if (ResultCode != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(ResultCode);
      }
      if (ServerId != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(ServerId);
      }
      if (LightNo.Length != 0) {
        output.WriteRawTag(106);
        output.WriteString(LightNo);
      }
      if (WaringCode.Length != 0) {
        output.WriteRawTag(242, 1);
        output.WriteString(WaringCode);
      }
      if (WaringDesc.Length != 0) {
        output.WriteRawTag(250, 1);
        output.WriteString(WaringDesc);
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
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (ServerId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ServerId);
      }
      if (LightNo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LightNo);
      }
      if (WaringCode.Length != 0) {
        size += 2 + pb::CodedOutputStream.ComputeStringSize(WaringCode);
      }
      if (WaringDesc.Length != 0) {
        size += 2 + pb::CodedOutputStream.ComputeStringSize(WaringDesc);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WaringBk other) {
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
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      if (other.ServerId != 0) {
        ServerId = other.ServerId;
      }
      if (other.LightNo.Length != 0) {
        LightNo = other.LightNo;
      }
      if (other.WaringCode.Length != 0) {
        WaringCode = other.WaringCode;
      }
      if (other.WaringDesc.Length != 0) {
        WaringDesc = other.WaringDesc;
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
          case 40: {
            ResultCode = input.ReadInt32();
            break;
          }
          case 48: {
            ServerId = input.ReadUInt32();
            break;
          }
          case 106: {
            LightNo = input.ReadString();
            break;
          }
          case 242: {
            WaringCode = input.ReadString();
            break;
          }
          case 250: {
            WaringDesc = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
