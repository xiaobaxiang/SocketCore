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

goog.exportSymbol('proto.SocketCmd.RemoveLight', null, global);

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
proto.SocketCmd.RemoveLight = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, null, null);
};
goog.inherits(proto.SocketCmd.RemoveLight, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  proto.SocketCmd.RemoveLight.displayName = 'proto.SocketCmd.RemoveLight';
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
proto.SocketCmd.RemoveLight.prototype.toObject = function(opt_includeInstance) {
  return proto.SocketCmd.RemoveLight.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Whether to include the JSPB
 *     instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.SocketCmd.RemoveLight} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.RemoveLight.toObject = function(includeInstance, msg) {
  var f, obj = {
    cmdcode: jspb.Message.getFieldWithDefault(msg, 1, ""),
    identity: jspb.Message.getFieldWithDefault(msg, 2, ""),
    oppositeid: jspb.Message.getFieldWithDefault(msg, 3, ""),
    timetoken: jspb.Message.getFieldWithDefault(msg, 4, ""),
    celladdr: jspb.Message.getFieldWithDefault(msg, 12, 0),
    lightno: jspb.Message.getFieldWithDefault(msg, 13, "")
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
 * @return {!proto.SocketCmd.RemoveLight}
 */
proto.SocketCmd.RemoveLight.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.SocketCmd.RemoveLight;
  return proto.SocketCmd.RemoveLight.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.SocketCmd.RemoveLight} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.SocketCmd.RemoveLight}
 */
proto.SocketCmd.RemoveLight.deserializeBinaryFromReader = function(msg, reader) {
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
    case 4:
      var value = /** @type {string} */ (reader.readString());
      msg.setTimetoken(value);
      break;
    case 12:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setCelladdr(value);
      break;
    case 13:
      var value = /** @type {string} */ (reader.readString());
      msg.setLightno(value);
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
proto.SocketCmd.RemoveLight.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.SocketCmd.RemoveLight.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.SocketCmd.RemoveLight} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.RemoveLight.serializeBinaryToWriter = function(message, writer) {
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
  f = message.getTimetoken();
  if (f.length > 0) {
    writer.writeString(
      4,
      f
    );
  }
  f = message.getCelladdr();
  if (f !== 0) {
    writer.writeInt32(
      12,
      f
    );
  }
  f = message.getLightno();
  if (f.length > 0) {
    writer.writeString(
      13,
      f
    );
  }
};


/**
 * optional string cmdCode = 1;
 * @return {string}
 */
proto.SocketCmd.RemoveLight.prototype.getCmdcode = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 1, ""));
};


/** @param {string} value */
proto.SocketCmd.RemoveLight.prototype.setCmdcode = function(value) {
  jspb.Message.setProto3StringField(this, 1, value);
};


/**
 * optional string identity = 2;
 * @return {string}
 */
proto.SocketCmd.RemoveLight.prototype.getIdentity = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/** @param {string} value */
proto.SocketCmd.RemoveLight.prototype.setIdentity = function(value) {
  jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional string oppositeId = 3;
 * @return {string}
 */
proto.SocketCmd.RemoveLight.prototype.getOppositeid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 3, ""));
};


/** @param {string} value */
proto.SocketCmd.RemoveLight.prototype.setOppositeid = function(value) {
  jspb.Message.setProto3StringField(this, 3, value);
};


/**
 * optional string timeToken = 4;
 * @return {string}
 */
proto.SocketCmd.RemoveLight.prototype.getTimetoken = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 4, ""));
};


/** @param {string} value */
proto.SocketCmd.RemoveLight.prototype.setTimetoken = function(value) {
  jspb.Message.setProto3StringField(this, 4, value);
};


/**
 * optional int32 cellAddr = 12;
 * @return {number}
 */
proto.SocketCmd.RemoveLight.prototype.getCelladdr = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 12, 0));
};


/** @param {number} value */
proto.SocketCmd.RemoveLight.prototype.setCelladdr = function(value) {
  jspb.Message.setProto3IntField(this, 12, value);
};


/**
 * optional string lightNo = 13;
 * @return {string}
 */
proto.SocketCmd.RemoveLight.prototype.getLightno = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 13, ""));
};


/** @param {string} value */
proto.SocketCmd.RemoveLight.prototype.setLightno = function(value) {
  jspb.Message.setProto3StringField(this, 13, value);
};


goog.object.extend(exports, proto.SocketCmd);
