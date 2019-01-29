// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: comDealBk.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from comDealBk.proto</summary>
  public static partial class ComDealBkReflection {

    #region Descriptor
    /// <summary>File descriptor for comDealBk.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ComDealBkReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9jb21EZWFsQmsucHJvdG8SCVNvY2tldENtZCKJAQoJQ29tRGVhbEJrEg8K",
            "B2NtZENvZGUYASABKAkSEAoIaWRlbnRpdHkYAiABKAkSEgoKb3Bwb3NpdGVJ",
            "ZBgDIAEoCRISCgpyZXN1bHRDb2RlGAUgASgFEhAKCHNlcnZlcklkGAYgASgN",
            "Eh8KA3JlcxgmIAMoCzISLlNvY2tldENtZC5EZWFsUmVzIi8KB0RlYWxSZXMS",
            "EgoKcmVzdWx0Q29kZRgFIAEoBRIQCghjZWxsQWRkchgMIAEoDWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.ComDealBk), global::SocketCmd.ComDealBk.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ResultCode", "ServerId", "Res" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.DealRes), global::SocketCmd.DealRes.Parser, new[]{ "ResultCode", "CellAddr" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ComDealBk : pb::IMessage<ComDealBk> {
    private static readonly pb::MessageParser<ComDealBk> _parser = new pb::MessageParser<ComDealBk>(() => new ComDealBk());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ComDealBk> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.ComDealBkReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ComDealBk() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ComDealBk(ComDealBk other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      resultCode_ = other.resultCode_;
      serverId_ = other.serverId_;
      res_ = other.res_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ComDealBk Clone() {
      return new ComDealBk(this);
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
    ///操作对端对象标识(可选,用于控制中)
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
    ///操作成功1成功，其他失败
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

    /// <summary>Field number for the "res" field.</summary>
    public const int ResFieldNumber = 38;
    private static readonly pb::FieldCodec<global::SocketCmd.DealRes> _repeated_res_codec
        = pb::FieldCodec.ForMessage(306, global::SocketCmd.DealRes.Parser);
    private readonly pbc::RepeatedField<global::SocketCmd.DealRes> res_ = new pbc::RepeatedField<global::SocketCmd.DealRes>();
    /// <summary>
    ///单元格数组
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SocketCmd.DealRes> Res {
      get { return res_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ComDealBk);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ComDealBk other) {
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
      if(!res_.Equals(other.res_)) return false;
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
      hash ^= res_.GetHashCode();
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
      res_.WriteTo(output, _repeated_res_codec);
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
      size += res_.CalculateSize(_repeated_res_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ComDealBk other) {
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
      res_.Add(other.res_);
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
          case 306: {
            res_.AddEntriesFrom(input, _repeated_res_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class DealRes : pb::IMessage<DealRes> {
    private static readonly pb::MessageParser<DealRes> _parser = new pb::MessageParser<DealRes>(() => new DealRes());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DealRes> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.ComDealBkReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DealRes() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DealRes(DealRes other) : this() {
      resultCode_ = other.resultCode_;
      cellAddr_ = other.cellAddr_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DealRes Clone() {
      return new DealRes(this);
    }

    /// <summary>Field number for the "resultCode" field.</summary>
    public const int ResultCodeFieldNumber = 5;
    private int resultCode_;
    /// <summary>
    ///操作成功1成功，其他失败
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
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

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DealRes);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DealRes other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ResultCode != other.ResultCode) return false;
      if (CellAddr != other.CellAddr) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (CellAddr != 0) hash ^= CellAddr.GetHashCode();
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
      if (ResultCode != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(ResultCode);
      }
      if (CellAddr != 0) {
        output.WriteRawTag(96);
        output.WriteUInt32(CellAddr);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (CellAddr != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CellAddr);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DealRes other) {
      if (other == null) {
        return;
      }
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      if (other.CellAddr != 0) {
        CellAddr = other.CellAddr;
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
          case 40: {
            ResultCode = input.ReadInt32();
            break;
          }
          case 96: {
            CellAddr = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
