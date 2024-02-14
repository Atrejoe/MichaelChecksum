using MichaelChecksum.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MichaelChecksum
{

	/// <summary>
	/// A controller for calculating <see cref="SHA1"/> hashes.
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	public class SHA1moneController : ControllerBase
	{

		private static readonly TimeSpan MaxHashAge = TimeSpan.FromHours(24);
		private static readonly TimeSpan MaxErrorAge = TimeSpan.FromMinutes(5);
		private static readonly ConcurrentDictionary<Uri, CheckResult> LastChecks = new ConcurrentDictionary<Uri, CheckResult>();

		private static void CleanLastChecks()
		{

			LastChecks
				.Where(x => x.Value.FailureReason.HasValue && DateTime.UtcNow.Subtract(x.Value.LastCheck) > MaxErrorAge)
				.Select(x => x.Key)
				.ToList()
				.ForEach(x => LastChecks.TryRemove(x, out var _));

			LastChecks
				.Where(x => !x.Value.FailureReason.HasValue && DateTime.UtcNow.Subtract(x.Value.LastCheck) > MaxHashAge)
				.Select(x => x.Key)
				.ToList()
				.ForEach(x => LastChecks.TryRemove(x, out var _));
		}

		/// <summary>
		/// Calculates the <see cref="SHA1"/> hash of the content of <paramref name="url"/> and returns it as a SVG badge.
		/// </summary>
		/// <param name="url">The url to calculate the SHA1 hash for.</param>
		/// <param name="light"></param>
		/// <returns>A badge containing the calculated SHA1 hash.</returns>
		/// <remarks>
		/// The hash may be cached.
		/// </remarks>
		/// <seealso cref="Hashing.GetHashAsync(Uri, uint)"/>
		/// <response code="200">Returns the badge as an SVG image.</response>
		/// <response code="400">Argument <paramref name="url"/> invalid, response is WIP.</response>
		/// <response code="413">Argument <paramref name="url"/> refers to a file that is too large. File size has been limited to 100MB. This may change.</response>
		/// <response code="204">Argument <paramref name="url"/> had connectivity issues, content could not be obtained.</response>
		/// <response code="404">Argument <paramref name="url"/> refers to a file that does not exist.</response>
		[HttpGet]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status413PayloadTooLarge)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult Hash([Url] string url, bool light = false)
		{
			if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
				return BadRequest("Please specify a valid absolute uri");

			CleanLastChecks();

			return Hash(uri, light);
		}

		internal ActionResult Hash([Url] Uri url, bool light = false)
		{

			var result = LastChecks.AddOrUpdate(
				url,
				(uri) => CheckHash(uri).Result,
				(uri, result) =>
				{
					result.Hits += 1;
					return result;
				}
				);

			if (result.FailureReason.HasValue)

				return result.FailureReason.Value switch
				{
					HashCalculationFailureReason.Other => new StatusCodeResult(StatusCodes.Status500InternalServerError),
					HashCalculationFailureReason.TooLarge => new StatusCodeResult(StatusCodes.Status413PayloadTooLarge),
					HashCalculationFailureReason.Connectivity => new StatusCodeResult(StatusCodes.Status204NoContent),
					HashCalculationFailureReason.NotFound => new StatusCodeResult(StatusCodes.Status404NotFound),
					_ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
				};
			else
				return File(
					fileContents: Encoding.UTF8.GetBytes(
												UI.SVG(
													Request.Host.Host,
													result.Hash,
													light,
													$"Calculated on {result.LastCheck}, in {result.Duration}. Accessed {result.Hits:n0} times since."
												)),
					contentType: "image/svg+xml");
		}

		internal static async Task<CheckResult> CheckHash(Uri url)
		{
			string hash;
			var sw = Stopwatch.StartNew();
			try
			{
				hash = await Hashing.GetHashAsync(url, 10 * 1024 * 1024).ConfigureAwait(false);

				return new CheckResult()
				{
					Hash = hash,
					Duration = sw.Elapsed
				};

			}
			catch (FileTooLargeException)
			{
				return new CheckResult()
				{
					FailureReason = HashCalculationFailureReason.TooLarge,
					Duration = sw.Elapsed
				};
			}
			catch (FileReadException)
			{
				return new CheckResult()
				{
					FailureReason = HashCalculationFailureReason.Connectivity,
					Duration = sw.Elapsed
				};
			}
			catch (FileNotFoundException)
			{
				return new CheckResult()
				{
					FailureReason = HashCalculationFailureReason.NotFound,
					Duration = sw.Elapsed
				};
			}
			catch (Exception)
			{
				return new CheckResult()
				{
					FailureReason = HashCalculationFailureReason.Other,
					Duration = sw.Elapsed
				};
			}
		}
	}
}