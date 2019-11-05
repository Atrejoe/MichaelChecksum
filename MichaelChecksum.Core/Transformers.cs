using System.Globalization;
using System.Text;

namespace MichaelChecksum.Core
{
    internal static class Transformers {
        public static string ConvertToString(this byte[] hash) {
            var sb = new StringBuilder();
            foreach (var @byte in hash)
                sb.Append(@byte.ToString("X2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
