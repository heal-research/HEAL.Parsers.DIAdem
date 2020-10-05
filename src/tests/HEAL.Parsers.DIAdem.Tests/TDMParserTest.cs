using HEAL.Parsers.DIAdem.Tdm;
using HEAL.Parsers.DIAdem.Tdm.Structures;
using HEAL.Parsers.DIAdem.Tests;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace HEAL.Parsers.DIAdem.Tdm.Tests {


#if INCLUDE_TDM
  public class TDMParserTest {


    [Fact]
    public static void CheckFileInfoParsing() {
      lock (Shared.TdmReaderLock) {
        using (var parser = Shared.CreateTDMParserInstance()) {
          var fileInfo = parser.GetFileProperties();

          Assert.Equal("09/11/2020 12:02:04", fileInfo.Time.ToString(CultureInfo.InvariantCulture));
          Assert.Equal("testfile", fileInfo.Name);
          Assert.Equal("DataSetDescription", fileInfo.Title);
          Assert.Equal("DataSetProcessor", fileInfo.Author);
          Assert.Equal("", fileInfo.Description);
        }
      }
    }


    [Fact]
    public static void CheckChannelData() {
      using (var parser = Shared.CreateTDMParserInstance()) {
        var groups = parser.GetChannelGroups();
        var channels = new List<Channel>();
        foreach(var group in groups) {
          channels.AddRange(parser.GetChannels(group));
        }

        foreach (var channel in channels) {
          switch (channel.ValueType) {
            case TDMChannelDataTypes.DDC_Double:
              CheckOneChannelData<double>(parser, channel, 0, 100);
              CheckOneChannelData<double>(parser, channel, 0, 100);
              break;
            case TDMChannelDataTypes.DDC_Float:
              CheckOneChannelData<float>(parser, channel, 0, 100);
              CheckOneChannelData<float>(parser, channel, 0, 100);
              break;
            case TDMChannelDataTypes.DDC_Int32:
              CheckOneChannelData<Int32>(parser, channel, 0, 100);
              CheckOneChannelData<Int32>(parser, channel, 0, 100);
              break;
            case TDMChannelDataTypes.DDC_Int16:
              CheckOneChannelData<Int16>(parser, channel, 0, 100);
              CheckOneChannelData<Int16>(parser, channel, 0, 100);
              break;
          }
        }
      }
    }

    private static void CheckOneChannelData<T>(TDMReader parser, Channel channel, int startIndex, int length)
        where T : IConvertible {
      var values = parser.GetChannelData<T>(channel).ToList();
      var partialReadValues = parser.GetChannelData<T>(channel, (uint)startIndex, (uint)length).ToList();

      Assert.Equal(values, partialReadValues);
      Assert.Equal(channel.Maximum, values.Max().ToDouble(NumberFormatInfo.InvariantInfo));
      Assert.Equal(channel.Minimum, values.Min().ToDouble(NumberFormatInfo.InvariantInfo));
      Shared.CheckOneChannelDataCommon(channel, values);
    }
  }
#endif
}