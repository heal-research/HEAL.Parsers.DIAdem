
namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public static class Constants {
        public const string DDLPath = "nilibddc.dll";

        // File type constants
        internal static class FileTypes {
            public const string TDM = "TDM";
            public const string TDM_STREAMING = "TDMS";
        }
        // File property constants
        public static class FileProperties {
            public const string NAME = "name";     // Name
            public const string DESCRIPTION = "description";   // Description
            public const string TITLE = "title";       // Title
            public const string AUTHOR = "author"; // Author
            public const string DATETIME = "datetime";     // Date/Time

        }
        // ChannelGroup property constants
        public static class ChannelGroupProperties {
            public const string NAME = "name";     // Name
            public const string DESCRIPTION = "description";   // Description

        }
        // Channel property constants
        public static class ChannelProperties {
            public const string NAME = "name";      // Name
            public const string DESCRIPTION = "description";    // Description
            public const string UNIT_STRING = "unit_string";    // Unit String
            public const string MINIMUM = "minimum";   // Minimum
            public const string MAXIMUM = "maximum";    // Maximum
        }
    }
}
