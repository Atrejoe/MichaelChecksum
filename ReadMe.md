# ![Draft logo](MichaelChecksum.png) Michael Checksum

[![](https://img.shields.io/badge/NuGet-MichaelChecksum.Console-blue)]( https://www.nuget.org/packages/MichaelChecksum.Console/ )[![Build status](https://ci.appveyor.com/api/projects/status/5v2fgluxnswctuxl?svg=true)](https://ci.appveyor.com/project/Atrejoe/michaelchecksum)

[TOC]
## Web API

You can either use the online service at: [michaelchecksum.com](http://www.michaelchecksum.com).

This service allows you to externally assert that the file served has the documented checksum, showing an nice badge as a seal of approval.

> For the extra paranoid: this does not assert 100% that when *you* download the same file, it will arrive on *your* machine with the correct checksum. (it may be altered or corrupted on the way to your machine).
>
> Use the console application for that purpose.

## Console

A cross-platform console application without file size restrictions can be installed from NuGet:

global:

```dotnet tool install -g michaelchecksum.console```

or local:

```dotnet tool install --tool-path . michaelchecksum.console```

### Prerequisite

- [dotnet runtime](https://dotnet.microsoft.com/download)
