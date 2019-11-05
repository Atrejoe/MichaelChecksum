using MichaelChecksum.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace MichaelChecksum.Console
{

    static class Program
    {
        /// <summary>
        /// See <see cref="ExitCode"/> for possible responses.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static async Task<int> Main(string[] args)
        {
            if (!(args?.Any()).GetValueOrDefault())
            {
                Error.WriteLine(Resources.Input_Validation_Missing_File_name);
                return (int)ExitCode.FileNotSpecified;
            }

            else if (Uri.TryCreate(args[0], UriKind.Absolute, out var url))
            {
                //File via file web
                WriteLine(Resources.Calculating_Hash, url);
                try
                {
                    WriteLine(Resources.Hash_Result_SHA1Mone, await Hashing.GetHashAsync(url).ConfigureAwait(false));
                }
                catch (FileReadException ex)
                {
                    WriteLine(Resources.FailedToReadFile, ex.Message);
                    return (int)ExitCode.FileNotFound;
                }
            }
            else
            {
                //File via file system?
                FileInfo fi;
                try
                {
                    fi = new FileInfo(args[0]);
                }
                catch (UnauthorizedAccessException) {
                    return (int)ExitCode.AccessDenied;
                }
                catch (PathTooLongException)
                {
                    return (int)ExitCode.FilePathInvalidFormat;
                }
                catch (NotSupportedException)
                {
                    return (int)ExitCode.FilePathInvalidFormat;
                }

                if (!fi.Exists)
                {
                    Error.WriteLine(Resources.Input_Validation_File_does_not_exists, fi.FullName);
                    return (int)ExitCode.FileNotFound;
                }
                else
                {
                    WriteLine(Resources.Calculating_Hash, fi.FullName);
                    WriteLine(Resources.Hash_Result_SHA1Mone, Hashing.GetHash(fi));
                }
            }

            WriteLine(Resources.CallToAction_Visit_Website);
            return (int)ExitCode.Success;
        }
    }
}
