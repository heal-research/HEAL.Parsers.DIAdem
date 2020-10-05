using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HEAL.Parsers.DIAdem.Tdm.Structures
{
    public class FileProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Time { get; set; }
    }
}
