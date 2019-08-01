using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
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

    /// <summary>
    /// Central class for hashing
    /// </summary>
    public static class Hashing
    {
        #region SHA1
        /// <summary>
        /// <see cref="SHA1"/> overload for <see cref="GetHash(string, HashAlgorithm, Encoding)"/>.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetHash(string input, Encoding encoding = null)
        {
            using (var sha1 = SHA1.Create())
                return GetHash(input, sha1, encoding);
        }

        /// <summary>
        /// <see cref="SHA1"/> overload for <see cref="GetHash(Uri, HashAlgorithm)"/>.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetHash(Uri address)
        {
            using (var sha1 = SHA1.Create())
                return GetHash(address, sha1);
        }

        #endregion

        /// <summary>
        /// Calculates <see cref="SHA1"/> hash of <paramref name="input"/>.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="algorithm"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetHash(string input, HashAlgorithm algorithm, Encoding encoding = null)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));

            var bytes = (encoding ?? Encoding.UTF8).GetBytes(input);
            var hash = bytes.GetHash(algorithm);
            return hash;
        }

        /// <summary>
        /// Calculates string representation of <see cref="SHA1"/> hash of <paramref name="bytes"/>.
        /// </summary>
        /// <param name="bytes">The bytes to calculate the hash for.</param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static string GetHash(this byte[] bytes, HashAlgorithm algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));

            var hash = algorithm.ComputeHash(bytes);

            return hash.ConvertToString(); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static string GetHash(Uri address, HashAlgorithm algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));

            byte[] hash;
            using(var wc = new WebClient())
            using (var stream = new MemoryStream(wc.DownloadData(address)))
                hash = algorithm.ComputeHash(stream);
            
            return hash.ConvertToString();
        }
    }
}
