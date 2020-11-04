using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using HEAL.Parsers.DIAdem.Abstractions;

namespace HEAL.Parsers.DIAdem.Tdm {
  public class FileProperties : IGlobalHeader {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime? Time { get; set; }

    public DateTime? TimeStamp => Time;
  }
}
