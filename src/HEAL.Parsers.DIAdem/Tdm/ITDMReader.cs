using System;
using System.Collections.Generic;
using HEAL.Parsers.DIAdem.Tdm.Structures;

namespace HEAL.Parsers.DIAdem.Tdm {
  public interface ITDMReader : IDIAdemReader {
    IEnumerable<T> GetChannelData<T>(Channel channel) where T : IConvertible;
    IEnumerable<T> GetChannelData<T>(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) where T : IConvertible;
    IEnumerable<ChannelGroup> GetChannelGroups();
    IEnumerable<Channel> GetChannels(ChannelGroup group);
    FileProperties GetFileProperties();
  }
}
