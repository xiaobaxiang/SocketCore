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

goog.exportSymbol('proto.SocketCmd.SettingsRange', null, global);

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
proto.SocketCmd.SettingsRange = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, proto.SocketCmd.SettingsRange.repeatedFields_, null);
};
goog.inherits(proto.SocketCmd.SettingsRange, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  proto.SocketCmd.SettingsRange.displayName = 'proto.SocketCmd.SettingsRange';
}
/**
 * List of repeated fields within this message type.
 * @private {!Array<number>}
 * @const
 */
proto.SocketCmd.SettingsRange.repeatedFields_ = [37];



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
proto.SocketCmd.SettingsRange.prototype.toObject = function(opt_includeInstance) {
  return proto.SocketCmd.SettingsRange.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Whether to include the JSPB
 *     instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.SocketCmd.SettingsRange} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.SettingsRange.toObject = function(includeInstance, msg) {
  var f, obj = {
    cmdcode: jspb.Message.getFieldWithDefault(msg, 1, ""),
    identity: jspb.Message.getFieldWithDefault(msg, 2, ""),
    oppositeid: jspb.Message.getFieldWithDefault(msg, 3, ""),
    serverid: jspb.Message.getFieldWithDefault(msg, 6, 0),
    lowvalue: jspb.Message.getFieldWithDefault(msg, 25, 0),
    heighvalue: jspb.Message.getFieldWithDefault(msg, 26, 0),
    celladdrsList: jspb.Message.getRepeatedField(msg, 37)
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
 * @return {!proto.SocketCmd.SettingsRange}
 */
proto.SocketCmd.SettingsRange.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.SocketCmd.SettingsRange;
  return proto.SocketCmd.SettingsRange.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.SocketCmd.SettingsRange} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.SocketCmd.SettingsRange}
 */
proto.SocketCmd.SettingsRange.deserializeBinaryFromReader = function(msg, reader) {
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
    case 25:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setLowvalue(value);
      break;
    case 26:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setHeighvalue(value);
      break;
    case 37:
      var value = /** @type {!Array.<number>} */ (reader.readPackedUint32());
      msg.setCelladdrsList(value);
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
proto.SocketCmd.SettingsRange.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.SocketCmd.SettingsRange.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.SocketCmd.SettingsRange} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.SocketCmd.SettingsRange.serializeBinaryToWriter = function(message, writer) {
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
  f = message.getLowvalue();
  if (f !== 0) {
    writer.writeInt32(
      25,
      f
    );
  }
  f = message.getHeighvalue();
  if (f !== 0) {
    writer.writeInt32(
      26,
      f
    );
  }
  f = message.getCelladdrsList();
  if (f.length > 0) {
    writer.writePackedUint32(
      37,
      f
    );
  }
};


/**
 * optional string cmdCode = 1;
 * @return {string}
 */
proto.SocketCmd.SettingsRange.prototype.getCmdcode = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 1, ""));
};


/** @param {string} value */
proto.SocketCmd.SettingsRange.prototype.setCmdcode = function(value) {
  jspb.Message.setProto3StringField(this, 1, value);
};


/**
 * optional string identity = 2;
 * @return {string}
 */
proto.SocketCmd.SettingsRange.prototype.getIdentity = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/** @param {string} value */
proto.SocketCmd.SettingsRange.prototype.setIdentity = function(value) {
  jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional string oppositeId = 3;
 * @return {string}
 */
proto.SocketCmd.SettingsRange.prototype.getOppositeid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 3, ""));
};


/** @param {string} value */
proto.SocketCmd.SettingsRange.prototype.setOppositeid = function(value) {
  jspb.Message.setProto3StringField(this, 3, value);
};


/**
 * optional uint32 serverId = 6;
 * @return {number}
 */
proto.SocketCmd.SettingsRange.prototype.getServerid = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 6, 0));
};


/** @param {number} value */
proto.SocketCmd.SettingsRange.prototype.setServerid = function(value) {
  jspb.Message.setProto3IntField(this, 6, value);
};


/**
 * optional int32 lowValue = 25;
 * @return {number}
 */
proto.SocketCmd.SettingsRange.prototype.getLowvalue = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 25, 0));
};


/** @param {number} value */
proto.SocketCmd.SettingsRange.prototype.setLowvalue = function(value) {
  jspb.Message.setProto3IntField(this, 25, value);
};


/**
 * optional int32 heighValue = 26;
 * @return {number}
 */
proto.SocketCmd.SettingsRange.prototype.getHeighvalue = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 26, 0));
};


/** @param {number} value */
proto.SocketCmd.SettingsRange.prototype.setHeighvalue = function(value) {
  jspb.Message.setProto3IntField(this, 26, value);
};


/**
 * repeated uint32 cellAddrs = 37;
 * @return {!Array.<number>}
 */
proto.SocketCmd.SettingsRange.prototype.getCelladdrsList = function() {
  return /** @type {!Array.<number>} */ (jspb.Message.getRepeatedField(this, 37));
};


/** @param {!Array.<number>} value */
proto.SocketCmd.SettingsRange.prototype.setCelladdrsList = function(value) {
  jspb.Message.setField(this, 37, value || []);
};


/**
 * @param {!number} value
 * @param {number=} opt_index
 */
proto.SocketCmd.SettingsRange.prototype.addCelladdrs = function(value, opt_index) {
  jspb.Message.addToRepeatedField(this, 37, value, opt_index);
};


proto.SocketCmd.SettingsRange.prototype.clearCelladdrsList = function() {
  this.setCelladdrsList([]);
};


goog.object.extend(exports, proto.SocketCmd);