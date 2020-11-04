using System;

namespace HEAL.Parsers.DIAdem.Abstractions {
  public interface IChannelHeader {
    string Name { get; }
    uint ValueCount { get; }
    CommonChannelDataTypes CommonChannelDataType { get; }
  }
}
