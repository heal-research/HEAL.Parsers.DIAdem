Instructions for National Instruments TDM DLL

The TDM DLL enables applications to read and write TDM (.tdm) 
and TDM Streaming (.tdms) files. The TDM and TDM Streaming file formats are 
supported by multiple National Instruments products, such as DIAdem.

See license.rtf for licensing terms and restrictions.

***************************************
*****  Development Instructions   *****
***************************************

The 'dev' directory contains the header file, import libraries, and binaries
to be used during development.  

Modify your compiler project or makefile settings to locate the header file 
and import library.

Import libraries are included in Microsoft 32-bit and 64-bit formats.

The 'dev\bin' directory contains separate sub-directories with the runtime components 
required for 32-bit and 64-bit applications. For the purpose of development testing, 
you should copy the contents of this directory into the same directory as your executable 
or DLL that uses this library.

Note that the runtime components for this library require the Microsoft Visual C++ 2015
runtime components to be installed.
You must install 32-bit (x86) or 64-bit (x64) versions of the Microsoft Visual C++ 2015
runtime components depending on whether you are using this library in a 32-bit or 64-bit 
application. You can download the Microsoft Visual C++ 2015 Redistributable Package 
from the Microsoft web site.

The 'doc' directory includes a help file for the library.

The 'samples' directory contains sample programs.

***************************************
***** Redistribution Instructions *****
***************************************

The 'redist' directory contains 32-bit and 64-bit merge modules that include the 
runtime components required by the 32-bit and 64-bit versions of this library.

The 'niusiemb.msm' and 'niusiemb_x64.msm' merge modules contains all files in 
'dev\bin\32-bit' and 'dev\bin\64-bit', respectively, except for nilibddc.dll. The 
'nilibddc.msm' and 'nilibddc_x64.msm' merge modules contain only the 32-bit and 64-bit 
versions nilibddc.dll, respectively.

Your installed application will require the Microsoft Visual C++ 2015 runtime components.
The 'Microsoft_VC140_CRT_x86.msm' merge module will install the required components for 
32-bit applications. The 'Microsoft_VC140_CRT_x64.msm' merge module will install the required 
components for 64-bit applications.

The files in the included 'nilibddc[_x64]' and 'niusiemb[_x64].msm' merge modules need 
to be installed in the same directory as your executable or DLL that uses this library. 
It is highly recommended that this directory be specific to your application and not a 
shared system location like the Windows System directory. 

By default, the supplied 'nilibddc[_x64]' and 'niusiemb[_x64].msm' merge modules 
install their files to the directory specified by the INSTALLDIR installer property. 
Some installer authoring tools, including Wise for Windows Installer, set the INSTALLDIR 
property to the application directory selected by the user at install time. Other 
installer authoring tools do not use the INSTALLDIR property. For example, Microsoft 
Visual Studio uses the TARGETDIR property to store the application directory selected 
by the user at install time. If your installation directory for the files in the merge 
modules is specified by an installer property other than INSTALLDIR, then you must change 
the "Installation Directory" property of the merge modules to refer to the correct 
property name. See the documentation for your installer authoring tool for details.

These merge modules have been tested with Wise for Windows and Microsoft Visual Studio.

***************************************
*****       Version History       *****
***************************************
17.0 - Updated niusiemb[_x64] merge module, containing Xerces XML parser 3.1.4,
       and updated to Microsoft Visual C++ 2015 runtime components.
13.0 - Bug fixes, removed Borland format import libraries, and updated to Microsoft Visual 
       C++ 2010 SP1 runtime components.
 9.1 - Added TDM Streaming (.tdms) 2.0 file format support, 64-bit application support, 
       and additional type-safe functions for applications not written in C/C++.
 8.6 - Added support for reading and writing Timestamp values and properties.
 8.1 - Added support for reading and writing TDM Streaming (.tdms) file format.
     - Added functions to retrieve property names and property types from a file, 
       channelgroup, or channel.
 8.0 - First release.

© 2017 National Instruments Corporation. All rights reserved.