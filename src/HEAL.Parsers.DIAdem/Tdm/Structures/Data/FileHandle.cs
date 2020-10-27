using System;
using System.Collections.Generic;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public class FileHandle : Handle {
        public FileHandle(Int64 ptr)
            : base(ptr) { }
        public override TDMHandleTypes HandleType => TDMHandleTypes.FileHandle;
    }
}
