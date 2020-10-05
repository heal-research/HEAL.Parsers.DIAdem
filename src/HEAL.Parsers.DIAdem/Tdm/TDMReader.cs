using HEAL.Parsers.DIAdem.Tdm.NilibDdc;
using HEAL.Parsers.DIAdem.Tdm.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm {
  /// <summary>
  /// Object oriented Parser that utilizes the nilibddc.dll for parsing *.tdm files
  /// Methods may throw instances of <see cref="DDCException"/> if dll runs into an unexpected error.
  /// </summary>
  public class TDMReader : ITDMReader {
    private readonly FileHandle _fileHandle;

    /// <summary>
    /// calls <see cref="TDMReader.TDMReader(FileInfo)"/> Constructor with <see cref="FileInfo"/> parameter
    /// </summary>
    /// <param name="pathToFile">string path to file</param>
    public TDMReader(string pathToFile) :
        this(new FileInfo(pathToFile)) { }

    /// <summary>
    /// creates a new instance of <see cref="TDMReader"/> and immediately opens the file provided in construktor parameters.
    /// Throws <see cref="FileNotFoundException"/> if file is not existent or <see cref="ArgumentException"/> if file is not '*.tdm' file
    /// </summary>
    /// <param name="file"></param>
    public TDMReader(FileInfo file) {
      if (!file.Exists)
        throw new FileNotFoundException("Supplied file-path does not point to a file.");
      if (!file.Extension.ToLowerInvariant().EndsWith($".{Constants.FileTypes.TDM.ToLowerInvariant()}"))
        throw new ArgumentException($"Supplied parameter {nameof(file)} must be of type {Constants.FileTypes.TDM}.", nameof(file));

      _fileHandle = NiLibDdcWrapper.OpenFile(file.FullName);
    }

    public FileProperties GetFileProperties() {
      return NiLibDdcWrapper.GetFileProperties(_fileHandle);
    }

    public IEnumerable<ChannelGroup> GetChannelGroups() {
      return NiLibDdcWrapper.GetChannelGroups(_fileHandle);
    }

    public IEnumerable<IChannelHeader> GetChannels() {
      foreach (var group in GetChannelGroups())
        foreach (var channel in GetChannels(group))
          yield return channel;
    }

    public IEnumerable<Channel> GetChannels(ChannelGroup group) {
      return NiLibDdcWrapper.GetChannels(group);
    }

    public IEnumerable<T> GetChannelData<T>(string channelName) where T : IConvertible {
      var channel = GetChannels().FirstOrDefault(header => header.Name == channelName);
      if (channel == null)
        throw new ArgumentException($"No channel with name '{channelName}' available.");

      return GetChannelData<T>(channel);
    }

    public IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader) where T : IConvertible {
      if (channelHeader is Channel)
        return GetChannelData<T>((Channel)channelHeader);

      throw new NotSupportedException($"The class {nameof(TDMReader)} does not support the {channelHeader.GetType()} implementation of {nameof(IChannelHeader)}");
    }

    public IEnumerable<T> GetChannelData<T>(Channel channel) where T : IConvertible {
      return NiLibDdcWrapper.GetChannelData<T>(channel);
    }

    public IEnumerable<T> GetChannelData<T>(string channelName, uint firstValueIndex = 0, uint numberOfValues = 0) where T : IConvertible {
      var channel = GetChannels().FirstOrDefault(header => header.Name == channelName);
      if (channel == null)
        throw new ArgumentException($"No channel with name '{channelName}' available.");

      return GetChannelData<T>(channel, firstValueIndex, numberOfValues);
    }

    public IEnumerable<T> GetChannelData<T>(IChannelHeader channelHeader, uint firstValueIndex = 0, uint numberOfValues = 0) where T : IConvertible {
      if (channelHeader is Channel)
        return GetChannelData<T>((Channel)channelHeader, firstValueIndex, numberOfValues);

      throw new NotSupportedException($"The class {nameof(TDMReader)} does not support the {channelHeader.GetType()} implementation of {nameof(IChannelHeader)}");
    }

    public IEnumerable<T> GetChannelData<T>(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) where T : IConvertible {
      return NiLibDdcWrapper.GetChannelData<T>(channel, firstValueIndex, numberOfValues);
    }

    protected void CloseFile() {
      NiLibDdcWrapper.CloseFile(_fileHandle);
    }

    public void Dispose() {
      CloseFile();
    }
  }
}
