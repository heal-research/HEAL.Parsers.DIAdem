# HEAL.Domain.DataAccess.DIAdem

## Common/expected Errors
`Could not find NiLibDdc library zip with name NILIBDDC-64bit.zip in application directory. Expected location '...\bin\NILIBDDC-64bit.zip'`

Read the [usage instruction](#how-to-use-the-nuget-package-in-your-project)

## How to use the nuget package in your project


Download the National Instruments TDM C DLL as library [download](https://www.ni.com/content/dam/web/product-documentation/c_dll_tdm.zip). Package the `64-bit` folder as zip and rename it to `NILIBDDC-64bit.zip` **place this zip into the folder of your executing assembly**.

![Install NILIBDDC](img/InstallNILIBDDC.gif)

Beware that National Instruments provides only a very strict license for this library but were so kind to allow this wrapper library. Beware however that public hosting of this library is not permitted/wanted which is why this project only links their download address.

National Instruments published a [whitepaper](http://www.ni.com/white-paper/3727/en/#toc4) on the TDM and TDMS format and offer the TDM C DLL as library [download](https://www.ni.com/content/dam/web/product-documentation/c_dll_tdm.zip). *The NILIBDDC library and associated files are subject to National Instrument's licensing*. Carefully read the [NILIBDDC license](src\HEAL.Domain.DataAccess.DIAdem\license.rtf) and [NILIBDDC README](src\HEAL.Domain.DataAccess.DIAdem\README.txt) to ensure that you are compliant with their restrictions.

## DAT
The DAT DIAdem file format consists of the .dat header files containing a list of channels. The channel information is separated by the strings `#BEGINCHANNELHEADER` and `#ENDCHANNELHEADER`.

### Structure
```
...
#BEGINCHANNELHEADER
200,ChannelName
201,
202,[]
210,EXPLICIT
211,DataFile.R64
213,CHANNEL
214,REAL64
...
#ENDCHANNELHEADER
...
```
Real64 values are stored in .R64 files whereas Real32 Values are stored in .R32 files, etc.. More about the header structure and the storage of data can be read in the [specification of the .DAT structure](http://digital.ni.com/public.nsf/allkb/7c72161d9b13ef1086256ce8007f570b/$FILE/dmheader.pdf) made available by national instruments.

## Parsing
To parse a .dat file and it's data start by parsing all channels of the .dat file. From the information of the channels you can find out the location of the data files and which data type/size they store. 

Parsing the data files in C# can be achieved by utilizing System.IO BinaryReader.
```csharp
using (var binReader = new BinaryReader(new FileStream("datafile.r32", FileMode.Open)))
{
  binReader.BaseStream.Position = 4 * (channel.PtrFirstChannelValue - 1);
  binReader.ReadSingle();
}
```

## Parser Implementation
It provides different methods for parsing the contents of the *.DAT header and its linked binary files:
*DAT Access*
```C#
using(var datreader = new DATReader(@"path_to.dat")){
  //global header including: title, author, etc.
  GlobalHeader header = parser.GetGlobalHeader();

  //channel header: channel-name, data-file location, datatype, min, max
  IEnumerable<ChannelHeader> headers = parser.GetChannelHeaders();

  //parses the actual channel data
  double[] data = parser.GetChannelData<double>(headers.First()).ToArray();
}
```

*TDM Access*
```C#
using(var datreader =  new TDMReader(@"path_to.tdm")){
  //global file including: title, author, etc.
  FileProperties header =  parser.GetFileProperties();
  var groups = parser.GetChannelGroups();

  var channels = new List<Channel>();
  foreach(var group in groups) {
    channels.AddRange(parser.GetChannels(group));
  }

  double[] data = parser.GetChannelData<double>(channels.First()).ToArray();
}
```