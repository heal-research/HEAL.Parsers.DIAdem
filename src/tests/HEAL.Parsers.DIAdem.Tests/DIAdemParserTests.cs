using System.Collections.Generic;
using System.Linq;
using HEAL.Parsers.DIAdem.Abstractions;
using Xunit;

namespace HEAL.Parsers.DIAdem.Tests {
  public class DIAdemParserTests {

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

  }
}
