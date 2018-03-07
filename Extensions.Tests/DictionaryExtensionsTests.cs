using System.Collections.Generic;
using Xunit;

namespace Extensions.Tests
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void GetValueSafe_Test()
        {
            var obj = new Dictionary<string, int> { { "a", 1 } };
            Assert.Equal(1, obj.GetValueSafe("a"));
            Assert.Equal(0, obj.GetValueSafe("b"));
        }
    }
}
