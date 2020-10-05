using System;
using System.Collections.Generic;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm.Structures
{
    public class DDCException : Exception
    {
        
        public DDCException(int errorCode, string message)
            : base($"{errorCode}: {message}")
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
}
