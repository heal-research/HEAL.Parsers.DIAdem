using HEAL.Parsers.DIAdem.Dat.Structures;
using HEAL.Parsers.DIAdem.Dat.Structures.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace HEAL.Parsers.DIAdem.Dat {
  internal static class DATContentParser {
    /// <summary>
    /// Parses one line and invokes the correct property setter of <see cref="GlobalHeader"/> to pass the parsed value
    /// line is assumed to fit '<int>,<value>' as specified by national instruments DAT documentation
    /// e.g. '101,Reading an ASCII channel file' or '110,#dd.mm.yyyy hh:nn:ss'
    /// A line is ignored if the value cannot be parsed as expected (e.g. wrong format or no available enum values)
    /// </summary>
    /// <param name="header">the header-instance where the value of the parsed line should be applied</param>
    /// <param name="line">the line to be parsed</param>
    internal static void ParseLine<HeaderT, EnumT>(this HeaderT header, string line)
                          where EnumT : IComparable, IConvertible, IFormattable
                          where HeaderT : IDATHeader {

      if (!typeof(EnumT).IsEnum) {
        throw new ArgumentException($"{nameof(EnumT)} must be an enum type");
      }

      string[] data = line.Split(new char[] { ',' }, 2); //splits the line only on the first ',' since length of array is limited to 2
      if (!data.Any() && data.Count() != 2)
        return;

      int headerId;
      if (!int.TryParse(data[0], out headerId))
        return;

      var identification = (EnumT)Enum.ToObject(typeof(EnumT), headerId); ;
      if (!Enum.IsDefined(typeof(EnumT), identification)) //cast int to enum is always possible, but value might not be in range
        return;

      //TargetAttributeAttribute is defined to be 'Multiple=false' therefore Single is used
      var attibute = typeof(EnumT).GetMember(identification.ToString()).First()
                        .GetCustomAttributes(typeof(TargetAttributeAttribute))
                        .Select(x => (TargetAttributeAttribute)x).SingleOrDefault();

      if (attibute == null)
        return;

      var propertyInfo = typeof(HeaderT).GetProperty(attibute.AttributeName);

      if (propertyInfo.PropertyType.IsEnum) {
        //if property is enum we have to parse it differently from all other IConvertibles
        propertyInfo.SetValue(header, Enum.Parse(propertyInfo.PropertyType, data[1]));
      } else if (propertyInfo.PropertyType.GetInterfaces().Contains(typeof(IConvertible))) {
        //data[1] contains string representation of whatever type of data is expected by PropertyType
        // it is however certain that the target property implements IConvertible -> we can try to convert it
        propertyInfo.SetValue(header, Convert.ChangeType(data[1], propertyInfo.PropertyType, CultureInfo.InvariantCulture), null);
      }
    }
  }
}
