using System;
using System.Collections.Generic;

namespace HEAL.Parsers.DIAdem {

  /// <summary>
  /// Largest denominator of DIAdem Parser functionality.
  /// For better performance or more functionality use the specialized interfaces <see cref="Tdm.ITDMReader"/> or <see cref="Dat.IDATReader"/>
  /// </summary>
  public interface IDIAdemReader : IDisposable {
    IEnumerable<T> GetChannelData<T>(string channelName) where T :  IConvertible;
    IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader) where T : IConvertible;
    IEnumerable<T> GetChannelData<T>(string channelName, uint firstValueIndex = 0, uint numberOfValues = 0) where T :  IConvertible;
    IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader, uint firstValueIndex = 0, uint numberOfValues = 0) where T :  IConvertible;
    IEnumerable<IChannelHeader> GetChannels();
  }
}