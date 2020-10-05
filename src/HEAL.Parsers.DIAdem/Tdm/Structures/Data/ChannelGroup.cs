using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm.Structures
{
    public class ChannelGroup : Handle
    {
        public ChannelGroup(Int64 ptr)
            : base(ptr) { }
        public override TDMHandleTypes HandleType => TDMHandleTypes.ChannelGroup;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
