# HEAL.Parsers.DIAdem
HEAL.Parsers.DIAdem provides managed C# access to the proprietary DIAdem data format. It implements C# wrapper methods for the NILIBDDC TDM C DLL, as provided by [National Instruments](https://www.ni.com/). 

## DIAdem
DIAdem is a trademark of National Instruments. Neither [HEAL](https://heal.heuristiclab.com/), nor any software programs or other goods or services offered by [HEAL](https://heal.heuristiclab.com/), are affiliated with, endorsed by, or sponsored by National Instruments.

## Table of Contents
1. [Getting Started](#getting-started)

1. [Features and Usage](#features-and-usage)

1. [License](#license)

# Getting Started

## Installation
The nuget package does not contain the TDM C DLL provided by National Instruments. Therefore **both** of the following steps are necessary for usage. 

### Install the Nuget Package
All release packages of this solution can be found on the public nuget.org feed.

Additionally, we provide a public nuget build feed where you can get the latest release candidate or feature builds from our CI platform see the [development instructions](docs/development.md).

To use the package include the following feed URL in visual studio 
```
https://pkgs.dev.azure.com/heal-research/HEAL.Parsers.DIAdem/_packaging/HEAL.Parsers.DIAdem/nuget/v3/index.json
```
or add a nuget.config file to your project, in the same folder as your .csproj or .sln file with the following content
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />

    <add key="HEAL.Parsers.DIAdem" value="https://pkgs.dev.azure.com/heal-research/HEAL.Parsers.DIAdem/_packaging/HEAL.Parsers.DIAdem/nuget/v3/index.json" />

  </packageSources>
</configuration>
```

### Copy NILIBDDC TDM C DLL
Download the National Instruments TDM C DLL library as described in the [National Instruments TDMS File Format white paper](http://www.ni.com/white-paper/3727/en/#toc4) and place the contents of `TDM C DLL\dev\bin\64-bit` in your executable directory. 

## Build Locally

Prerequisites and build instructions can be found in the [development instructions](docs/development.md).

# Features and Usage
Visit the [detailed documentation](docs/HEAL.Domain.DataAccess.DIAdem.md) for more information on usage of the package and on National Instrument's licenses. The access library currently requires a **64bit environment** to work.

*DAT Access*
```C#
using (var parser = new DATReader(@"path_to.dat")) {
  // global header including: title, author, etc.
  GlobalHeader header = parser.GetGlobalHeader() as GlobalHeader;

  // channel header: channel-name, data-file location, datatype, min, max
  IEnumerable<ChannelHeader> headers = parser.GetChannelHeaders().Cast<ChannelHeader>();

  // parses the actual channel data
  double[] data = parser.GetChannelData<double>(headers.First()).ToArray();
}
```

*TDM Access*
```C#
using (var parser = new TDMReader(@"path_to.tdm")) {
  // global file including: title, author, etc.
  var header = parser.GetGlobalHeader() as FileProperties;
  
  var groups = parser.GetChannelGroups();

  var channels = new List<Channel>();
  foreach (var group in groups) {
    channels.AddRange(parser.GetChannels(group));
  }

  double[] data = parser.GetChannelData<double>(channels.First()).ToArray();
}
```
# License 
*DIAdem is a trademark of National Instruments. Neither [HEAL](https://heal.heuristiclab.com/), nor any software programs or other goods or services offered by HEAL, are affiliated with, endorsed by, or sponsored by National Instruments.*

The project HEAL.Parsers.DIAdem is [licensed](LICENSE.txt) under the MIT License.

```
MIT License

Copyright (c) 2017-present Heuristic and Evolutionary Algorithms Laboratory

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
