# HEAL.Parsers.DIAdem


## How to use the nuget package in your project
National Instruments does not permit hosting the TDM C DLL library directly. This also prohibits packaging the library directly into the nuget package. You are therefore required to manually download the library including the NI license agreements and place it alongside your executable in order for this package to function.

Download the National Instruments TDM C DLL library [here](https://www.ni.com/content/dam/web/product-documentation/c_dll_tdm.zip) and place the contents of the 64-bit folder alongside your executing assembly.

*The NILIBDDC library and associated files are subject to National Instrument's licensing.* Carefully read the NILIBDDC license also included in `/src/HEAL.Parsers.DIAdem/license.rtf` and NILIBDDC README at `/src/HEAL.Parsers.DIAdem/README.txt` to ensure that you are compliant with their restrictions. Alternatively these files can also be found in the in the TDM C DLL library download. 

*DIAdem is a trademark of National Instruments. Neither [HEAL](https://heal.heuristiclab.com/), nor any software programs or other goods or services offered by HEAL, are affiliated with, endorsed by, or sponsored by National Instruments.*

## TDM / TDMS 
The TDM and TDMS files consist of a metadata file (*.tdm, *.tdms) and an associated data file (*.tdx). National Instruments published a [whitepaper](http://www.ni.com/white-paper/3727/en/#toc4) on the TDM and TDMS format. Contrary to the DAT file format the TDM and TDMS files cannot be read without the use of an external library.

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
Real64 values are stored in .R64 files whereas Real32 Values are stored in .R32 files, etc.. More about the header structure and the storage of data can be read in the [specification of the .DAT structure](http://digital.ni.com/public.nsf/allkb/7c72161d9b13ef1086256ce8007f570b/$FILE/dmheader.pdf) made available by National Instruments.

### Parsing DAT Files

To parse a .dat file and its data, start by parsing all channels of the metadata (*.dat) file. This channel metadata contains locations of the binary files, data type and size, and binary stream position and length. 

Parsing the data files in C# can be achieved by utilizing `System.IO BinaryReader`.
```csharp
using (var binReader = new BinaryReader(new FileStream("datafile.r32", FileMode.Open))) {
  binReader.BaseStream.Position = 4 * (channel.PtrFirstChannelValue - 1);
  binReader.ReadSingle();
}
```