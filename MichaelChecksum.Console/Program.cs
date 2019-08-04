//using MichaelChecksum.Core;
using System.IO;
using System.Linq;
using static System.Console;

namespace MichaelChecksum.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (!(args?.Any()).GetValueOrDefault())
            //    Error.WriteLine($"Please specify a file to check");
            //else if (!File.Exists(args[0]))
            //    Error.WriteLine($"File '{args[0]}' does not exist");
            //else
            //    WriteLine($"SHA1Mone!:{Hashing.GetHash(new FileInfo(args[0]))}");
            WriteLine($"Echo : {string.Join(",", args)}");
        }
    }
}
