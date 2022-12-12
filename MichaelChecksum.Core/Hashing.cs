using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MichaelChecksum.Core
{

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
		/// <see cref="SHA1"/> overload for <see cref="GetHashAsync(Uri, HashAlgorithm, uint)"/>.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		/// <exception cref="FileTooLargeException">When <paramref name="address"/> refers to a file exceeding <paramref name="maxLength"/>.</exception>
		/// <exception cref="FileReadException">Obtaining the failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
		public static async Task<string> GetHashAsync(Uri address, uint maxLength = 0)
		{
			using (var sha1 = SHA1.Create())
				return await GetHashAsync(address, sha1, maxLength).ConfigureAwait(false);
		}

		/// <summary>
		/// <see cref="SHA1"/> overload for <see cref="GetHash(FileInfo, HashAlgorithm)"/>.
		/// </summary>
		/// <param name="file">File</param>
		/// <returns></returns>
		public static string GetHash(FileInfo file)
		{
			using (var sha1 = SHA1.Create())
				return GetHash(file, sha1);
		}

		#endregion

		/// <summary>
		/// Calculates <see cref="SHA1"/> hash of <paramref name="input"/>.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="algorithm"></param>
		/// <param name="encoding"></param>
		/// <returns>The calculated has for the specified <paramref name="input"/>.</returns>
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

		private static readonly HttpClient client = new HttpClient();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="algorithm"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		/// <exception cref="FileTooLargeException">When <paramref name="address"/> refers to a file exceeding <paramref name="maxLength"/>.</exception>
		/// <exception cref="FileReadException">Obtaining the failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
		/// <exception cref="FileNotFoundException">The file was reported not to exist.</exception>
		public static async Task<string> GetHashAsync(Uri address, HashAlgorithm algorithm, uint maxLength = 0)
		{
			if (algorithm == null)
				throw new ArgumentNullException(nameof(algorithm));

			byte[] hash;
			//using (var wc = new WebClient())
			//{

			//    bool downloadCancelledDuetoSize = false;
			//    long fileSize = 0;

			//    using (var tokenSource = new CancellationTokenSource())
			//    {

			//        wc.DownloadProgressChanged += (sender, args) =>
			//        {
			//            if (maxLength > 0
			//                && (
			//                   args.TotalBytesToReceive > maxLength
			//                || args.BytesReceived > maxLength
			//                ))
			//            {
			//                downloadCancelledDuetoSize = true;
			//                fileSize = args.TotalBytesToReceive;

			//                wc.CancelAsync();
			//            }
			//        };

			//        try
			//        {
			//            byte[] buffer = await wc.DownloadDataTaskAsync(address).ConfigureAwait(false);
			//            using (var stream = new MemoryStream(buffer))
			//                hash = algorithm.ComputeHash(stream);
			//        }
			//        catch (TaskCanceledException ex) when (downloadCancelledDuetoSize)
			//        {
			//            throw new FileTooLargeException(
			//                message: $"File is {fileSize:n0} bytes, exceeding the limit of {maxLength:n0}.",
			//                paramName: nameof(address),
			//                innerException: ex);
			//        }
			//    }
			//}

			try
			{
				using (HttpResponseMessage response = await client.GetAsync(address, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
				{
					CheckResponse(address, response, maxLength);

					using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
					{
						CheckResponse(address, response, maxLength);
						hash = algorithm.ComputeHash(stream);
					}

				}
			}
			catch (HttpRequestException ex)
			{
				throw new FileReadException($"Failed to read file : {ex.Message}", ex);
			}

			return hash.ConvertToString();
		}

		private static void CheckResponse(Uri address, HttpResponseMessage response, uint maxLength)
		{
			if (maxLength > 0 && response.Content.Headers.ContentLength.GetValueOrDefault() > maxLength)
				throw new FileTooLargeException(
						message: $"File is {response.Content.Headers.ContentLength.GetValueOrDefault():n0} bytes, exceeding the limit of {maxLength:n0}.",
						paramName: nameof(address));

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return;
				case HttpStatusCode.NotFound:
					throw new FileNotFoundException($"File does not exist {response.ReasonPhrase}");
				default:
					throw new FileReadException($"Server responsed {response.StatusCode} ({response.ReasonPhrase})");
			}
		}

		/// <summary>
		/// Calculated the hash for the specified file.
		/// </summary>
		/// <param name="file">The file to read</param>
		/// <param name="algorithm"></param>
		/// <returns></returns>
		public static string GetHash(FileInfo file, HashAlgorithm algorithm)
		{
			if (file == null)
				throw new ArgumentNullException(nameof(file));

			if (algorithm == null)
				throw new ArgumentNullException(nameof(algorithm));

			byte[] hash;

			try
			{
				using (var stream = file.OpenRead())
					hash = algorithm.ComputeHash(stream);
			}
			catch (UnauthorizedAccessException ex)
			{
				throw new FileReadException($"Unauthorized to read {file.FullName}", ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new FileReadException($"Directory `{file.Directory.FullName}` not found", ex);
			}
			catch (IOException ex)
			{
				throw new FileReadException($"File is already open", ex);
			}

			return hash.ConvertToString();
		}
	}
}
