using System.ComponentModel;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {
  public enum ChannelHeaderIdentifications {
    [Description("Channel name")]
    [TargetAttribute(nameof(ChannelHeader.Name))]
    Name = 200,
    [Description("Channel comment")]
    [TargetAttribute(nameof(ChannelHeader.Comment))]
    Comment = 201,
    [Description("Unit")]
    [TargetAttribute(nameof(ChannelHeader.Unit))]
    Unit = 202,
    [Description("Channel type")]
    [TargetAttribute(nameof(ChannelHeader.Type))]
    Type = 210,
    [Description("File from which channel data is read")]
    [TargetAttribute(nameof(ChannelHeader.FilePath))]
    FilePath = 211,
    [Description("Method of storing the data")]
    [TargetAttribute(nameof(ChannelHeader.DataStoringMethod))]
    DataStoringMethod = 213,
    [Description("Data type")]
    [TargetAttribute(nameof(ChannelHeader.DataType))]
    DataType = 214,
    [Description("Bit masking")]
    [TargetAttribute(nameof(ChannelHeader.BitMasking))]
    BitMasking = 215,
    [Description("No. of values in the channel")]
    [TargetAttribute(nameof(ChannelHeader.ValueCount))]
    ValueCount = 220,
    [Description("Pointer to the 1st value in the channel")]
    [TargetAttribute(nameof(ChannelHeader.PointerFirstValue))]
    PointerFirstValue = 221,
    [Description("Offset for ASCII block files for binary block files with header")]
    [TargetAttribute(nameof(ChannelHeader.BinaryBlockOffset))]
    BinaryBlockOffset = 222,
    [Description("Local ASCII-pointer in the case of ASCII block files")]
    [TargetAttribute(nameof(ChannelHeader.LocalASCIIPointer))]
    LocalASCIIPointer = 223,
    [Description("Separator character for ASCII-block files")]
    [TargetAttribute(nameof(ChannelHeader.SeparationCharacter))]
    SeparationCharacter = 230,
    [Description("Decimal character in ASCII-files")]
    [TargetAttribute(nameof(ChannelHeader.DecimalCharacter))]
    DecimalCharacter = 231,
    [Description("Exponential character in ASCII-files")]
    [TargetAttribute(nameof(ChannelHeader.ExponentialCharacter))]
    ExponentialCharacter = 232,
    [Description("Starting value / Offset")]
    [TargetAttribute(nameof(ChannelHeader.StartingValue))]
    StartingValue = 240,
    [Description("Step width / Factor")]
    [TargetAttribute(nameof(ChannelHeader.StepWidth))]
    StepWidth = 241,
    [Description("Minimum value in the channel")]
    [TargetAttribute(nameof(ChannelHeader.MinimumValue))]
    MinimumValue = 250,
    [Description("Maximum value of the channel")]
    [TargetAttribute(nameof(ChannelHeader.MaximumValue))]
    MaximumValue = 251,
    [Description("Keyword for NoValues in the channel")]
    [TargetAttribute(nameof(ChannelHeader.NoValueKeyword))]
    NoValueKeyword = 252,
    [Description("Keyword for monotony")]
    [TargetAttribute(nameof(ChannelHeader.MonotonyKeyword))]
    MonotonyKeyword = 253,
    [Description("Value for NoValues in the channel")]
    [TargetAttribute(nameof(ChannelHeader.NoValueValue))]
    NoValueValue = 254,
    [Description("Keyword for the data display at the interface")]
    [TargetAttribute(nameof(ChannelHeader.DataDisplayKeyword))]
    DataDisplayKeyword = 260,
    [Description("Register variable RV1 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable1))]
    RegisterVariable1 = 270,
    [Description("Register variable RV2 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable2))]
    RegisterVariable2 = 271,
    [Description("Register variable RV3 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable3))]
    RegisterVariable3 = 272,
    [Description("Register variable RV4 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable4))]
    RegisterVariable4 = 273,
    [Description("Register variable RV5 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable5))]
    RegisterVariable5 = 274,
    [Description("Register variable RV6 for storing the channel-related additional data")]
    [TargetAttribute(nameof(ChannelHeader.RegisterVariable6))]
    RegisterVariable6 = 275,
    [Description("Register variable Int1 for storing the channel-related additional data in Integer format")]
    [TargetAttribute(nameof(ChannelHeader.IntRegisterVariable1))]
    IntRegisterVariable1 = 280,
    [Description("Register variable Int2 for storing the channel-related additional data in Integer format")]
    [TargetAttribute(nameof(ChannelHeader.IntRegisterVariable2))]
    IntRegisterVariable2 = 281,
    [Description("Register variable Int3 for storing the channel-related additional data in Integer format")]
    [TargetAttribute(nameof(ChannelHeader.IntRegisterVariable3))]
    IntRegisterVariable3 = 282,
    [Description("Register variable Int4 for storing the channel-related additional data in Integer format")]
    [TargetAttribute(nameof(ChannelHeader.IntRegisterVariable4))]
    IntRegisterVariable4 = 283,
    [Description("Register variable Int5 for storing the channel-related additional data in Integer format")]
    [TargetAttribute(nameof(ChannelHeader.IntRegisterVariable5))]
    IntRegisterVariable5 = 284,   
    [Description("Reserve 1")]
    [TargetAttribute(nameof(ChannelHeader.Reserve1))]
    Reserve1 = 300,
    [Description("Reserve 2")]
    [TargetAttribute(nameof(ChannelHeader.Reserve2))]
    Reserve2 = 301,
  }
}
