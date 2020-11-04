using System;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  public class TargetAttributeAttribute : Attribute {
    public TargetAttributeAttribute(string attributeName) {
      AttributeName = attributeName;
    }

    public string AttributeName { get; private set; }
  }
}
