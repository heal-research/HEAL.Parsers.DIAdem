using System;
using System.Collections.Generic;
using System.Text;
using HEAL.Parsers.DIAdem.Tdm.Structures;

using DDCFileHandle = System.Int64;
using DDCChannelHandle = System.Int64;
using DDCChannelGroupHandle = System.Int64;
using DDCDataType = System.Int64;

using System.Linq;
using static HEAL.Parsers.DIAdem.Tdm.NiLibDdc.NiLibDdcMethodSignatures;
using System.Runtime.InteropServices;
using HEAL.Parsers.DIAdem.Tdm.Abstractions;

namespace HEAL.Parsers.DIAdem.Tdm.NilibDdc {
  /// <summary>
  /// Defines the wrapped methods made availble from the 'nilibddcc.dll' (National Instruments LIBrary for DiaDem Connectivity)
  /// Methods may throw instances of <see cref="DDCException"/> if dll runs into an unexpected error.
  /// </summary>
  internal class NiLibDdcWrapper : NilibddcDeclaration {
    private static int CheckReturnCode(int v, params TDMReturnCodes[] ignoreCodes) {
      if (v == 0)
        return v;

      var enumval = (TDMReturnCodes)v;
      if (ignoreCodes.Contains(enumval))
        return v;

      throw new DDCException(v, enumval.GetEnumDescription());
    }
    /// <summary>
    /// Use default ignoreCodes. Call <see cref="CheckReturnCode(int, TDMReturnCodes[])"/> to specify which codes to ignore
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private static int CheckReturnCode(int v) {
      return CheckReturnCode(v
          , TDMReturnCodes.DDC_PropertyDoesNotContainData /*ignore error code -6214. null values will be handles as defaults*/);
    }

    #region Property-Getters
    internal static object GetPropertyData<THandl>(THandl h, string propertyName, TDMChannelDataTypes dataType)
        where THandl : Handle {
      //if (typeof(TVal) != dataType.GetNETDataType())
      //    throw new InvalidCastException($"Type {typeof(TVal).ToString()} was provided but type {dataType.GetNETDataType()} was expected. Provide a matching parameter to parameter{nameof(dataType)}.");

      switch (dataType) {
        case TDMChannelDataTypes.DDC_Double:
          return GetDoubleValue(h, propertyName);
        case TDMChannelDataTypes.DDC_Float:
          return GetFloatValue(h, propertyName);
        case TDMChannelDataTypes.DDC_Int16:
          return GetInt16Value(h, propertyName);
        case TDMChannelDataTypes.DDC_Int32:
          return GetInt32Value(h, propertyName);
        case TDMChannelDataTypes.DDC_String:
          return GetStringValue(h, propertyName);
        case TDMChannelDataTypes.DDC_Timestamp:
          return GetDateTimeValue(h, propertyName);
        case TDMChannelDataTypes.DDC_UInt8:
          return GetUInt8Value(h, propertyName);
      }
      throw new NotImplementedException("DataType not supported.");
    }

    internal static ChannelGroup CreateChannelGroup(FileHandle fileHandle) {
      throw new NotImplementedException();
    }

    private static object GetUInt8Value<THandl>(THandl h, string propertyName) where THandl : Handle {
      byte byteVal = 0;
      DDC_GetObjectPropertyUInt8 intDelegate;
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          intDelegate = DDC_GetFilePropertyUInt8;
          break;
        case TDMHandleTypes.ChannelGroup:
          intDelegate = DDC_GetChannelGroupPropertyUInt8;
          break;
        case TDMHandleTypes.Channel:
          intDelegate = DDC_GetChannelPropertyUInt8;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      CheckReturnCode(
          intDelegate(h.Ptr, propertyName, ref byteVal)
      );
      return byteVal;
    }

    private static string GetStringValue<THandl>(THandl h, string propertyName) where THandl : Handle {
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          return GetStringProperty(h, propertyName, DDC_GetFileStringPropertyLength, DDC_GetFileProperty);
        case TDMHandleTypes.ChannelGroup:
          return GetStringProperty(h, propertyName, DDC_GetChannelGroupStringPropertyLength, DDC_GetChannelGroupProperty);
        case TDMHandleTypes.Channel:
          return GetStringProperty(h, propertyName, DDC_GetChannelStringPropertyLength, DDC_GetChannelProperty);
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
    }

