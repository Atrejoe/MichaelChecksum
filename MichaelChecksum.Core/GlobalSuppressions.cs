
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

// SHA-1 is the intended, advertised purpose of this tool ("SHA1mone" - a
// non-security content fingerprint / checksum). It is never used in a
// security-sensitive context such as password storage, digital signatures or
// tamper detection, so its collision weaknesses do not apply here. These
// suppressions mirror the CA5350 suppressions above for the SonarAnalyzer
// weak-hash rules (S2070 / S4790) surfaced by the analyzer upgrade.
[assembly: SuppressMessage("Vulnerability", "S2070:SHA-1 and Message-Digest hash algorithms should not be used in secure contexts", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.String,System.Text.Encoding)~System.String")]
[assembly: SuppressMessage("Vulnerability", "S2070:SHA-1 and Message-Digest hash algorithms should not be used in secure contexts", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo)~System.String")]
[assembly: SuppressMessage("Vulnerability", "S2070:SHA-1 and Message-Digest hash algorithms should not be used in secure contexts", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHashAsync(System.Uri,System.UInt32)~System.Threading.Tasks.Task{System.String}")]

[assembly: SuppressMessage("Security Hotspot", "S4790:Using weak hashing algorithms is security-sensitive", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.String,System.Text.Encoding)~System.String")]
[assembly: SuppressMessage("Security Hotspot", "S4790:Using weak hashing algorithms is security-sensitive", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo)~System.String")]
[assembly: SuppressMessage("Security Hotspot", "S4790:Using weak hashing algorithms is security-sensitive", Justification = "SHA-1 is this tool's advertised purpose (non-security content fingerprint); not used in any security-sensitive context.", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHashAsync(System.Uri,System.UInt32)~System.Threading.Tasks.Task{System.String}")]

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:MichaelChecksum.Core.FileTooLargeException.#ctor")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:MichaelChecksum.Core.Hashing.GetHash(System.IO.FileInfo,System.Security.Cryptography.HashAlgorithm)~System.String")]

