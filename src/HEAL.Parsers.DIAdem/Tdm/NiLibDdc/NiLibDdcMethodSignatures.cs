using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using DDCHandle = System.Int64;
using DDCFileHandle = System.Int64;
using DDCChannelHandle = System.Int64;
using DDCChannelGroupHandle = System.Int64;
using DDCDataType = System.Int64;
using size_t = System.UInt64;


namespace HEAL.Parsers.DIAdem.Tdm.NiLibDdc
{
    public class NiLibDdcMethodSignatures
    {
        #region getobjectsmethods-delegates
        /// <summary>
        /// Shared Signature of a DCC Method that return amount of occurances of a handle type like <see cref="ChannelGroup"/> or <see cref="Channel"/>
        /// </summary>
        /// <param name="handle">Handle of the <see cref="ChannelGroup"/> or <see cref="Channel"/></param>
        /// <param name="numberOfObjects">returns amount of occurences</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetNumberOfObjects(DDCHandle handle
                                          , ref UInt32 numberOfObjects);

        /// <summary>
        ///  Shared Signature of a DCC Method that return the actual object references. requires call to suitable <see cref="DDC_GetNumberOfObjects"/> first.
        /// </summary>
        /// <param name="handle">Handle of the <see cref="ChannelGroup"/> or <see cref="Channel"/></param>
        /// <param name="objectReferences">references to the Objects</param>
        /// <param name="numberOfObjects">amount of occurences</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjects(DDCHandle handle
                                          , DDCHandle[] objectReferences
                                          , size_t numberOfObjects);

        /// <summary>
        ///  Shared Signature of a DCC Method that return the length a string property
        /// </summary>
        /// <param name="handle">Handle of the <see cref="ChannelGroup"/> or <see cref="Channel"/></param>
        /// <param name="property">name of the property</param>
        /// <param name="length">length of the string value</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyLength(DDCHandle handle
                                          , [MarshalAs(UnmanagedType.LPStr)] string property
                                          , ref UInt32 length);

        /// <summary>
        ///  Shared Signature of a DCC Method that return the value a string property
        /// </summary>
        /// <param name="handle">Handle of the <see cref="ChannelGroup"/> or <see cref="Channel"/></param>
        /// <param name="property">name of the property</param>
        /// <param name="value">actual property value</param>
        /// <param name="valueSizeInBytes">length of the string value</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectProperty(DDCChannelHandle channel
                                      , [MarshalAs(UnmanagedType.LPStr)] string property
                                      , byte[] value
                                      , size_t valueSizeInBytes);
        #endregion

        #region GetObject-Property Methods

        /// <summary>
        /// Shared Signature of a DCC Method that returns the String-PropertyLength of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="length">REF returned length of the string property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectStringPropertyLength(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref UInt32 length);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="byte"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="byte"/> value of the property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyUInt8(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref byte value);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="Int16"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="Int16"/> value of the property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyInt16(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int16 value);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="Int32"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="Int32"/> value of the property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyInt32(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref Int32 value);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="float"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="float"/> value of the property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyFloat(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref float value);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="double"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="double"/> value of the property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyDouble(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , ref double value);

        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="string"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="value">REF actual <see cref="string"/> value of the property</param>
        /// <param name="valueSize">length of the string property</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectPropertyString(DDCHandle handle
                                    , [MarshalAs(UnmanagedType.LPStr)] string property
                                    , string value
                                    , size_t valueSize);


        /// <summary>
        /// Shared Signature of a DCC Method that returns the <see cref="DateTime"/>-Property value of an Object
        /// </summary>
        /// <param name="handle">Handle of the <see cref="FileHandle"/>, <see cref="ChannelGroup"/>, <see cref="Channel"/></param>
        /// <param name="property">Name of the queried property</param>
        /// <param name="year">year portion</param>
        /// <param name="month">month portion</param>
        /// <param name="day">day portion</param>
        /// <param name="hour">hour</param>
        /// <param name="minute">minute</param>
        /// <param name="second">second</param>
        /// <param name="milliSecond">milliseconds</param>
        /// <returns>DDC Return Code</returns>
        public delegate int DDC_GetObjectTimestampComponents(DDCHandle handle
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
    }
}
