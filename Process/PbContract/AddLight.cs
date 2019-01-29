// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: addLight.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from addLight.proto</summary>
  public static partial class AddLightReflection {

    #region Descriptor
    /// <summary>File descriptor for addLight.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AddLightReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5hZGRMaWdodC5wcm90bxIJU29ja2V0Q21kInYKCEFkZExpZ2h0Eg8KB2Nt",
            "ZENvZGUYASABKAkSEAoIaWRlbnRpdHkYAiABKAkSEgoKb3Bwb3NpdGVJZBgD",
            "IAEoCRIQCghzZXJ2ZXJJZBgGIAEoDRIQCghjZWxsQWRkchgMIAEoDRIPCgds",
            "aWdodE5vGA0gASgJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.AddLight), global::SocketCmd.AddLight.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ServerId", "CellAddr", "LightNo" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AddLight : pb::IMessage<AddLight> {
    private static readonly pb::MessageParser<AddLight> _parser = new pb::MessageParser<AddLight>(() => new AddLight());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AddLight> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.AddLightReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddLight() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddLight(AddLight other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      serverId_ = other.serverId_;
      cellAddr_ = other.cellAddr_;
      lightNo_ = other.lightNo_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddLight Clone() {
      return new AddLight(this);
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

    /// <summary>Field number for the "cellAddr" field.</summary>
    public const int CellAddrFieldNumber = 12;
    private uint cellAddr_;
    /// <summary>
    ///单元格地址
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint CellAddr {
      get { return cellAddr_; }
      set {
        cellAddr_ = value;
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

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AddLight);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AddLight other) {
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
      if (CellAddr != other.CellAddr) return false;
      if (LightNo != other.LightNo) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      if (CellAddr != 0) hash ^= CellAddr.GetHashCode();
      if (LightNo.Length != 0) hash ^= LightNo.GetHashCode();
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
      if (CellAddr != 0) {
        output.WriteRawTag(96);
        output.WriteUInt32(CellAddr);
      }
      if (LightNo.Length != 0) {
        output.WriteRawTag(106);
        output.WriteString(LightNo);
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
      if (CellAddr != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CellAddr);
      }
      if (LightNo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LightNo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AddLight other) {
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
      if (other.CellAddr != 0) {
        CellAddr = other.CellAddr;
      }
      if (other.LightNo.Length != 0) {
        LightNo = other.LightNo;
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
          case 96: {
            CellAddr = input.ReadUInt32();
            break;
          }
          case 106: {
            LightNo = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code