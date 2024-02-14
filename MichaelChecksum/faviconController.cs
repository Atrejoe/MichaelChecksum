using System.ComponentModel.DataAnnotations;
using System.Text;
using MichaelChecksum.Core;
using Microsoft.AspNetCore.Mvc;

namespace MichaelChecksum
{
	/// <summary>
	/// A controller for showing the favicon
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class FaviconController : ControllerBase
	{
		/// <summary>
		/// Returns the favicon.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// The hash may be cached per url.
		/// </remarks>
		[HttpGet]
		public ActionResult Icon(bool light = false, [Range(0, 1)] decimal opacity = 1.0m)
		{
			return File(Encoding.UTF8.GetBytes(UI.Favicon(light, opacity)), "image/svg+xml");
		}
	}
}