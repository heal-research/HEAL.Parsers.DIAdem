using System;
using System.Collections.Generic;
using System.Text;

namespace HEAL.Parsers.DIAdem.Dat.Structures.Data {
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  public class TargetAttributeAttribute : Attribute {
    public TargetAttributeAttribute(string attributeName) {
      AttributeName = attributeName;
    }

    public string AttributeName { get; private set; }
  }
}
