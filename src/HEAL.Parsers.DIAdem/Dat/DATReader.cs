using HEAL.Parsers.DIAdem.Abstractions;
using HEAL.Parsers.DIAdem.Dat.Abstractions;
using HEAL.Parsers.DIAdem.Dat.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HEAL.Parsers.DIAdem.Dat {

  public class DATReader : IDATReader {
    private readonly string[] _headerLines;
    private ChannelHeader[] channelHeaders;
    private readonly FileInfo _fileInfo;

    /// <summary>
    /// calls <see cref="DATReader.DATReader(FileInfo)"/> Constructor with <see cref="FileInfo"/> parameter
    /// </summary>
    /// <param name="pathToFile">string path to file</param>
    public DATReader(string pathToFile) :
        this(new FileInfo(pathToFile)) {  }

    /// <summary>
    /// creates a new instance of <see cref="TDMReader"/> and immediately opens the file provided in constructor parameters.
    /// Throws <see cref="FileNotFoundException"/> if file is not existent or <see cref="ArgumentException"/> if file is not '*.tdm' file
    /// </summary>
    /// <param name="file"></param>
    public DATReader(FileInfo file) {
      if (!file.Exists)
        throw new FileNotFoundException("Supplied file path does not point to a file.");
      if (!file.Extension.ToLowerInvariant().EndsWith($".{Constants.FileTypes.DAT.ToLowerInvariant()}"))
        throw new ArgumentException($"Supplied parameter {nameof(file)} must be of type {Constants.FileTypes.DAT}.", nameof(file));

      _headerLines = File.ReadAllLines(file.FullName);
      _fileInfo = file;
    }

    public IGlobalHeader GetGlobalHeader() {
      int startIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.GlobalHeaderStart);
      int endIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.GlobalHeaderEnd);

      GlobalHeader header = new GlobalHeader();

      for (int i = startIndex; i < endIndex; i++) {
        header.ParseLine<GlobalHeader, DATGlobalHeaderIdentifications>(_headerLines[i]);
      }

      return header;
    }

    public IEnumerable<IChannelHeader> GetChannels() {
      return GetChannelHeaders();
    }

    public IEnumerable<IChannelHeader> GetChannelHeaders() {
      if(channelHeaders == null)
        channelHeaders = ParseChannelHeaders().ToArray();

      return channelHeaders;
    }
    private IEnumerable<ChannelHeader> ParseChannelHeaders() {
      int startIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.ChannelHeaderStart);
      int endIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.ChannelHeaderEnd);

      int startSearchIndex = startIndex;

      while (endIndex > startSearchIndex && startIndex > 0 && endIndex > 0) {
        startSearchIndex = endIndex;

        ChannelHeader header = new ChannelHeader();
        for (int i = startIndex; i < endIndex; i++) {
          header.ParseLine<ChannelHeader, ChannelHeaderIdentifications>(_headerLines[i]);
        }

        yield return header;

        startIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.ChannelHeaderStart, startSearchIndex);
        if (startIndex < 0)
          break; //no more values found
        endIndex = Array.IndexOf(_headerLines, Constants.HeaderDelimiters.ChannelHeaderEnd, startIndex);
      }
    }

    public IEnumerable<T> GetChannelData<T>(string channelName)
                            where T :  IConvertible {
      var channel = GetChannelHeaders().FirstOrDefault(header => header.Name == channelName);
      if (channel == null)
        throw new ArgumentException($"No channel with name '{channelName}' available.");

      return GetChannelData<T>(channel);
    }

    public IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader)
                            where T :  IConvertible {
      if (channelHeader is ChannelHeader)
        return GetChannelData<T>((ChannelHeader)channelHeader);

      throw new NotSupportedException($"The class {nameof(DATReader)} does not support the {channelHeader.GetType()} implementation of {nameof(IChannelHeader)}");
    }

    public IEnumerable<T> GetChannelData<T>(ChannelHeader channel)
                            where T :  IConvertible {

      if (string.IsNullOrEmpty(_fileInfo.Directory.FullName) || string.IsNullOrEmpty(channel.FilePath))
        yield break;

      using (var fileReader = new FileStream(Path.Combine(_fileInfo.Directory.FullName, channel.FilePath), FileMode.Open, FileAccess.Read))
      using (var binReader = new BinaryReader(fileReader)) {
        foreach (T value in ReadChannelData<T>(binReader, channel.DataType, channel.DataType.GetBitSize(), (long)channel.PointerFirstValue, channel.ValueCount))
          yield return value;
      }
    }

    public IEnumerable<T> GetChannelData<T>(string channelName, uint startValueCount, uint valueCount)
                            where T :  IConvertible {
      var channel = GetChannelHeaders().FirstOrDefault(header => header.Name == channelName);
      if (channel == null)
        throw new ArgumentException($"No channel with name '{channelName}' available.");

      return GetChannelData<T>(channel, startValueCount,valueCount);
    }

    public IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader, uint startValueCount, uint valueCount)
                            where T :  IConvertible {
      if (channelHeader is ChannelHeader)
        return GetChannelData<T>((ChannelHeader)channelHeader, startValueCount, valueCount);

      throw new NotSupportedException($"The class {nameof(DATReader)} does not support the {channelHeader.GetType()} implementation of {nameof(IChannelHeader)}");
    }

    public IEnumerable<T> GetChannelData<T>(ChannelHeader channel,uint startValueCount, uint valueCount)
                            where T :  IConvertible {

      if (string.IsNullOrEmpty(_fileInfo.Directory.FullName) || string.IsNullOrEmpty(channel.FilePath))
        yield break;

      using (var fileReader = new FileStream(Path.Combine(_fileInfo.Directory.FullName, channel.FilePath), FileMode.Open, FileAccess.Read))
      using (var binReader = new BinaryReader(fileReader)) {
        foreach (T value in ReadChannelData<T>(binReader, channel.DataType, channel.DataType.GetBitSize(), (long)channel.PointerFirstValue + startValueCount, valueCount))
          yield return value;
      }
    }

    private IEnumerable<T> ReadChannelData<T>(BinaryReader binReader,DATChannelDataTypes channelDataType, int bitSize, long startPosition, long valueCount) {
      binReader.BaseStream.Position = (bitSize / 8) * (long)(startPosition - 1);
      for (int i = 0; i < valueCount; i++) {

        switch (channelDataType) {
          case DATChannelDataTypes.INT16:
            yield return (T)Convert.ChangeType(binReader.ReadInt16(), typeof(T));
            break;
          case DATChannelDataTypes.INT32:
            yield return (T)Convert.ChangeType(binReader.ReadInt32(), typeof(T));
            break;
          case DATChannelDataTypes.REAL32:
            yield return (T)Convert.ChangeType(binReader.ReadSingle(), typeof(T));
            break;
          case DATChannelDataTypes.REAL64:
            yield return (T)Convert.ChangeType(binReader.ReadDouble(), typeof(T));
            break;
          default:
            throw new NotImplementedException();
        }
      }
    }

    public void Dispose() {
    }

  }
}
