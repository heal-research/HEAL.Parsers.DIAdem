using System;
using System.Collections.Generic;
using HEAL.Parsers.DIAdem.Dat.Structures;
using HEAL.Parsers.DIAdem;

namespace HEAL.Parsers.DIAdem.Dat {
  public interface IDATReader : IDIAdemReader {
    IEnumerable<T> GetChannelData<T>(ChannelHeader channel) where T :  IConvertible;
    IEnumerable<T> GetChannelData<T>(ChannelHeader channel, uint firstValueIndex = 0, uint numberOfValues = 0) where T :  IConvertible;
    IEnumerable<ChannelHeader> GetChannelHeaders();
    GlobalHeader GetGlobalHeader();
  }
}
