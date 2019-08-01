using MichaelChecksum.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace MichaelChecksum
{
    /// <summary>
    /// A controller for calculating <see cref="SHA1"/> hashes.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SHA1moneController : ControllerBase
    {
        /// <summary>
        /// Calculates the <see cref="SHA1"/> hash of the content of <paramref name="url"/> and returns it as a SVG badge.
        /// </summary>
        /// <param name="url">The url to calculate the SHA1 hash for.</param>
        /// <returns>A badge containing the calculated SHA1 hash.</returns>
        /// <remarks>
        /// The hash may be cached.
        /// </remarks>
        /// <seealso cref="Hashing.GetHash(Uri)"/>
        /// <response code="200">Returns the badge as an SVG image.</response>
		/// <response code="400">Argument <paramref name="url"/> invalid, response is WIP.</response>
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Hash([Url]string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
                return BadRequest("Please specify a valid absolute uri");

            var hash = Hashing.GetHash(uri);

            return File(
                fileContents: Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, UI.SVG, hash)), 
                contentType: "image/svg+xml");
        }
    }
}