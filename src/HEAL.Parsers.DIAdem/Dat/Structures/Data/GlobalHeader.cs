using System;
using System.Globalization;


namespace HEAL.Parsers.DIAdem.Dat.Structures {

  public class GlobalHeader : IDATHeader {
    public string OriginOfDataSet { get; set; }
    public string RevisionNumber { get; set; }
    public string DataSetDescription { get; set; }
    public string DataSetComments { get; set; }
    public string DataSetProcessor { get; set; }
    public DateTime TimeStamp => DateTime.ParseExact($"{Date} {Time}", NetTimeFormat, new CultureInfo("en-EN"));
    public string DataSetCommentsDescription { get; set; }
    public string NetTimeFormat => TimeFormat.Replace("#","").Replace('m', 'M').Replace('n', 'm');
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
  }
}
