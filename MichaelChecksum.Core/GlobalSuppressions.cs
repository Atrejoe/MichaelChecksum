
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "SHA1 is a common hash verification method (and a nice pun)", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.String,System.Text.Encoding)~System.String")]
[assembly: SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "SHA1 is a common hash verification method (and a nice pun)", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo)~System.String")]

[assembly: SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "SHA1 is a common hash verification method (and a nice pun)", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.String,System.Text.Encoding)~System.String")]
[assembly: SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "SHA1 is a common hash verification method (and a nice pun)", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo)~System.String")]
[assembly: SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "SHA1 is a common hash verification method (and a nice pun)", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHashAsync(System.Uri,System.UInt32)~System.Threading.Tasks.Task{System.String}")]

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:MichaelChecksum.Core.FileTooLargeException.#ctor")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo,System.Security.Cryptography.HashAlgorithm)~System.String")]