    private static Int32 GetInt32Value<THandl>(THandl h, string propertyName) where THandl : Handle {
      Int32 int32Val = 0;
      DDC_GetObjectPropertyInt32 intDelegate;
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          intDelegate = DDC_GetFilePropertyInt32;
          break;
        case TDMHandleTypes.ChannelGroup:
          intDelegate = DDC_GetChannelGroupPropertyInt32;
          break;
        case TDMHandleTypes.Channel:
          intDelegate = DDC_GetChannelPropertyInt32;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      CheckReturnCode(
          intDelegate(h.Ptr, propertyName, ref int32Val)
      );
      return int32Val;
    }

    private static Int16 GetInt16Value<THandl>(THandl h, string propertyName) where THandl : Handle {
      Int16 int16Val = 0;
      DDC_GetObjectPropertyInt16 intDelegate;
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          intDelegate = DDC_GetFilePropertyInt16;
          break;
        case TDMHandleTypes.ChannelGroup:
          intDelegate = DDC_GetChannelGroupPropertyInt16;
          break;
        case TDMHandleTypes.Channel:
          intDelegate = DDC_GetChannelPropertyInt16;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      CheckReturnCode(
          intDelegate(h.Ptr, propertyName, ref int16Val)
      );
      return int16Val;
    }

    private static float GetFloatValue<THandl>(THandl h, string propertyName) where THandl : Handle {
      float floatVal = 0;
      DDC_GetObjectPropertyFloat floatDelegate;
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          floatDelegate = DDC_GetFilePropertyFloat;
          break;
        case TDMHandleTypes.ChannelGroup:
          floatDelegate = DDC_GetChannelGroupPropertyFloat;
          break;
        case TDMHandleTypes.Channel:
          floatDelegate = DDC_GetChannelPropertyFloat;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      CheckReturnCode(
          floatDelegate(h.Ptr, propertyName, ref floatVal)
      );
      return floatVal;
    }

    private static double GetDoubleValue<THandl>(THandl h, string propertyName) where THandl : Handle {
      double doubleVal = 0;
      DDC_GetObjectPropertyDouble doubleDelegate;
      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          doubleDelegate = DDC_GetFilePropertyDouble;
          break;
        case TDMHandleTypes.ChannelGroup:
          doubleDelegate = DDC_GetChannelGroupPropertyDouble;
          break;
        case TDMHandleTypes.Channel:
          doubleDelegate = DDC_GetChannelPropertyDouble;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      CheckReturnCode(
          doubleDelegate(h.Ptr, propertyName, ref doubleVal)
      );
      return doubleVal;
    }

    private static DateTime GetDateTimeValue<THandl>(THandl h, string propertyName) where THandl : Handle {
      UInt32 year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0, weekDay = 0;
      double milliSecond = 0;

      DDC_GetObjectTimestampComponents timeStampMethod;

      switch (h.HandleType) {
        case TDMHandleTypes.FileHandle:
          timeStampMethod = DDC_GetFilePropertyTimestampComponents;
          break;
        case TDMHandleTypes.ChannelGroup:
          timeStampMethod = DDC_GetChannelGroupPropertyTimestampComponents;
          break;
        case TDMHandleTypes.Channel:
          timeStampMethod = DDC_GetChannelPropertyTimestampComponents;
          break;
        default:
          throw new NotImplementedException("HandleType not supported.");
      }
      var code = CheckReturnCode(
          timeStampMethod(h.Ptr, propertyName, ref year, ref month, ref day, ref hour, ref minute, ref second, ref milliSecond, ref weekDay)
          , TDMReturnCodes.DDC_InvalidTimeValue /*gets thrown when nilibddc does not support the time format*/
      );
      if (code == (int)TDMReturnCodes.DDC_InvalidTimeValue)
        return default(DateTime);
      return new DateTime((int)year, (int)month, (int)day, (int)hour, (int)minute, (int)second, (int)milliSecond);
    }

    #endregion

    #region File Management Methods

    internal static FileHandle OpenFile(string filePath, TDMFileTypes fileType = TDMFileTypes.TDM, bool readOnly = false) {
      DDCFileHandle handle = default(DDCFileHandle);
      CheckReturnCode(
          DDC_OpenFileEx(filePath, fileType.GetStringConstant(), readOnly ? 1 : 0, ref handle)
      );
      return new FileHandle(handle);
    }

