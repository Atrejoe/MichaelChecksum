using System;
using System.Diagnostics;
using System.IO;
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
            var actual = await Hashing.GetHashAsync(url);

            //assert
            Trace.WriteLine(actual);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests <see cref="Hashing.GetHashAsync(Uri, uint)"/> by passing in a large download file
        /// </summary>
        [Fact(Timeout = 10000)]
        public async Task GetHashTooLargeTestAsync()
        {
            //arrange
            var url = new Uri($"https://download.microsoft.com/download/1/9/8/1986c4a9-480b-4a46-8088-2778e0abcc8a/SSMS-Setup-ENU.exe");

            //act & assert
            string actual = null;
            await Assert.ThrowsAsync<FileTooLargeException>(async () => {
                actual = await Hashing.GetHashAsync(url,1000);
            });

            Assert.Null(actual);
        }

        /// <summary>
        /// Tests <see cref="Hashing.GetHashAsync(Uri, uint)"/> by passing in a url knowing to respond with 404
        /// </summary>
        [Fact]
        public async Task GetHashFileDoesNotExistAsync()
        {
            //arrange
            var url = new Uri($"https://www.github.com/{Guid.NewGuid()}.extension");

            //act & assert
            string actual = null;
            await Assert.ThrowsAsync<FileNotFoundException>(async () => {
                actual = await Hashing.GetHashAsync(url);
            });

            Assert.Null(actual);
        }
    }
}
