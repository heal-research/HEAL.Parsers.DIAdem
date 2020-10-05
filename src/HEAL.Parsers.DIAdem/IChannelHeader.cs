using System;

namespace HEAL.Parsers.DIAdem {
  public interface IChannelHeader {
    string Name { get; }
    uint ValueCount { get; }
    CommonChannelDataTypes CommonChannelDataType { get; }
  }
}