    internal static void CloseFile(FileHandle fileHandle) {
      CheckReturnCode(
          DDC_CloseFile(fileHandle.Ptr)
      );
    }

    internal static void SaveFile(FileHandle fileHandle) {
      CheckReturnCode(
          DDC_SaveFile(fileHandle.Ptr)
      );
    }

    internal static FileHandle CreateFile(string path,
                              TDMFileTypes fileType,
                              string name,
                              string description,
                              string title,
                              string author) {
      DDCFileHandle fileHandle = default(DDCFileHandle);
      CheckReturnCode(
          DDC_CreateFile(path, fileType.GetStringConstant(), name, description, title, author, ref fileHandle)
      );
      return new FileHandle(fileHandle);
    }

    internal static FileProperties GetFileProperties(FileHandle fileHandle) {
      return new FileProperties() {
        Author = (string)GetPropertyData(fileHandle, Constants.FileProperties.AUTHOR, TDMChannelDataTypes.DDC_String),
        Description = (string)GetPropertyData(fileHandle, Constants.FileProperties.DESCRIPTION, TDMChannelDataTypes.DDC_String),
        Name = (string)GetPropertyData(fileHandle, Constants.FileProperties.NAME, TDMChannelDataTypes.DDC_String),
        Time = (DateTime)GetPropertyData(fileHandle, Constants.FileProperties.DATETIME, TDMChannelDataTypes.DDC_Timestamp),
        Title = (string)GetPropertyData(fileHandle, Constants.FileProperties.TITLE, TDMChannelDataTypes.DDC_String),
      };
    }



    #endregion

    #region Channel Methods

    /// <summary>
    /// retrieves any string property value of a <see cref="Channel"/> or <see cref="ChannelGroup"/> when provides with the correct access methods of the nilibddc
    /// </summary>
    /// <param name="h"><see cref="Handle"/> handle referencing the object</param>
    /// <param name="propertyName"><see cref="Constants.ChannelGroupProperties"/> or <see cref="Constants.ChannelProperties"/> for property name</param>
    /// <param name="lengthDelegate">a nilibddc method that implements the <see cref="NilibddcDeclaration.DDC_GetObjectPropertyLength"/> type to retrieve length of the string</param>
    /// <param name="propertyDelegate">a nilibddc method that implements the <see cref="NilibddcDeclaration.DDC_GetObjectProperty"/> type to retrieve the actual string</param>
    /// <returns>string value of the property</returns>
    private static string GetStringProperty(Handle h, string propertyName
                                                , DDC_GetObjectPropertyLength lengthDelegate
                                                , DDC_GetObjectProperty propertyDelegate) {
      UInt32 channelGroupNameLength = 0;
      CheckReturnCode(
          lengthDelegate(h.Ptr, propertyName, ref channelGroupNameLength)
      );

      byte[] byteChannelGroupName = new byte[channelGroupNameLength];
      CheckReturnCode(
          propertyDelegate(h.Ptr, propertyName, byteChannelGroupName, sizeof(UInt16) * (channelGroupNameLength + 1))
      );

      return (new ASCIIEncoding()).GetString(byteChannelGroupName);
    }

    /// <summary>
    /// retrieves any list of <see cref="Channel"/> or <see cref="ChannelGroup"/> when provides with the correct access methods of the nilibddc
    /// </summary>
    /// <param name="h"><see cref="Handle"/> handle referencing the object <see cref="FileHandle"/> or <see cref="ChannelGroup"/></param>
    /// <param name="getNumberOfObjectsMethod">a nilibddc method that implements the <see cref="NilibddcDeclaration.DDC_GetNumberOfObjects"/> that retrieves number of objects</param>
    /// <param name="getObjectsMethod">a nilibddc method that implements the <see cref="NilibddcDeclaration.DDC_GetObjects"/> that retrieves the actual object references</param>
    /// <returns></returns>
    private static IEnumerable<Handle> GetListOfObjects(Handle h
                                                , DDC_GetNumberOfObjects getNumberOfObjectsMethod
                                                , DDC_GetObjects getObjectsMethod) {
      UInt32 numberOfObjects = 0;
      CheckReturnCode(
          getNumberOfObjectsMethod(h.Ptr, ref numberOfObjects)
      );

      DDCChannelHandle[] objects = new DDCChannelHandle[numberOfObjects];
      CheckReturnCode(
          getObjectsMethod(h.Ptr, objects, numberOfObjects)
      );

      for (int objectNr = 0; objectNr < numberOfObjects; objectNr++) {
        yield return new Handle(objects[objectNr]);
      }
    }

