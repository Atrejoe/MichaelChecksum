using MichaelChecksum.Core;
using System.IO;
using System.Linq;
using static System.Console;

namespace MichaelChecksum.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!(args?.Any()).GetValueOrDefault())
                Error.WriteLine(Resources.Input_Validation_Missing_File_name);
            else
            {
                var fi = new FileInfo(args[0]);
                if (!fi.Exists)
                    Error.WriteLine(Resources.Input_Validation_File_does_not_exists, fi.FullName);
                else
                {
                    WriteLine(Resources.Calculating_Hash, fi.FullName);
                    WriteLine(Resources.Hash_Result_SHA1Mone, Hashing.GetHash(fi));
                    WriteLine(Resources.CallToAction_Visit_Website);
                }
            }
        }
    }
}
