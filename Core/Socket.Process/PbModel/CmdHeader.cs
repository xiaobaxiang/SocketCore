// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: cmdHeader.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from cmdHeader.proto</summary>
  public static partial class CmdHeaderReflection {

    #region Descriptor
    /// <summary>File descriptor for cmdHeader.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CmdHeaderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9jbWRIZWFkZXIucHJvdG8SCVNvY2tldENtZCKJAQoJQ21kSGVhZGVyEg8K",
            "B2NtZENvZGUYASABKA0SEAoIaWRlbnRpdHkYAiABKAkSEgoKb3Bwb3NpdGVJ",
            "ZBgDIAEoCRIQCghzZXJ2ZXJJZBgEIAEoDRISCgpyZXN1bHRDb2RlGAUgASgF",
            "EhEKCXRpbWVUb2tlbhgGIAEoBBIMCgRtZW1vGAcgASgJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.CmdHeader), global::SocketCmd.CmdHeader.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "ServerId", "ResultCode", "TimeToken", "Memo" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CmdHeader : pb::IMessage<CmdHeader> {
    private static readonly pb::MessageParser<CmdHeader> _parser = new pb::MessageParser<CmdHeader>(() => new CmdHeader());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CmdHeader> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.CmdHeaderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CmdHeader() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CmdHeader(CmdHeader other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      serverId_ = other.serverId_;
      resultCode_ = other.resultCode_;
      timeToken_ = other.timeToken_;
      memo_ = other.memo_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CmdHeader Clone() {
      return new CmdHeader(this);
    }

    /// <summary>Field number for the "cmdCode" field.</summary>
    public const int CmdCodeFieldNumber = 1;
    private uint cmdCode_;
    /// <summary>
    /// 命令号
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint CmdCode {
      get { return cmdCode_; }
      set {
        cmdCode_ = value;
      }
    }

    /// <summary>Field number for the "identity" field.</summary>
    public const int IdentityFieldNumber = 2;
    private string identity_ = "";
    /// <summary>
    /// socket对象标识
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
    /// 操作对端对象标识
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OppositeId {
      get { return oppositeId_; }
      set {
        oppositeId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "serverId" field.</summary>
    public const int ServerIdFieldNumber = 4;
    private uint serverId_;
    /// <summary>
    /// 上位机Id
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ServerId {
      get { return serverId_; }
      set {
        serverId_ = value;
      }
    }

    /// <summary>Field number for the "resultCode" field.</summary>
    public const int ResultCodeFieldNumber = 5;
    private int resultCode_;
    /// <summary>
    /// 操作成功1成功，其他失败
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
      }
    }

    /// <summary>Field number for the "timeToken" field.</summary>
    public const int TimeTokenFieldNumber = 6;
    private ulong timeToken_;
    /// <summary>
    /// 命令发送时间戳到1970年毫秒数
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong TimeToken {
      get { return timeToken_; }
      set {
        timeToken_ = value;
      }
    }

    /// <summary>Field number for the "memo" field.</summary>
    public const int MemoFieldNumber = 7;
    private string memo_ = "";
    /// <summary>
    /// 备用字段调试使用
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Memo {
      get { return memo_; }
      set {
        memo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CmdHeader);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CmdHeader other) {
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
      if (ResultCode != other.ResultCode) return false;
      if (TimeToken != other.TimeToken) return false;
      if (Memo != other.Memo) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (TimeToken != 0UL) hash ^= TimeToken.GetHashCode();
      if (Memo.Length != 0) hash ^= Memo.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (CmdCode != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(CmdCode);
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
        output.WriteRawTag(32);
        output.WriteUInt32(ServerId);
      }
      if (ResultCode != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(ResultCode);
      }
      if (TimeToken != 0UL) {
        output.WriteRawTag(48);
        output.WriteUInt64(TimeToken);
      }
      if (Memo.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Memo);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CmdCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CmdCode);
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
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (TimeToken != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(TimeToken);
      }
      if (Memo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Memo);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CmdHeader other) {
      if (other == null) {
        return;
      }
      if (other.CmdCode != 0) {
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
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      if (other.TimeToken != 0UL) {
        TimeToken = other.TimeToken;
      }
      if (other.Memo.Length != 0) {
        Memo = other.Memo;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            CmdCode = input.ReadUInt32();
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
          case 32: {
            ServerId = input.ReadUInt32();
            break;
          }
          case 40: {
            ResultCode = input.ReadInt32();
            break;
          }
          case 48: {
            TimeToken = input.ReadUInt64();
            break;
          }
          case 58: {
            Memo = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