    /// <summary>
    /// Retrieves a list of all available channels of a given <see cref="ChannelGroup"/>.
    /// and also fills properties like <see cref="Channel.Name"/> utilizing <see cref="NiLibDdcWrapper.GetChannelStringProperty(Handle, string)"/>
    /// </summary>
    /// <param name="fileHandle">handle of the file</param>
    /// <returns>List of filled <see cref="Channel"/> instances</returns>
    internal static IEnumerable<ChannelGroup> GetChannelGroups(FileHandle fileHandle) {
      foreach (var handle in GetListOfObjects(fileHandle, DDC_GetNumChannelGroups, DDC_GetChannelGroups)) {
        var group = new ChannelGroup(handle.Ptr);

        group.Name = GetStringProperty(group
                                    , Constants.ChannelGroupProperties.NAME
                                    , DDC_GetChannelGroupStringPropertyLength
                                    , DDC_GetChannelGroupProperty);
        group.Description = GetStringProperty(group
                                    , Constants.ChannelGroupProperties.DESCRIPTION
                                    , DDC_GetChannelGroupStringPropertyLength
                                    , DDC_GetChannelGroupProperty);

        yield return group;
      }
    }

    /// <summary>
    /// Retrieves a list of all available channels of a given <see cref="ChannelGroup"/>.
    /// and also fills properties like <see cref="Channel.Name"/> utilizing <see cref="NiLibDdcWrapper.GetChannelStringProperty(Handle, string)"/>
    /// </summary>
    /// <param name="channelGroup">handle of the channelGroup for which data should be retrieved/param>
    /// <returns>List of filled <see cref="Channel"/> instances</returns>
    internal static IEnumerable<Channel> GetChannels(ChannelGroup channelGroup) {
      foreach (var handle in GetListOfObjects(channelGroup, DDC_GetNumChannels, DDC_GetChannels)) {
        var channel = new Channel(handle.Ptr);

        channel.Name = (string)GetPropertyData(channel, Constants.ChannelProperties.NAME, TDMChannelDataTypes.DDC_String);
        channel.Description = (string)GetPropertyData(channel, Constants.ChannelProperties.DESCRIPTION, TDMChannelDataTypes.DDC_String);
        channel.Unit = (string)GetPropertyData(channel, Constants.ChannelProperties.UNIT_STRING, TDMChannelDataTypes.DDC_String);

        channel.ValueCount = GetDataValuesCount(channel);
        channel.ValueType = GetDataType(channel);

        //ToDo Florian: make call to GetPropertyData generic by type of channel.ValueType.GetNETDataType()
        channel.Minimum = (double)GetPropertyData(channel, Constants.ChannelProperties.MINIMUM, TDMChannelDataTypes.DDC_Double);
        channel.Maximum = (double)GetPropertyData(channel, Constants.ChannelProperties.MAXIMUM, TDMChannelDataTypes.DDC_Double);

        yield return channel;
      }
    }

    #endregion

    #region Channel-Data Methods

