// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: register.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketCmd {

  /// <summary>Holder for reflection information generated from register.proto</summary>
  public static partial class RegisterReflection {

    #region Descriptor
    /// <summary>File descriptor for register.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RegisterReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5yZWdpc3Rlci5wcm90bxIJU29ja2V0Q21kIn0KCFJlZ2lzdGVyEg8KB2Nt",
            "ZENvZGUYASABKAkSEAoIaWRlbnRpdHkYAiABKAkSDQoFaWNjaWQYByABKAkS",
            "EAoIaW1laVR5cGUYCCABKAkSEwoLaW1laVZlcnNpb24YCSABKAkSCwoDTG5n",
            "GCAgASgBEgsKA0xhdBghIAEoAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketCmd.Register), global::SocketCmd.Register.Parser, new[]{ "CmdCode", "Identity", "Iccid", "ImeiType", "ImeiVersion", "Lng", "Lat" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Register : pb::IMessage<Register> {
    private static readonly pb::MessageParser<Register> _parser = new pb::MessageParser<Register>(() => new Register());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Register> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketCmd.RegisterReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Register() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Register(Register other) : this() {
      cmdCode_ = other.cmdCode_;
      identity_ = other.identity_;
      iccid_ = other.iccid_;
      imeiType_ = other.imeiType_;
      imeiVersion_ = other.imeiVersion_;
      lng_ = other.lng_;
      lat_ = other.lat_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Register Clone() {
      return new Register(this);
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

    /// <summary>Field number for the "iccid" field.</summary>
    public const int IccidFieldNumber = 7;
    private string iccid_ = "";
    /// <summary>
    ///string timeToken = 4;//时间戳yyyy-MM-dd HH:mm:ss.fff
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Iccid {
      get { return iccid_; }
      set {
        iccid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "imeiType" field.</summary>
    public const int ImeiTypeFieldNumber = 8;
    private string imeiType_ = "";
    /// <summary>
    ///设备类别
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ImeiType {
      get { return imeiType_; }
      set {
        imeiType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "imeiVersion" field.</summary>
    public const int ImeiVersionFieldNumber = 9;
    private string imeiVersion_ = "";
    /// <summary>
    ///软件版本
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ImeiVersion {
      get { return imeiVersion_; }
      set {
        imeiVersion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Lng" field.</summary>
    public const int LngFieldNumber = 32;
    private double lng_;
    /// <summary>
    ///经度
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Lng {
      get { return lng_; }
      set {
        lng_ = value;
      }
    }

    /// <summary>Field number for the "Lat" field.</summary>
    public const int LatFieldNumber = 33;
    private double lat_;
    /// <summary>
    ///纬度
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Lat {
      get { return lat_; }
      set {
        lat_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Register);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Register other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CmdCode != other.CmdCode) return false;
      if (Identity != other.Identity) return false;
      if (Iccid != other.Iccid) return false;
      if (ImeiType != other.ImeiType) return false;
      if (ImeiVersion != other.ImeiVersion) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Lng, other.Lng)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Lat, other.Lat)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CmdCode.Length != 0) hash ^= CmdCode.GetHashCode();
      if (Identity.Length != 0) hash ^= Identity.GetHashCode();
      if (Iccid.Length != 0) hash ^= Iccid.GetHashCode();
      if (ImeiType.Length != 0) hash ^= ImeiType.GetHashCode();
      if (ImeiVersion.Length != 0) hash ^= ImeiVersion.GetHashCode();
      if (Lng != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Lng);
      if (Lat != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Lat);
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
      if (Iccid.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Iccid);
      }
      if (ImeiType.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(ImeiType);
      }
      if (ImeiVersion.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(ImeiVersion);
      }
      if (Lng != 0D) {
        output.WriteRawTag(129, 2);
        output.WriteDouble(Lng);
      }
      if (Lat != 0D) {
        output.WriteRawTag(137, 2);
        output.WriteDouble(Lat);
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
      if (Iccid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Iccid);
      }
      if (ImeiType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ImeiType);
      }
      if (ImeiVersion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ImeiVersion);
      }
      if (Lng != 0D) {
        size += 2 + 8;
      }
      if (Lat != 0D) {
        size += 2 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Register other) {
      if (other == null) {
        return;
      }
      if (other.CmdCode.Length != 0) {
        CmdCode = other.CmdCode;
      }
      if (other.Identity.Length != 0) {
        Identity = other.Identity;
      }
      if (other.Iccid.Length != 0) {
        Iccid = other.Iccid;
      }
      if (other.ImeiType.Length != 0) {
        ImeiType = other.ImeiType;
      }
      if (other.ImeiVersion.Length != 0) {
        ImeiVersion = other.ImeiVersion;
      }
      if (other.Lng != 0D) {
        Lng = other.Lng;
      }
      if (other.Lat != 0D) {
        Lat = other.Lat;
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
          case 58: {
            Iccid = input.ReadString();
            break;
          }
          case 66: {
            ImeiType = input.ReadString();
            break;
          }
          case 74: {
            ImeiVersion = input.ReadString();
            break;
          }
          case 257: {
            Lng = input.ReadDouble();
            break;
          }
          case 265: {
            Lat = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
