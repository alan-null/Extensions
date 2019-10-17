using Extensions.Tests.Models;
using System.Collections.Generic;
using Xunit;

namespace Extensions.Tests
{
    public class GenericExtensionsTests
    {
        [Fact]
        public void SafeGet_From_Dictionary_Test()
        {
            var obj = new Dictionary<string, int> { { "a", 1 } };
            Assert.Equal(1, obj.SafeGet(x => x["a"]));
            Assert.Equal(0, obj.SafeGet(x => x["b"]));
        }

        [Fact]
        public void SafeGet_From_Object_Test()
        {
            var obj = new Model { Number = 1 };
            Assert.Null(obj.SafeGet(x => x.Nested.Number));
            Assert.Equal(1, obj.SafeGet(x => x.Number));
        }

        [Fact]
        public void SafeGet_From_Collection_Test()
        {
            var obj = new List<int> { 1, 2, 3 };
            Assert.Equal(1, obj.SafeGet(x => x[0]));
            Assert.Equal(0, obj.SafeGet(x => x[10]));
        }
    }
}
