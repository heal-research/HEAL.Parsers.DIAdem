using System;
using System.Collections.Generic;
using System.Text;
using HEAL.Parsers.DIAdem.Dat.Structures;
using HEAL.Parsers.DIAdem.Tdm.Structures;

namespace HEAL.Parsers.DIAdem {

  /// <summary>
  /// contains all common ChannelDataTypes 
  /// </summary>
  public enum CommonChannelDataTypes {
    Int16, Int32, Single, Double, String, DIAdemFileSpecific
  }

  public static class ChannelDataTypeExtensions {
    /// <summary>
    /// returns the matching channel content type.
    /// returns <see cref="CommonChannelDataTypes.DIAdemFileSpecific"/> if no DIAdem common type is stored in this channel
    /// </summary>
    /// <param name="dataTypes">type to be mapped</param>
    /// <returns></returns>
    public static CommonChannelDataTypes ToCommonChannelDataType(this DATChannelDataTypes dataTypes) {
      switch (dataTypes) {
        case DATChannelDataTypes.INT16:
          return CommonChannelDataTypes.Int16;
        case DATChannelDataTypes.INT32:
          return CommonChannelDataTypes.Int32;
        case DATChannelDataTypes.REAL32:
          return CommonChannelDataTypes.Single;
        case DATChannelDataTypes.REAL64:
          return CommonChannelDataTypes.Double;
        case DATChannelDataTypes.WORD32:
          return CommonChannelDataTypes.String;
        case DATChannelDataTypes.WORD16:
          return CommonChannelDataTypes.String;
        default:
          return CommonChannelDataTypes.DIAdemFileSpecific;
      }
    }

    /// <summary>
    /// returns the matching channel content type.
    /// returns <see cref="CommonChannelDataTypes.DIAdemFileSpecific"/> if no DIAdem common type is stored in this channel
    /// </summary>
    /// <param name="dataTypes">type to be mapped</param>
    /// <returns></returns>
    public static CommonChannelDataTypes ToCommonChannelDataType(this TDMChannelDataTypes dataTypes) {
      switch (dataTypes) {
        case TDMChannelDataTypes.DDC_Int16:
          return CommonChannelDataTypes.Int16;
        case TDMChannelDataTypes.DDC_Int32:
          return CommonChannelDataTypes.Int32;
        case TDMChannelDataTypes.DDC_Float:
          return CommonChannelDataTypes.Single;
        case TDMChannelDataTypes.DDC_Double:
          return CommonChannelDataTypes.Double;
        case TDMChannelDataTypes.DDC_String:
          return CommonChannelDataTypes.String;
        default:
          return CommonChannelDataTypes.DIAdemFileSpecific;
      }
    }
  }
}
