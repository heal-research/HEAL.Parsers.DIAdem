using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using HEAL.Parsers.DIAdem.Dat.Abstractions;

namespace HEAL.Parsers.DIAdem.Dat.Structures {
  public static class EnumExtensions {
    public static int GetBitSize(this DATChannelDataTypes dataType) {
      switch (dataType) {
        case DATChannelDataTypes.ASCII:
          return 8;
        case DATChannelDataTypes.INT16:
          return 16;
        case DATChannelDataTypes.INT32:
          return 32;
        case DATChannelDataTypes.MSREAL32:
          return 32;
        case DATChannelDataTypes.REAL32:
          return 32;
        case DATChannelDataTypes.REAL48:
          return 48;
        case DATChannelDataTypes.REAL64:
          return 64;
        case DATChannelDataTypes.TWOC12:
          return 12;
        case DATChannelDataTypes.TWOC16:
          return 16;
        case DATChannelDataTypes.WORD8:
          return 8;
        case DATChannelDataTypes.WORD16:
          return 16;
        case DATChannelDataTypes.WORD32:
          return 32;
        default:
          throw new NotImplementedException($"{nameof(DATChannelDataTypes)}-Enum Value {dataType} not supported.");
      }
    }
  }
}
