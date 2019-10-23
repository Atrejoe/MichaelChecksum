using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MichaelChecksum.Core
{
    /// <summary>
    /// General-purpose UI class
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1724", Justification = "General term")]
    public static class UI
    {

        /// <summary>
        /// The favicon version of the Fedora
        /// </summary>
        public static string Favicon(bool light = false, [Range(0,1)] decimal opacity = 1m)
        {
            return $@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
<svg width=""32"" height=""32"" {(opacity==1.0m?"":$@"fill-opacity=""{opacity.ToString(CultureInfo.InvariantCulture)}""")} fill=""{(light ? "white" : "black")}"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">
<g transform=""matrix(0.05,0,0,0.05,0,0)"">
    {fedora}
</g>
</svg>";
        }

        private const string fedora = @"<!-- https://www.svgrepo.com/svg/170982/fedora-hat -->
	<path d=""m 424.546,104.617 23.071,32.499 v 0 l 38.456,54.169 -1.851,8.856 c -0.347,1.626 -3.67,16.542 -15.224,38.881 -17.544,33.913 -53.591,84.072 -125.671,130.44 -13.701,9.049 -137.734,88.911 -208.921,65.923 l -8.252,-2.667 -20.366,-40.571 h -0.006 L 74.884,330.6 v 0 l -2.905,-5.79 c -33.302,34.324 -104.367,121.417 -55.126,197.963 0,0 75.345,127.393 293.925,-13.232 0,0 349.476,-230.225 295.57,-390.496 0.005,0.006 -26.646,-77.376 -181.802,-14.428 z""/>
	<path d=""M 280.2,262.402 C 371.033,203.978 401.745,143.055 410.485,120.594 l -5.43,-7.641 -46.496,-65.48 C 311.105,4.479 171.34,99.791 171.34,99.791 25.618,193.541 56.26,247.331 56.26,247.331 l 31.349,62.44 10.212,20.334 C 147.189,340.555 245.869,285.03 280.2,262.402 Z M 127.447,225.327 c -2.371,-5.199 -0.084,-11.349 5.122,-13.721 37.698,-17.204 83.372,-46.869 83.834,-47.164 40.526,-26.072 66.11,-48.643 80.441,-62.993 4.042,-4.049 10.597,-4.049 14.646,-0.013 3.278,3.271 3.901,8.187 1.883,12.088 -0.476,0.919 -1.105,1.787 -1.877,2.558 -21.889,21.921 -50.101,44.041 -83.841,65.744 -1.87,1.215 -47.357,30.764 -86.488,48.623 -5.198,2.378 -11.342,0.083 -13.72,-5.122 z""/>
	<path d=""m 130.66,395.528 10.109,20.141 c 63.777,20.597 191.35,-63.636 191.35,-63.636 C 446.659,278.346 463.94,195.887 463.94,195.887 L 451.402,178.22 c -1.208,2.622 -2.571,5.43 -4.152,8.464 -16.388,31.676 -53.353,84.997 -131.879,135.517 -4.934,3.258 -113.807,74.381 -184.711,73.327 z"" />";

        /// <summary>
        /// The SVG for showing the calculated hash in a SVG badge.
        /// </summary>
        public static string SVG(bool light = false)
        {
            return $@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
<svg
   width=""375""
   height=""30""
   enable-background=""true""
   fill=""{(light?"white":"black")}""
   xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">

<g transform=""matrix(0.025,0,0,0.025,3,3)"">
    {fedora}
</g>

<text
   xml:space=""preserve""
   style=""font-family:Consolas;""
   x=""20""
   y=""14"">{{0}}</text>

<text
   xml:space=""preserve""
   style=""font-family:Haettenschweiler;font-size:15px;""
   x=""267""
   y=""27""
   >MICHAELCHECKSUM.NET</text>

</svg>";

        }
    };
}
