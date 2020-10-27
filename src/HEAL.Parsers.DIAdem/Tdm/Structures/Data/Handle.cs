using System;
using System.Collections.Generic;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm.Structures {
    public class Handle {
        public Handle(Int64 ptr) {
            Ptr = ptr;
        }
        public Int64 Ptr { get; protected set; }
        public virtual TDMHandleTypes HandleType => TDMHandleTypes.AnyRef;
        /// <summary>
        /// TDM allows additional properties apart from the ones reserved by the different handle types
        /// <see cref="Constants"/> for the different defined properties/their names as per nilibddc.h
        /// </summary>
        public Dictionary<string, object> AdditionalValues { get; set; } = new Dictionary<string, object>();
    }
}
