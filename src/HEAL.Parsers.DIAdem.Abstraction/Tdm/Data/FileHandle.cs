using System;
using System.Collections.Generic;
using System.Text;
using HEAL.Parsers.DIAdem.Tdm.Abstractions;

namespace HEAL.Parsers.DIAdem.Tdm {
    public class FileHandle : Handle {
        public FileHandle(Int64 ptr)
            : base(ptr) { }
        public override TDMHandleTypes HandleType => TDMHandleTypes.FileHandle;
    }
}