    /// <summary>
    /// returns the cast enumerable list of values associated with the channel.
    /// <typeparam name="T"> must match the value type defined by the <see cref="Channel.ValueType"/> (call <see cref="TDMChannelDataTypes.GetNETDataType()"/> provided as extension method) to get the matching type.
    /// </summary>
    /// <typeparam name="T">supports types <see cref="byte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="string"/>, <see cref="DateTime"/></typeparam>
    /// <param name="channelHandle"></param>
    /// <returns></returns>
    internal static IEnumerable<T> GetChannelData<T>(Channel channelHandle, uint firstValueIndex = 0, uint numberOfValues = 0) {
      if (typeof(T) != channelHandle.ValueType.GetNETDataType())
        throw new InvalidCastException($"Type {typeof(T).ToString()} was provided but type {channelHandle.ValueType.GetNETDataType()} was expected. Provide a matching parameter to {nameof(Channel.ValueType)}.");

      switch (channelHandle.ValueType) {
        case TDMChannelDataTypes.DDC_Double:
          return (IEnumerable<T>)GetDoubleChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_Float:
          return (IEnumerable<T>)GetFloatChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_Int16:
          return (IEnumerable<T>)GetInt16ChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_Int32:
          return (IEnumerable<T>)GetInt32ChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_String:
          return (IEnumerable<T>)GetStringChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_Timestamp:
          return (IEnumerable<T>)GetDateTimeChannelValues(channelHandle, firstValueIndex, numberOfValues);
        case TDMChannelDataTypes.DDC_UInt8:
          return (IEnumerable<T>)GetByteChannelValues(channelHandle, firstValueIndex, numberOfValues);
      }
      throw new NotImplementedException("DataType not supported.");
    }

    internal static uint GetDataValuesCount(Channel channelHandle) {
      UInt32 numDataValues = 0;

      CheckReturnCode(
          DDC_GetNumDataValues(channelHandle.Ptr, ref numDataValues)
      );
      return numDataValues;
    }

    internal static TDMChannelDataTypes GetDataType(Channel channelHandle) {
      DDCDataType dataType = 0;

      CheckReturnCode(
          DDC_GetDataType(channelHandle.Ptr, ref dataType)
      );
      return (TDMChannelDataTypes)dataType;
    }

    private static IEnumerable<byte> GetByteChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      byte[] values = new byte[length];
      CheckReturnCode(
          DDC_GetDataValuesUInt8(channel.Ptr, firstValueIndex, length, values)
      );
      return values;
    }

    private static IEnumerable<DateTime> GetDateTimeChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      UInt32[] years = new UInt32[length]
          , months = new UInt32[length]
          , days = new UInt32[length]
          , hours = new UInt32[length]
          , minutes = new UInt32[length]
          , seconds = new UInt32[length]
          , weekDays = new UInt32[length];
      double[] milliSeconds = new double[length];

      CheckReturnCode(
         DDC_GetDataValuesTimestampComponents(channel.Ptr, firstValueIndex, numberOfValues == 0 ? channel.ValueCount : numberOfValues
          , years, months, days, hours, minutes, seconds, milliSeconds, weekDays)
          , TDMReturnCodes.DDC_InvalidTimeValue /*gets thrown when nilibddc does not support the time format*/
      );

      for (int i = 0; i < channel.ValueCount; i++) {
        yield return new DateTime((int)years[i], (int)months[i], (int)days[i], (int)hours[i], (int)minutes[i], (int)seconds[i], (int)milliSeconds[i]);
      }
    }

    private static IEnumerable<string> GetStringChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      IntPtr[] values = new IntPtr[length];
      CheckReturnCode(
          DDC_GetDataValuesString(channel.Ptr, firstValueIndex, length, values)
      );
      return values.Select(s => Marshal.PtrToStringAnsi(s));
    }

    private static IEnumerable<Int32> GetInt32ChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      Int32[] values = new Int32[length];
      CheckReturnCode(
          DDC_GetDataValuesInt32(channel.Ptr, firstValueIndex, length, values)
      );
      return values;
    }

    private static IEnumerable<Int16> GetInt16ChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      Int16[] values = new Int16[length];
      CheckReturnCode(
          DDC_GetDataValuesInt16(channel.Ptr, firstValueIndex, length, values)
      );
      return values;
    }

    private static IEnumerable<float> GetFloatChannelValues(Channel channel, uint firstValueIndex = 0, uint numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      float[] values = new float[length];
      CheckReturnCode(
          DDC_GetDataValuesFloat(channel.Ptr, firstValueIndex, length, values)
      );
      return values;
    }


    private static IEnumerable<double> GetDoubleChannelValues(Channel channel, ulong firstValueIndex = 0, ulong numberOfValues = 0) {
      var length = numberOfValues == 0 ? channel.ValueCount : numberOfValues;
      double[] values = new double[length];
      CheckReturnCode(
          DDC_GetDataValuesDouble(channel.Ptr, firstValueIndex, length, values)
      );
      return values;
    }
    #endregion
  }
}

