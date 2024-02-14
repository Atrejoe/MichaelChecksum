
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "This is a play on words, referring to abbreviation SHA1", Scope = "type", Target = "~T:MichaelChecksum.SHA1moneController")]
[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "This is a play on words, referring to abbreviation SHA1", Scope = "type", Target = "~T:MichaelChecksum.SHA1moneController")]
[assembly: SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "GitHub repo not configurable for now", Scope = "member", Target = "~M:MichaelChecksum.Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
