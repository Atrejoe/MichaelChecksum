using System;
using System.Diagnostics;
using Xunit;

namespace MichaelChecksum.Core.Tests
{
    /// <summary>
    /// Tests <see cref="Hashing"/>
    /// </summary>
    public class HashingTests
    {
        /// <summary>
        /// Tests <see cref="Hashing.GetHash(Uri)"/> by passing in the Google favicon url
        /// </summary>
        [Fact]
        public void GetHashTest()
        {
            //arrange
            var url = new Uri("https://www.google.com/favicon.ico");
            var expected = "49263695F6B0CDD72F45CF1B775E660FDC36C606";

            //act
            var actual = Hashing.GetHash(url);

            //assert
            Trace.WriteLine(actual);

            Assert.Equal(expected, actual);
        }
    }
}
