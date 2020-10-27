using System;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public class DDCException : Exception {
        
        public DDCException(int errorCode, string message)
            : base($"{errorCode}: {message}") {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
}
