using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HEAL.Parsers.DIAdem;
using HEAL.Parsers.DIAdem.Abstractions;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {
  public class ChannelHeader : IDATHeader, IChannelHeader {
    public string Name { get; set; }
    public string Comment { get; set; }
    public string Unit { get; set; }
    public DATChannelTypes Type { get; set; }
    public string FilePath { get; set; }
    public DATDataStoringMethods DataStoringMethod { get; set; }
    public DATChannelDataTypes DataType { get; set; }                               
    public string BitMasking { get; set; }
    public uint ValueCount { get; set; }
    public double PointerFirstValue { get; set; }
    public string BinaryBlockOffset { get; set; }
    public string LocalASCIIPointer { get; set; }
    public string SeparationCharacter { get; set; }
    public string DecimalCharacter { get; set; }
    public string ExponentialCharacter { get; set; }
    public double StartingValue { get; set; }
    public double StepWidth { get; set; }
    public double MinimumValue { get; set; }
    public double MaximumValue { get; set; }
    public string NoValueKeyword { get; set; }
    public string MonotonyKeyword { get; set; }
    public string NoValueValue { get; set; }
    public string DataDisplayKeyword { get; set; }
    public string RegisterVariable1 { get; set; }
    public string RegisterVariable2 { get; set; }
    public string RegisterVariable3 { get; set; }
    public string RegisterVariable4 { get; set; }
    public string RegisterVariable5 { get; set; }
    public string RegisterVariable6 { get; set; }
    public int IntRegisterVariable1 { get; set; }
    public int IntRegisterVariable2 { get; set; }
    public int IntRegisterVariable3 { get; set; }
    public int IntRegisterVariable4 { get; set; }
    public int IntRegisterVariable5 { get; set; }
    public string Reserve1 { get; set; }
    public string Reserve2 { get; set; }

    public CommonChannelDataTypes CommonChannelDataType => DataType.ToCommonChannelDataType();
  }
}
