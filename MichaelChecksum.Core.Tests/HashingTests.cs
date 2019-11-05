using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace MichaelChecksum.Core.Tests
{
    /// <summary>
    /// Tests <see cref="Hashing"/>
    /// </summary>
    public class HashingTests
    {
        /// <summary>
        /// Tests <see cref="Hashing.GetHashAsync(Uri, uint)"/> by passing in the Google favicon url
        /// </summary>
        [Fact]
        public async Task GetHashTestAsync()
        {
            //arrange
            var url = new Uri($"https://www.google.com/favicon.ico?{DateTime.UtcNow}");
            var expected = "49263695F6B0CDD72F45CF1B775E660FDC36C606";

            //act
            var actual = await Hashing.GetHashAsync(url).ConfigureAwait(false);

            //assert
            Trace.WriteLine(actual);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests <see cref="Hashing.GetHashAsync(Uri, uint)"/> by passing in the Google favicon url
        /// </summary>
        [Fact(Timeout = 10000)]
        public async Task GetHashTooLargeTestAsync()
        {
            //arrange
            var url = new Uri($"https://download.microsoft.com/download/1/9/8/1986c4a9-480b-4a46-8088-2778e0abcc8a/SSMS-Setup-ENU.exe");

            //act & assert
            string actual = null;
            await Assert.ThrowsAsync<FileTooLargeException>(async () => {
                actual = await Hashing.GetHashAsync(url,1).ConfigureAwait(true);
            }).ConfigureAwait(false);

            Assert.Null(actual);
        }
    }
}
