using HEAL.Parsers.DIAdem.Tdm.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HEAL.Parsers.DIAdem;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
  public class Channel : Handle, IChannelHeader {
    public Channel(Int64 ptr)
        : base(ptr) { }
    public override TDMHandleTypes HandleType => TDMHandleTypes.Channel;
    public string Name { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public TDMChannelDataTypes ValueType { get; set; }
    public object Minimum { get; set; }
    public object Maximum { get; set; }
    public uint ValueCount { get; set; }

    public CommonChannelDataTypes CommonChannelDataType => ValueType.ToCommonChannelDataType();
  }
}
