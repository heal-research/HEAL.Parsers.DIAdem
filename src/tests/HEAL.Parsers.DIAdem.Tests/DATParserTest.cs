
using System;
using System.Globalization;
using System.Linq;
using HEAL.Parsers.DIAdem.Dat.Abstractions;
using HEAL.Parsers.DIAdem.Tests;
using Xunit;

namespace HEAL.Parsers.DIAdem.Dat.Tests {
  public class DatParserTest {


    [Fact]
    public static void CheckFileInfoParsing() {
      using (var parser = Shared.CreateDATParserInstance()) {
        var fileInfo = parser.GetGlobalHeader() as GlobalHeader;

        Assert.Equal("DataSetDescription", fileInfo.DataSetDescription);
        Assert.Equal("DataSetProcessor", fileInfo.DataSetProcessor);
        Assert.Equal("High -> Low", fileInfo.InterchangeHighAndLowBytes);
        Assert.Equal("dd.MM.yyyy hh:mm:ss.ffff", fileInfo.NetTimeFormat);
        Assert.Equal("9.9E+300", fileInfo.NoValueValue);
        Assert.Equal("WINDOWS 32Bit", fileInfo.OriginOfDataSet);
        Assert.Equal("{@R:1200 {@V:12.00.4911 {@F:4.00", fileInfo.RevisionNumber);
        Assert.Equal("Reserve 1", fileInfo.Reserve1);
        Assert.Equal("Reserve 2", fileInfo.Reserve2);
        Assert.Equal("Reserve 3", fileInfo.Reserve3);
        Assert.Equal("Reserve 4", fileInfo.Reserve4);
      }
    }

    [Fact]
    public static void CheckChannelGroups() {
      using (var parser = Shared.CreateDATParserInstance()) {
        var channelHeaders = parser.GetChannelHeaders().Cast<ChannelHeader>();

        Assert.NotNull(channelHeaders);
        Assert.NotEmpty(channelHeaders);

        var fristChannel = channelHeaders.First();

        Assert.Equal("IncrementReal64_1", fristChannel.Name);
        Assert.Equal("Channel Comment", fristChannel.Comment);
        Assert.Equal("Numeric", fristChannel.DataDisplayKeyword);
        Assert.Equal(DATDataStoringMethods.CHANNEL, fristChannel.DataStoringMethod);
        Assert.Equal(DATChannelDataTypes.REAL64, fristChannel.DataType);
        Assert.Equal("REAL64.R64", fristChannel.FilePath);
        Assert.Equal(99, fristChannel.MaximumValue);
        Assert.Equal(0, fristChannel.MinimumValue);
        Assert.Equal("increasing", fristChannel.MonotonyKeyword);
        Assert.Equal("No", fristChannel.NoValueKeyword);
        Assert.Equal(1, fristChannel.PointerFirstValue);
        Assert.Equal(0, fristChannel.StartingValue);
        Assert.Equal(1, fristChannel.StepWidth);
        Assert.Equal(DATChannelTypes.EXPLICIT, fristChannel.Type);
        Assert.Equal((uint)100, fristChannel.ValueCount);
      }
    }

    [Fact]
    public static void CheckChannelData() {
      using (var parser = Shared.CreateDATParserInstance()) {
        var channelHeaders = parser.GetChannelHeaders().Cast<ChannelHeader>().ToList();

        foreach (var channel in channelHeaders) {
          switch (channel.DataType) {
            case DATChannelDataTypes.REAL64:
              CheckOneChannelData<double>(parser, channel, 0, 100);
              CheckOneChannelData<double>(parser, channel, 0, 100);
              break;
            case DATChannelDataTypes.REAL32:
              CheckOneChannelData<float>(parser, channel, 0, 100);
              CheckOneChannelData<float>(parser, channel, 0, 100);
              break;
            case DATChannelDataTypes.INT32:
              CheckOneChannelData<Int32>(parser, channel, 0, 100);
              CheckOneChannelData<Int32>(parser, channel, 0, 100);
              break;
            case DATChannelDataTypes.INT16:
              CheckOneChannelData<Int16>(parser, channel, 0, 100);
              CheckOneChannelData<Int16>(parser, channel, 0, 100);
              break;
          }
        }
      }
    }

    private static void CheckOneChannelData<T>(DATReader parser, ChannelHeader channel, int startIndex, int length)
        where T : IConvertible {
      var values = parser.GetChannelData<T>(channel).ToList();
      var partialReadValues = parser.GetChannelData<T>(channel, (uint)startIndex, (uint)length).ToList();

      Assert.Equal(values, partialReadValues);
      Assert.Equal(channel.MaximumValue, values.Max().ToDouble(NumberFormatInfo.InvariantInfo));
      Assert.Equal(channel.MinimumValue, values.Min().ToDouble(NumberFormatInfo.InvariantInfo));
      Shared.CheckOneChannelDataCommon(channel, values);
    }

    
  }
}
