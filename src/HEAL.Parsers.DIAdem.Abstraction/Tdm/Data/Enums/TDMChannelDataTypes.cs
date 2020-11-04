namespace HEAL.Parsers.DIAdem.Tdm.Abstractions {
  public enum TDMChannelDataTypes {
        DDC_UInt8 = 5,  // unsigned char
        DDC_Int16 = 2,  // short
        DDC_Int32 = 3,  // int
        DDC_Float = 9,  // float
        DDC_Double = 10,    // double
        DDC_String = 23,    // string
        DDC_Timestamp = 30,	// timestamp (year/month/day/hour/minute/second/millisecond components)
    }
}
