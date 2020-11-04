using System;
using System.Collections.Generic;
using HEAL.Parsers.DIAdem;
using HEAL.Parsers.DIAdem.Abstractions;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {
  public interface IDATReader : IDIAdemReader {
    IEnumerable<IChannelHeader> GetChannelHeaders();
  }
}
