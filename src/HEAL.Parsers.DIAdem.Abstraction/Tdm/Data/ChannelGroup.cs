using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HEAL.Parsers.DIAdem.Tdm.Abstractions;

namespace HEAL.Parsers.DIAdem.Tdm {
    public class ChannelGroup : Handle {
        public ChannelGroup(Int64 ptr)
            : base(ptr) { }
        public override TDMHandleTypes HandleType => TDMHandleTypes.ChannelGroup;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
