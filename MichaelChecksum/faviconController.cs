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
    public class faviconController : ControllerBase
    {
        /// <summary>
        /// Returns the favicon.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The hash may be cached per url.
        /// </remarks>
        [HttpGet]
        public ActionResult Icon()
        {
            return File(Encoding.UTF8.GetBytes(UI.Favicon), "image/svg+xml");
        }
    }
}