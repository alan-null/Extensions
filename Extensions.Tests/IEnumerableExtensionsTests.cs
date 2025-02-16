using System.Collections.Generic;
using Xunit;

namespace Extensions.Tests
{
    public class IEnumerableExtensionsTests
    {

        [Fact]
        public void Empty_NoElements_Test()
        {
            // Assign 
            var collection = new List<int>();

            // Act
            var result = collection.Empty();

            // Assert 
            Assert.True(result);
        }

        [Fact]
        public void Empty_WithElements_Test()
        {
            // Assign 
            var collection = new List<int>() { 1, 2 };

            // Act
            var result = collection.Empty();

            // Assert 
            Assert.False(result);
        }
    }
}
