using System;
using System.Globalization;
using HEAL.Parsers.DIAdem.Abstractions;

namespace HEAL.Parsers.DIAdem.Dat.Abstractions {

  public class GlobalHeader : IDATHeader, IGlobalHeader {
    public string OriginOfDataSet { get; set; }
    public string RevisionNumber { get; set; }
    public string DataSetDescription { get; set; }
    public string DataSetComments { get; set; }
    public string DataSetProcessor { get; set; }
    public DateTime? TimeStamp {
      get {
        if (DateTime.TryParseExact($"{Date} {Time}", NetTimeFormat, new CultureInfo("en-EN"), DateTimeStyles.None, out DateTime result))
          return result;
        return null;
      }
    }
    public string DataSetCommentsDescription { get; set; }
    public string NetTimeFormat => TimeFormat.Replace("#", "").Replace('m', 'M').Replace('n', 'm');
    public string NoValueValue { get; set; }
    public string InterchangeHighAndLowBytes { get; set; }
    public string Reserve1 { get; set; }
    public string Reserve2 { get; set; }
    public string Reserve3 { get; set; }
    public string Reserve4 { get; set; }

    #region helper properties - used by parser but not accessible externally
    public string Date { get; set; }
    public string Time { get; set; }
    public string TimeFormat { get; set; }
    #endregion

    public string Name => DataSetDescription;
    public string Description => DataSetComments;
    public string Title => default;
    public string Author => default;
  }
}
