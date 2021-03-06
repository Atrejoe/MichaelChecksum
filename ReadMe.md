# ![Draft logo](MichaelChecksum.png) Michael Checksum

[![Nuget](https://img.shields.io/nuget/dt/michaelchecksum.console?color=blue&label=NuGet&logo=nuget)]( https://www.nuget.org/packages/MichaelChecksum.Console/ ) [![Build status](https://ci.appveyor.com/api/projects/status/5v2fgluxnswctuxl?svg=true)](https://ci.appveyor.com/project/Atrejoe/michaelchecksum) [![GitHub Releases](https://img.shields.io/github/downloads/atrejoe/michaelchecksum/latest/total?logo=github)](https://github.com/Atrejoe/MichaelChecksum/releases/latest)

This pun-based tool allows you to calculate checksums. You can either use the online service at: [michaelchecksum.com](https://michaelchecksum.com) or the console version.
<!--

[TOC]
-->
## Web API

This web service allows you to externally assert that the file served has the documented checksum, showing an nice badge as a seal of approval (which you can embed anywhere with an Internet connection).
<!--
```mermaid
%% Basic flow 
sequenceDiagram
participant v as Visitor
participant w as Website
participant m as Michael Checksum

v->>w : Visits `Download` page
w->>v : Here is the download link, let Michael Checksum verify that hash for you!
v->>m : Can you check this file for me?
m->>w : Can you give me this file?
w->>m : Returns file
Note over m:Calculates hash<br/> for the file
m->>v : This is the hash for your url, SHA1mone!
Note over v:Shows image that<br/>hash is as<br/>expected, user<br/>can proceed with<br/>the download.
```
-->

> For the extra paranoid: this does not assert 100% that when *you* download the same file, it will arrive on *your* machine with the correct checksum. (it may be altered or corrupted on the way to your machine).
>
> Use the console application for that purpose.

## Console

A cross-platform (Linux, Mac & Windows) console application without file size restrictions can be installed from NuGet:

global:

```dotnet tool install -g michaelchecksum.console```

or local:

```dotnet tool install --tool-path . michaelchecksum.console```

> For upgrading replace `install` with `update`

### Usage

Calculate a SHA-1 hash using:

```bash
michaelchecksum myfile.txt         # relative file
michaelchecksum c:\myfile.txt      # file on a drive (Windows)
michaelchecksum /path/myfile.txt   # file on a drive (Linux/Mac)
michaelchecksum https://myfile.txt # file via url
```

### Prerequisite

- [dotnet runtime](https://dotnet.microsoft.com/download)

>Also see the [releases section](https://github.com/Atrejoe/MichaelChecksum/releases/latest) for when you do not have .Net Core installed.