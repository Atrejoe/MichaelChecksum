using MichaelChecksum.Core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace MichaelChecksum
{
	/// <summary>
	/// A controller for calculating checksums (hashes) .... boring!
	/// </summary>
	/// <seealso cref="SHA1moneController"/>
	[Route("[controller]")]
	[ApiController]
	public class ChecksumController : ControllerBase
	{
		/// <summary>
		/// Calculates <see cref="SHA1"/> hash.
		/// </summary>
		/// <param name="hihi">The text to calculate the hash for</param>
		/// <returns>The string representataion of the <see cref="SHA1"/> hash of <paramref name="hihi"/>.</returns>
		[HttpGet]
		public ActionResult SHAmone([MaxLength(1024 * 1024)] string hihi)
		{
			var result = Hashing.GetHash(hihi);
			return Ok(result);
		}
	}
}