using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HEAL.Parsers.DIAdem.Dat.Structures.Data;

namespace HEAL.Parsers.DIAdem.Dat.Structures {

  public enum DATChannelDataTypes {
    REAL32, REAL48, REAL64, MSREAL32,
    INT16, INT32,
    WORD8, WORD16, WORD32,
    TWOC12, TWOC16,
    ASCII
  }

  public enum DATChannelTypes {
    IMPLICIT, EXPLICIT
  }
  public enum DATDataStoringMethods {
    BLOCK, CHANNEL
  }

  public enum DATGlobalHeaderIdentifications {
    [Description("Keyword for the origin of the data set")]
    [TargetAttribute(nameof(GlobalHeader.OriginOfDataSet))]
    OriginOfDataSet = 1,
    [Description("Revision number")]
    [TargetAttribute(nameof(GlobalHeader.RevisionNumber))]
    RevisonNumber = 2,
    [Description("Description of the data set")]
    [TargetAttribute(nameof(GlobalHeader.DataSetDescription))]
    DataSetDescription = 101,
    [Description("Comments on the data set")]
    [TargetAttribute(nameof(GlobalHeader.DataSetComments))]
    DataSetComments = 102,
    [Description("Person processing the data set")]
    [TargetAttribute(nameof(GlobalHeader.DataSetProcessor))]
    DataSetProcessor = 103,
    [Description("Date")]
    [TargetAttribute(nameof(GlobalHeader.Date))]
    Date = 104,
    [Description("Time")]
    [TargetAttribute(nameof(GlobalHeader.Time))]
    Time = 105,
    [Description("Description of the comments")]
    [TargetAttribute(nameof(GlobalHeader.DataSetCommentsDescription))]
    DataSetCommentsDescription = 106,
    [Description("Time format for time-channels in the case of ASCII-files")]
    [TargetAttribute(nameof(GlobalHeader.TimeFormat))]
    TimeFormat = 110,
    [Description("Value for NoValues in the data file")]
    [TargetAttribute(nameof(GlobalHeader.NoValueValue))]
    NoValueValue = 111,
    [Description("Interchange high- and low-bytes")]
    [TargetAttribute(nameof(GlobalHeader.InterchangeHighAndLowBytes))]
    InterchangeHighAndLowBytes = 112,
    [Description("Reserve 1")]
    [TargetAttribute(nameof(GlobalHeader.Reserve1))]
    Reserve1 = 130,
    [Description("Reserve 2")]
    [TargetAttribute(nameof(GlobalHeader.Reserve2))]
    Reserve2 = 131,
    [Description("Reserve 3")]
    [TargetAttribute(nameof(GlobalHeader.Reserve3))]
    Reserve3 = 132,
    [Description("Reserve 4")]
    [TargetAttribute(nameof(GlobalHeader.Reserve4))]
    Reserve4 = 133,
  }

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
