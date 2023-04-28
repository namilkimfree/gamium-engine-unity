// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Gamium.Protocol.Packets
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct Env : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_10_26(); }
  public static Env GetRootAsEnv(ByteBuffer _bb) { return GetRootAsEnv(_bb, new Env()); }
  public static Env GetRootAsEnv(ByteBuffer _bb, Env obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Env __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Key { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKeyBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetKeyBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetKeyArray() { return __p.__vector_as_array<byte>(4); }
  public string Value { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetValueBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetValueBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetValueArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Gamium.Protocol.Packets.Env> CreateEnv(FlatBufferBuilder builder,
      StringOffset keyOffset = default(StringOffset),
      StringOffset valueOffset = default(StringOffset)) {
    builder.StartTable(2);
    Env.AddValue(builder, valueOffset);
    Env.AddKey(builder, keyOffset);
    return Env.EndEnv(builder);
  }

  public static void StartEnv(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddKey(FlatBufferBuilder builder, StringOffset keyOffset) { builder.AddOffset(0, keyOffset.Value, 0); }
  public static void AddValue(FlatBufferBuilder builder, StringOffset valueOffset) { builder.AddOffset(1, valueOffset.Value, 0); }
  public static Offset<Gamium.Protocol.Packets.Env> EndEnv(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Gamium.Protocol.Packets.Env>(o);
  }
  public EnvT UnPack() {
    var _o = new EnvT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(EnvT _o) {
    _o.Key = this.Key;
    _o.Value = this.Value;
  }
  public static Offset<Gamium.Protocol.Packets.Env> Pack(FlatBufferBuilder builder, EnvT _o) {
    if (_o == null) return default(Offset<Gamium.Protocol.Packets.Env>);
    var _key = _o.Key == null ? default(StringOffset) : builder.CreateString(_o.Key);
    var _value = _o.Value == null ? default(StringOffset) : builder.CreateString(_o.Value);
    return CreateEnv(
      builder,
      _key,
      _value);
  }
}

public class EnvT
{
  public string Key { get; set; }
  public string Value { get; set; }

  public EnvT() {
    this.Key = null;
    this.Value = null;
  }
}


}
