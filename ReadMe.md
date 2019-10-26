# ![Draft logo](MichaelChecksum.png) Michael Checksum

[![](https://img.shields.io/badge/NuGet-MichaelChecksum.Console-blue)]( https://www.nuget.org/packages/MichaelChecksum.Console/ ) [![Build status](https://ci.appveyor.com/api/projects/status/5v2fgluxnswctuxl?svg=true)](https://ci.appveyor.com/project/Atrejoe/michaelchecksum)

This pun-based tool allows you to calculate checksums. You can either use the online service at: [michaelchecksum.com](http://www.michaelchecksum.com) or the console version.

[TOC]
## Web API

This web service allows you to externally assert that the file served has the documented checksum, showing an nice badge as a seal of approval (which you can embed anywhere with an Internet connection).

> For the extra paranoid: this does not assert 100% that when *you* download the same file, it will arrive on *your* machine with the correct checksum. (it may be altered or corrupted on the way to your machine).
>
> Use the console application for that purpose.

## Console

A cross-platform (Linux, Mac & Windows) console application without file size restrictions can be installed from NuGet:

global:

```dotnet tool install -g michaelchecksum.console```

or local:

```dotnet tool install --tool-path . michaelchecksum.console```

### Prerequisite

- [dotnet runtime](https://dotnet.microsoft.com/download)

>Also see the releases section for when you do not have .Net Core installed.
