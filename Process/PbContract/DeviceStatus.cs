// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: deviceStatus.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from deviceStatus.proto</summary>
  public static partial class DeviceStatusReflection {

    #region Descriptor
    /// <summary>File descriptor for deviceStatus.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DeviceStatusReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJkZXZpY2VTdGF0dXMucHJvdG8SCVNvY2tldENtZCJyCgxEZXZpY2VTdGF0",
            "dXMSDwoHY21kQ29kZRgBIAEoCRIQCghpZGVudGl0eRgCIAEoCRISCgpvcHBv",
            "c2l0ZUlkGAMgASgJEisKC2xpZ2h0U3RhdHVzGBcgASgLMhYuU29ja2V0Q21k",
            "LkxpZ2h0U3RhdHVzIrkBCgtMaWdodFN0YXR1cxIQCghjZWxsQWRkchgMIAEo",
            "DRIOCgZzdGF0dXMYDyABKAkSDwoHbGlnaHRQdxgQIAEoBRIPCgdsaWdodEx1",
            "GBEgASgFEg8KB2xpZ2h0TGkYEiABKAUSDwoHbGlnaHRCdRgTIAEoBRIPCgds",
            "aWdodEJ0GBQgASgFEg8KB2xpZ2h0VXUYFSABKAUSDwoHbGlnaHRVaRgWIAEo",
            "BRIRCglsaWdodEJndXMYIiADKAViBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.DeviceStatus), global::SocketCmd.DeviceStatus.Parser, new[]{ "CmdCode", "Identity", "OppositeId", "LightStatus" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.LightStatus), global::SocketCmd.LightStatus.Parser, new[]{ "CellAddr", "Status", "LightPw", "LightLu", "LightLi", "LightBu", "LightBt", "LightUu", "LightUi", "LightBgus" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class DeviceStatus : pb::IMessage<DeviceStatus> {
    private static readonly pb::MessageParser<DeviceStatus> _parser = new pb::MessageParser<DeviceStatus>(() => new DeviceStatus());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DeviceStatus> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.DeviceStatusReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceStatus() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceStatus(DeviceStatus other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      oppositeId_ = other.oppositeId_;
      LightStatus = other.lightStatus_ != null ? other.LightStatus.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceStatus Clone() {
      return new DeviceStatus(this);
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

    /// <summary>Field number for the "lightStatus" field.</summary>
    public const int LightStatusFieldNumber = 23;
    private global::SocketCmd.LightStatus lightStatus_;
    /// <summary>
    ///string timeToken = 4;//时间戳yyyy-MM-dd HH:mm:ss.fff
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketCmd.LightStatus LightStatus {
      get { return lightStatus_; }
      set {
        lightStatus_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DeviceStatus);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DeviceStatus other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CmdCode != other.CmdCode) return false;
      if (Identity != other.Identity) return false;
      if (OppositeId != other.OppositeId) return false;
      if (!object.Equals(LightStatus, other.LightStatus)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (OppositeId.Length != 0) hash ^= OppositeId.GetHashCode();
      if (lightStatus_ != null) hash ^= LightStatus.GetHashCode();
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
      if (lightStatus_ != null) {
        output.WriteRawTag(186, 1);
        output.WriteMessage(LightStatus);
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
      if (lightStatus_ != null) {
        size += 2 + pb::CodedOutputStream.ComputeMessageSize(LightStatus);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DeviceStatus other) {
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
      if (other.lightStatus_ != null) {
        if (lightStatus_ == null) {
          lightStatus_ = new global::SocketCmd.LightStatus();
        }
        LightStatus.MergeFrom(other.LightStatus);
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
          case 186: {
            if (lightStatus_ == null) {
              lightStatus_ = new global::SocketCmd.LightStatus();
            }
            input.ReadMessage(lightStatus_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LightStatus : pb::IMessage<LightStatus> {
    private static readonly pb::MessageParser<LightStatus> _parser = new pb::MessageParser<LightStatus>(() => new LightStatus());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LightStatus> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.DeviceStatusReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LightStatus() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LightStatus(LightStatus other) : this() {
      cellAddr_ = other.cellAddr_;
      status_ = other.status_;
      lightPw_ = other.lightPw_;
      lightLu_ = other.lightLu_;
      lightLi_ = other.lightLi_;
      lightBu_ = other.lightBu_;
      lightBt_ = other.lightBt_;
      lightUu_ = other.lightUu_;
      lightUi_ = other.lightUi_;
      lightBgus_ = other.lightBgus_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LightStatus Clone() {
      return new LightStatus(this);
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

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 15;
    private string status_ = "";
    /// <summary>
    ///string lightNo = 13;//灯标识
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Status {
      get { return status_; }
      set {
        status_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "lightPw" field.</summary>
    public const int LightPwFieldNumber = 16;
    private int lightPw_;
    /// <summary>
    ///功率
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightPw {
      get { return lightPw_; }
      set {
        lightPw_ = value;
      }
    }

    /// <summary>Field number for the "lightLu" field.</summary>
    public const int LightLuFieldNumber = 17;
    private int lightLu_;
    /// <summary>
    ///光伏电压
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightLu {
      get { return lightLu_; }
      set {
        lightLu_ = value;
      }
    }

    /// <summary>Field number for the "lightLi" field.</summary>
    public const int LightLiFieldNumber = 18;
    private int lightLi_;
    /// <summary>
    ///光伏电流
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightLi {
      get { return lightLi_; }
      set {
        lightLi_ = value;
      }
    }

    /// <summary>Field number for the "lightBu" field.</summary>
    public const int LightBuFieldNumber = 19;
    private int lightBu_;
    /// <summary>
    ///电池电压
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightBu {
      get { return lightBu_; }
      set {
        lightBu_ = value;
      }
    }

    /// <summary>Field number for the "lightBt" field.</summary>
    public const int LightBtFieldNumber = 20;
    private int lightBt_;
    /// <summary>
    ///电池温度
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightBt {
      get { return lightBt_; }
      set {
        lightBt_ = value;
      }
    }

    /// <summary>Field number for the "lightUu" field.</summary>
    public const int LightUuFieldNumber = 21;
    private int lightUu_;
    /// <summary>
    ///负载电压
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightUu {
      get { return lightUu_; }
      set {
        lightUu_ = value;
      }
    }

    /// <summary>Field number for the "lightUi" field.</summary>
    public const int LightUiFieldNumber = 22;
    private int lightUi_;
    /// <summary>
    ///负载电流
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LightUi {
      get { return lightUi_; }
      set {
        lightUi_ = value;
      }
    }

    /// <summary>Field number for the "lightBgus" field.</summary>
    public const int LightBgusFieldNumber = 34;
    private static readonly pb::FieldCodec<int> _repeated_lightBgus_codec
        = pb::FieldCodec.ForInt32(274);
    private readonly pbc::RepeatedField<int> lightBgus_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///电池组电压
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> LightBgus {
      get { return lightBgus_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LightStatus);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LightStatus other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CellAddr != other.CellAddr) return false;
      if (Status != other.Status) return false;
      if (LightPw != other.LightPw) return false;
      if (LightLu != other.LightLu) return false;
      if (LightLi != other.LightLi) return false;
      if (LightBu != other.LightBu) return false;
      if (LightBt != other.LightBt) return false;
      if (LightUu != other.LightUu) return false;
      if (LightUi != other.LightUi) return false;
      if(!lightBgus_.Equals(other.lightBgus_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CellAddr != 0) hash ^= CellAddr.GetHashCode();
      if (Status.Length != 0) hash ^= Status.GetHashCode();
      if (LightPw != 0) hash ^= LightPw.GetHashCode();
      if (LightLu != 0) hash ^= LightLu.GetHashCode();
      if (LightLi != 0) hash ^= LightLi.GetHashCode();
      if (LightBu != 0) hash ^= LightBu.GetHashCode();
      if (LightBt != 0) hash ^= LightBt.GetHashCode();
      if (LightUu != 0) hash ^= LightUu.GetHashCode();
      if (LightUi != 0) hash ^= LightUi.GetHashCode();
      hash ^= lightBgus_.GetHashCode();
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
      if (CellAddr != 0) {
        output.WriteRawTag(96);
        output.WriteUInt32(CellAddr);
      }
      if (Status.Length != 0) {
        output.WriteRawTag(122);
        output.WriteString(Status);
      }
      if (LightPw != 0) {
        output.WriteRawTag(128, 1);
        output.WriteInt32(LightPw);
      }
      if (LightLu != 0) {
        output.WriteRawTag(136, 1);
        output.WriteInt32(LightLu);
      }
      if (LightLi != 0) {
        output.WriteRawTag(144, 1);
        output.WriteInt32(LightLi);
      }
      if (LightBu != 0) {
        output.WriteRawTag(152, 1);
        output.WriteInt32(LightBu);
      }
      if (LightBt != 0) {
        output.WriteRawTag(160, 1);
        output.WriteInt32(LightBt);
      }
      if (LightUu != 0) {
        output.WriteRawTag(168, 1);
        output.WriteInt32(LightUu);
      }
      if (LightUi != 0) {
        output.WriteRawTag(176, 1);
        output.WriteInt32(LightUi);
      }
      lightBgus_.WriteTo(output, _repeated_lightBgus_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CellAddr != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CellAddr);
      }
      if (Status.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Status);
      }
      if (LightPw != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightPw);
      }
      if (LightLu != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightLu);
      }
      if (LightLi != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightLi);
      }
      if (LightBu != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightBu);
      }
      if (LightBt != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightBt);
      }
      if (LightUu != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightUu);
      }
      if (LightUi != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(LightUi);
      }
      size += lightBgus_.CalculateSize(_repeated_lightBgus_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LightStatus other) {
      if (other == null) {
        return;
      }
      if (other.CellAddr != 0) {
        CellAddr = other.CellAddr;
      }
      if (other.Status.Length != 0) {
        Status = other.Status;
      }
      if (other.LightPw != 0) {
        LightPw = other.LightPw;
      }
      if (other.LightLu != 0) {
        LightLu = other.LightLu;
      }
      if (other.LightLi != 0) {
        LightLi = other.LightLi;
      }
      if (other.LightBu != 0) {
        LightBu = other.LightBu;
      }
      if (other.LightBt != 0) {
        LightBt = other.LightBt;
      }
      if (other.LightUu != 0) {
        LightUu = other.LightUu;
      }
      if (other.LightUi != 0) {
        LightUi = other.LightUi;
      }
      lightBgus_.Add(other.lightBgus_);
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
          case 96: {
            CellAddr = input.ReadUInt32();
            break;
          }
          case 122: {
            Status = input.ReadString();
            break;
          }
          case 128: {
            LightPw = input.ReadInt32();
            break;
          }
          case 136: {
            LightLu = input.ReadInt32();
            break;
          }
          case 144: {
            LightLi = input.ReadInt32();
            break;
          }
          case 152: {
            LightBu = input.ReadInt32();
            break;
          }
          case 160: {
            LightBt = input.ReadInt32();
            break;
          }
          case 168: {
            LightUu = input.ReadInt32();
            break;
          }
          case 176: {
            LightUi = input.ReadInt32();
            break;
          }
          case 274:
          case 272: {
            lightBgus_.AddEntriesFrom(input, _repeated_lightBgus_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
