using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HEAL.Parsers.DIAdem.Dat;
using HEAL.Parsers.DIAdem.Tdm;
using Xunit;

namespace HEAL.Parsers.DIAdem.Tests {
  public class Shared {
    /// <summary>
    /// TDM access library is not thread-safe; Multiple threads of unit tests might interfere and lock dll files.
    /// </summary>
    public static readonly object TdmReaderLock = new object();

    private const string TDM_File_Path = @"DIAdemFiles\testfile.tdm";
    public static TDMReader CreateTDMParserInstance() {

      return new TDMReader(TDM_File_Path);
    }

    private const string DAT_File_Path = @"DIAdemFiles\testfile.dat";
    public static DATReader CreateDATParserInstance() {
      return new DATReader(DAT_File_Path);
    }


    public static void CheckOneChannelDataCommon<T>(IChannelHeader channel, List<T> values) where T : IConvertible {
      Assert.Equal(channel.ValueCount, (uint)values.Count());

      var lastValue = values.First();
      foreach (var value in values.Skip(1)) {
        Assert.Equal(1, (dynamic)value - (dynamic)lastValue);
        lastValue = value;
      }
    }
  }
}
