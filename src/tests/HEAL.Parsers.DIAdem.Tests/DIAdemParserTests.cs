using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HEAL.Parsers.DIAdem.Dat;
using HEAL.Parsers.DIAdem.Tdm;
using Xunit;

namespace HEAL.Parsers.DIAdem.Tests {
  public class DIAdemParserTests {

#if INCLUDE_TDM
    [Fact]
    public static void CommonInterfaceTest() {
      IDIAdemReader parser;
      IEnumerable<double> tdmValues, datValues;

      lock (Shared.TdmReaderLock) {
        //TDM Tests
        parser = Shared.CreateTDMParserInstance();

        var tdmChannel = parser.GetChannels().First();

        tdmValues = parser.GetChannelData<double>(tdmChannel);
      }
      //DAT Tests
      parser = Shared.CreateDATParserInstance();
      var channel = parser.GetChannels().First();

      datValues = parser.GetChannelData<double>(channel);

      Assert.Equal(tdmValues, datValues);
    }
#endif

  }
}
