using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {

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
}
