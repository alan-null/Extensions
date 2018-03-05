using System.Collections.Specialized;
using System.Text;
using Xunit;

namespace Extensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", false)]
        [InlineData(" s ", false)]
        [InlineData("s", false)]
        public void IsNullOrEmpty_Test(string input, bool expected)
        {
            Assert.Equal(expected, input.IsNullOrEmpty());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" s ", true)]
        [InlineData("s", true)]
        public void NotNullOrWhiteSpace_Test(string input, bool expected)
        {
            Assert.Equal(expected, input.NotNullOrWhiteSpace());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", true)]
        [InlineData(" s ", true)]
        [InlineData("s", true)]
        public void NotNullOrEmpty_Test(string input, bool expected)
        {
            Assert.Equal(expected, input.NotNullOrEmpty());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" s ", true)]
        [InlineData("s", true)]
        public void HasValue_Test(string input, bool expected)
        {
            Assert.Equal(expected, input.HasValue());
        }

        [Fact]
        public void RemoveDiacritics_Test()
        {
            // 'Cyrillic' is not a supported encoding name. 
            // https://github.com/dotnet/corefx/issues/9158
            // https://msdn.microsoft.com/en-us/library/mt643901(v=vs.110).aspx
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string input = "ą,Ą,ć,Ć,ę,Ę,ł,Ł,ń,Ń,ó,Ó,ś,Ś,ż,Ż,ź,Ź";
            string expected = "a,A,c,C,e,E,l,L,n,N,o,O,s,S,z,Z,z,Z";
            Assert.Equal(expected, input.RemoveDiacritics());
        }

        [Theory]
        [InlineData("a=1&b=2")]
        [InlineData("?a=1&b=2")]
        public void ParseQueryString_Test(string input)
        {
            var collection = input.ParseQueryString();
            Assert.Equal(2, collection.Count);
            Assert.Equal(new NameValueCollection { { "a", "1" }, { "b", "2" } }, collection);
            Assert.Equal("a=1&b=2", collection.ToString());
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData("test", "Test")]
        [InlineData("Test", "Test")]
        public void ToUpperFirst_Test(string input, string expected)
        {
            Assert.Equal(expected, input.ToUpperFirst());
        }
    }
}
