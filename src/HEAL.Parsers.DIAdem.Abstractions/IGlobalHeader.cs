using System;

namespace HEAL.Parsers.DIAdem.Abstractions {
  public interface IGlobalHeader {
    string Name { get; }
    string Description { get;  }
    string Title { get;  }
    string Author { get;  }
    DateTime? TimeStamp { get;  }
  }
}
