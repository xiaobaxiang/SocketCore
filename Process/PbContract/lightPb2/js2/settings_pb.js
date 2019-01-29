/**
 * @fileoverview
 * @enhanceable
 * @suppress {messageConventions} JS Compiler reports an error if a variable or
 *     field starts with 'MSG_' and isn't a translatable message.
 * @public
 */
// GENERATED CODE -- DO NOT EDIT!

var jspb = require('google-protobuf');
var goog = jspb;
var global = Function('return this')();

goog.exportSymbol('proto.SocketCmd.Settings', null, global);

/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.SocketCmd.Settings = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, null, null);
};
goog.inherits(proto.SocketCmd.Settings, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  proto.SocketCmd.Settings.displayName = 'proto.SocketCmd.Settings';
}


if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto suitable for use in Soy templates.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     com.google.apps.jspb.JsClassTemplate.JS_RESERVED_WORDS.
 * @param {boolean=} opt_includeInstance Whether to include the JSPB instance
 *     for transitional soy proto support: http://goto/soy-param-migration
 * @return {!Object}
 */
proto.SocketCmd.Settings.prototype.toObject = function(opt_includeInstance) {
  return proto.SocketCmd.Settings.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Whether to include the JSPB
 *     instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.SocketCmd.Settings} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.Settings.toObject = function(includeInstance, msg) {
  var f, obj = {
    cmdcode: jspb.Message.getFieldWithDefault(msg, 1, ""),
    identity: jspb.Message.getFieldWithDefault(msg, 2, ""),
    oppositeid: jspb.Message.getFieldWithDefault(msg, 3, ""),
    serverid: jspb.Message.getFieldWithDefault(msg, 6, 0),
    value: jspb.Message.getFieldWithDefault(msg, 29, 0)
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.SocketCmd.Settings}
 */
proto.SocketCmd.Settings.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.SocketCmd.Settings;
  return proto.SocketCmd.Settings.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.SocketCmd.Settings} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.SocketCmd.Settings}
 */
proto.SocketCmd.Settings.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {string} */ (reader.readString());
      msg.setCmdcode(value);
      break;
    case 2:
      var value = /** @type {string} */ (reader.readString());
      msg.setIdentity(value);
      break;
    case 3:
      var value = /** @type {string} */ (reader.readString());
      msg.setOppositeid(value);
      break;
    case 6:
      var value = /** @type {number} */ (reader.readUint32());
      msg.setServerid(value);
      break;
    case 29:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setValue(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.SocketCmd.Settings.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.SocketCmd.Settings.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.SocketCmd.Settings} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.Settings.serializeBinaryToWriter = function(message, writer) {
  var f = undefined;
  f = message.getCmdcode();
  if (f.length > 0) {
    writer.writeString(
      1,
      f
    );
  }
  f = message.getIdentity();
  if (f.length > 0) {
    writer.writeString(
      2,
      f
    );
  }
  f = message.getOppositeid();
  if (f.length > 0) {
    writer.writeString(
      3,
      f
    );
  }
  f = message.getServerid();
  if (f !== 0) {
    writer.writeUint32(
      6,
      f
    );
  }
  f = message.getValue();
  if (f !== 0) {
    writer.writeInt32(
      29,
      f
    );
  }
};


/**
 * optional string cmdCode = 1;
 * @return {string}
 */
proto.SocketCmd.Settings.prototype.getCmdcode = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 1, ""));
};


/** @param {string} value */
proto.SocketCmd.Settings.prototype.setCmdcode = function(value) {
  jspb.Message.setProto3StringField(this, 1, value);
};


/**
 * optional string identity = 2;
 * @return {string}
 */
proto.SocketCmd.Settings.prototype.getIdentity = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/** @param {string} value */
proto.SocketCmd.Settings.prototype.setIdentity = function(value) {
  jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional string oppositeId = 3;
 * @return {string}
 */
proto.SocketCmd.Settings.prototype.getOppositeid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 3, ""));
};


/** @param {string} value */
proto.SocketCmd.Settings.prototype.setOppositeid = function(value) {
  jspb.Message.setProto3StringField(this, 3, value);
};


/**
 * optional uint32 serverId = 6;
 * @return {number}
 */
proto.SocketCmd.Settings.prototype.getServerid = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 6, 0));
};


/** @param {number} value */
proto.SocketCmd.Settings.prototype.setServerid = function(value) {
  jspb.Message.setProto3IntField(this, 6, value);
};


/**
 * optional int32 value = 29;
 * @return {number}
 */
proto.SocketCmd.Settings.prototype.getValue = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 29, 0));
};


/** @param {number} value */
proto.SocketCmd.Settings.prototype.setValue = function(value) {
  jspb.Message.setProto3IntField(this, 29, value);
};


goog.object.extend(exports, proto.SocketCmd);