using System;
using Xunit;

namespace Extensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" s ", true)]
        [InlineData("s", true)]
        public void NotNullOrWhiteSpace(string input, bool expected)
        {
            Assert.Equal(expected, input.NotNullOrWhiteSpace());
        }
    }
}
