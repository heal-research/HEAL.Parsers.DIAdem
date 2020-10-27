using System.ComponentModel;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public enum TDMChannelDataTypes {
        DDC_UInt8 = 5,  // unsigned char
        DDC_Int16 = 2,  // short
        DDC_Int32 = 3,  // int
        DDC_Float = 9,  // float
        DDC_Double = 10,    // double
        DDC_String = 23,    // string
        DDC_Timestamp = 30,	// timestamp (year/month/day/hour/minute/second/millisecond components)
    }

    public enum TDMFileTypes { TDM, TDMS }

    public enum TDMHandleTypes {
        AnyRef, FileHandle, ChannelGroup, Channel
    }

    public enum TDMReturnCodes {
        [Description("No error")]
        DDC_NoError = 0,
        [Description("Error Begin")]
        DDC_ErrorBegin = -6201,

        [Description("The library could not allocate memory.")]
        DDC_OutOfMemory = -6201,
        [Description("An invalid argument was passed to the library.")]
        DDC_InvalidArgument = -6202,
        [Description("An invalid data type was passed to the library.")]
        DDC_InvalidDataType = -6203,
        [Description("An unexpected error occurred in the library.")]
        DDC_UnexpectedError = -6204,
        [Description("The USI engine could not be loaded.")]
        DDC_UsiCouldNotBeLoaded = -6205,
        [Description("An invalid file handle was passed to the library.")]
        DDC_InvalidFileHandle = -6206,
        [Description("An invalid channel group handle was passed to the library.")]
        DDC_InvalidChannelGroupHandle = -6207,
        [Description("An invalid channel handle was passed to the library.")]
        DDC_InvalidChannelHandle = -6208,
        [Description("The file passed to the library does not exist.")]
        DDC_FileDoesNotExist = -6209,
        [Description("The file passed to the library is read only and cannot be modified.")]
        DDC_CannotWriteToReadOnlyFile = -6210,
        [Description("The storage could not be opened.")]
        DDC_StorageCouldNotBeOpened = -6211,
        [Description("The file passed to the library already exists and cannot be created.")]
        DDC_FileAlreadyExists = -6212,
        [Description("The property passed to the library does not exist.")]
        DDC_PropertyDoesNotExist = -6213,
        [Description("The property passed to the library does not have a value.")]
        DDC_PropertyDoesNotContainData = -6214,
        [Description("The value of the property passed to the library is an array and not a scalar.")]
        DDC_PropertyIsNotAScalar = -6215,
        [Description("The object type passed to the library does not exist.")]
        DDC_DataObjectTypeNotFound = -6216,
        [Description("The current implementation does not support this operation.")]
        DDC_NotImplemented = -6217,
        [Description("The file could not be saved.")]
        DDC_CouldNotSaveFile = -6218,
        [Description("The request would exceed the maximum number of data values for a channel.")]
        DDC_MaximumNumberOfDataValuesExceeded = -6219,
        [Description("An invalid channel name was passed to the library.")]
        DDC_InvalidChannelName = -6220,
        [Description("The channel group already contains a channel with this name.")]
        DDC_DuplicateChannelName = -6221,
        [Description("The current implementation does not support this data type.")]
        DDC_DataTypeNotSupported = -6222,
        [Description("File access denied.")]
        DDC_FileAccessDenied = -6224,
        [Description("The specified time value is invalid.")]
        DDC_InvalidTimeValue = -6225,
        [Description("The replace operation is not supported on data that has already been saved to a TDM streaming file.")]
        DDC_ReplaceNotSupportedForSavedTDMSData = -6226,
        [Description("The data type of the property does not match the expected data type.")]
        DDC_PropertyDataTypeMismatch = -6227,
        [Description("The data type of the channel does not match the expected data type.")]
        DDC_ChannelDataTypeMismatch = -6228,

        [Description("Error End")]
        DDC_ErrorEnd = -6228,
        [Description("Forsed Error Code into Int Size")]
        DDC_ErrorForceSizeTo32Bits = int.MaxValue,

        [Description("Not a standard error-code")]
        NoErrorRepresentation = -1
    }
}
