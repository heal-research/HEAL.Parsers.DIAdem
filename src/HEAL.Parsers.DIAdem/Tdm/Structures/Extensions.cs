using System;
using System.ComponentModel;
using System.Reflection;
using HEAL.Parsers.DIAdem.Tdm.Abstractions;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public static class StructureExtensions {
        public static string GetStringConstant(this TDMFileTypes fileType) {
            switch (fileType) {
                case TDMFileTypes.TDM:
                    return Constants.FileTypes.TDM;
                case TDMFileTypes.TDMS:
                    return Constants.FileTypes.TDM_STREAMING;
                default:
                    throw new NotImplementedException("Value not supported.");
            }
        }

        public static string GetEnumDescription(this Enum value) {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static Type GetNETDataType(this TDMChannelDataTypes ddcDataType) {
            switch (ddcDataType) {
                case TDMChannelDataTypes.DDC_Double:
                    return typeof(double);
                case TDMChannelDataTypes.DDC_Float:
                    return typeof(float);
                case TDMChannelDataTypes.DDC_Int16:
                    return typeof(Int16);
                case TDMChannelDataTypes.DDC_Int32:
                    return typeof(Int32);
                case TDMChannelDataTypes.DDC_String:
                    return typeof(string);
                case TDMChannelDataTypes.DDC_Timestamp:
                    return typeof(DateTime);
                case TDMChannelDataTypes.DDC_UInt8:
                    return typeof(Byte);
            }
            throw new NotImplementedException("Unsupported DataType");
        }
    }
}
