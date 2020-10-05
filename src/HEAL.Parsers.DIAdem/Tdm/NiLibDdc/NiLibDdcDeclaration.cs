using System;
using System.Collections.Generic;
using System.Text;


using DDCHandle = System.Int64;
using DDCFileHandle = System.Int64;
using DDCChannelHandle = System.Int64;
using DDCChannelGroupHandle = System.Int64;
using DDCDataType = System.Int64;
using size_t = System.UInt64;
using System.Runtime.InteropServices;
using HEAL.Parsers.DIAdem.Tdm.Structures;

namespace HEAL.Parsers.DIAdem.Tdm.NilibDdc
{
    internal class NilibddcDeclaration
    {
        #region File Management Methods
        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_CreateFile([MarshalAs(UnmanagedType.LPStr)] string filePath
                    , [MarshalAs(UnmanagedType.LPStr)] string fileType
                    , [MarshalAs(UnmanagedType.LPStr)] string name
                    , [MarshalAs(UnmanagedType.LPStr)] string description
                    , [MarshalAs(UnmanagedType.LPStr)] string title
                    , [MarshalAs(UnmanagedType.LPStr)] string author
                    , ref DDCFileHandle file);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_AddChannelGroup(DDCFileHandle file
                    , [MarshalAs(UnmanagedType.LPStr)] string name
                    , [MarshalAs(UnmanagedType.LPStr)] string description
                    , ref DDCChannelGroupHandle channelGroup);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_AddChannel(DDCChannelGroupHandle channelGroup
                    , DDCDataType dataType
                    , [MarshalAs(UnmanagedType.LPStr)] string name
                    , [MarshalAs(UnmanagedType.LPStr)] string description
                    , [MarshalAs(UnmanagedType.LPStr)] string unitString
                    , ref DDCChannelHandle channel);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_SaveFile(DDCFileHandle file);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_OpenFileEx([MarshalAs(UnmanagedType.LPStr)] string filePath
            , [MarshalAs(UnmanagedType.LPStr)] string fileType
            , int read_only
            , ref DDCFileHandle DDCFileHandle);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_CloseFile(DDCFileHandle file);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFileProperty(DDCFileHandle fileHandle
                                      , [MarshalAs(UnmanagedType.LPStr)] string property
                                      , byte[] value
                                      , size_t valueSizeInBytes);

        #endregion

        #region GetObjectsMethods-ChannelGroup Methods

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetNumChannelGroups(DDCFileHandle file
            , ref UInt32 numChannelGroups);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroups(DDCFileHandle file
            , DDCChannelGroupHandle[] channelGroupsBuf
            , size_t numChannelGroups);


        [DllImport("nilibddc.dll", CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupStringPropertyLength(DDCChannelGroupHandle channel
                                          , [MarshalAs(UnmanagedType.LPStr)] string property
                                          , ref UInt32 length);

        [DllImport("nilibddc.dll", CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupProperty(DDCChannelHandle channel
                                      , [MarshalAs(UnmanagedType.LPStr)] string property
                                      , byte[] value
                                      , size_t valueSizeInBytes);

        #endregion

        #region GetObjectsMethods-Channel Methods

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetNumChannels(DDCChannelGroupHandle channelGroup
                                  , ref UInt32 numChannels);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannels(DDCChannelGroupHandle channelGroup
                                       , DDCChannelHandle[] channelsBuf
                                       , size_t numChannels);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelStringPropertyLength(DDCChannelHandle channel
                                                  , [MarshalAs(UnmanagedType.LPStr)] string property
                                                  , ref UInt32 length);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelProperty(DDCChannelHandle channel
                                      , [MarshalAs(UnmanagedType.LPStr)] string property
                                      , byte[] value
                                      , size_t valueSizeInBytes);



        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataType(DDCChannelHandle channel
                                       , ref DDCDataType dataType);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetNumDataValues(DDCChannelHandle channel
                                    , ref UInt32 numValues);

        #endregion



        #region File-Property Methods

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFileStringProperty(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 length);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFileStringPropertyLength(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 length);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyUInt8(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref byte value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyInt16(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int16 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyInt32(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int32 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyFloat(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref float value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyDouble(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref double value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyString(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , string value
                                    , size_t valueSize);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetFilePropertyTimestampComponents(DDCFileHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 year
                                    , ref UInt32 month
                                    , ref UInt32 day
                                    , ref UInt32 hour
                                    , ref UInt32 minute
                                    , ref UInt32 second
                                    , ref double milliSecond
                                    , ref UInt32 weekDay);

        #endregion

        #region ChannelGroup-Property Methods


        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyUInt8(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref byte value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyInt16(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int16 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyInt32(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int32 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyFloat(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref float value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyDouble(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref double value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyString(DDCChannelGroupHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , string value
                                    , size_t valueSize);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelGroupPropertyTimestampComponents(DDCChannelGroupHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 year
                                    , ref UInt32 month
                                    , ref UInt32 day
                                    , ref UInt32 hour
                                    , ref UInt32 minute
                                    , ref UInt32 second
                                    , ref double milliSecond
                                    , ref UInt32 weekDay);

        #endregion

        #region Channel-Property Methods


        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyUInt8(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref byte value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyInt16(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int16 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyInt32(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int32 value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyFloat(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref float value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyDouble(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref double value);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyString(DDCChannelHandle channel
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , string value
                                    , size_t valueSize);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetChannelPropertyTimestampComponents(DDCChannelHandle file
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 year
                                    , ref UInt32 month
                                    , ref UInt32 day
                                    , ref UInt32 hour
                                    , ref UInt32 minute
                                    , ref UInt32 second
                                    , ref double milliSecond
                                    , ref UInt32 weekDay);

        #endregion

        #region Channel-Data Methods

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValues(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , byte[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesUInt8(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , byte[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesInt16(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , Int16[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesInt32(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , Int32[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesFloat(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , float[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesDouble(DDCChannelHandle channel
                                    , UInt64 indexOfFirstValueToGet
                                    , UInt64 numValuesToGet
                                    , double[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesString(DDCChannelHandle channel
                                    , UInt32 indexOfFirstValueToGet
                                    , UInt32 numValuesToGet
                                    , IntPtr[] values);

        [DllImport(Constants.DDLPath, CharSet = CharSet.Auto)]
        protected static extern int DDC_GetDataValuesTimestampComponents(DDCChannelHandle channel
                                    , size_t indexOfFirstValueToGet
                                    , size_t numValuesToGet
                                    , UInt32[] year
                                    , UInt32[] month
                                    , UInt32[] day
                                    , UInt32[] hour
                                    , UInt32[] minute
                                    , UInt32[] second
                                    , double[] milliSecond
                                    , UInt32[] weekDay);
        #endregion
    }
}
