namespace HEAL.Parsers.DIAdem.Dat.Structures {
  /// <summary>
  /// defines constant values associated with the DAT file format and the parser
  /// </summary>
  public static class Constants {
    /// <summary>
    /// Supported File-Types
    /// </summary>
    internal static class FileTypes {
      public const string DAT = "DAT";
    }
    /// <summary>
    /// String constants of *.dat header files used to delimit the header sections
    /// </summary>
    internal static class HeaderDelimiters {
      public const string GlobalHeaderStart = "#BEGINGLOBALHEADER";
      public const string GlobalHeaderEnd = "#ENDGLOBALHEADER";
      public const string ChannelHeaderStart = "#BEGINCHANNELHEADER";
      public const string ChannelHeaderEnd = "#ENDCHANNELHEADER";
    }
  }
}
