using Xunit;
using Extensions.Xml;
using Extensions.Tests.Models;

namespace Extensions.Tests
{
    public class XmlSerializerExtensionsTests
    {
        [Fact]
        public void XmlSerializeToString_Test()
        {
            var model = new Model()
            {
                Number = 1,
                Nested = new Nested { Number = "1" }
            };
            var serializedModel = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Model xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Nested>\r\n    <Number>1</Number>\r\n  </Nested>\r\n  <Number>1</Number>\r\n</Model>";
            var result = model.XmlSerializeToString();
            Assert.Equal(serializedModel, result);
        }

        [Fact]
        public void XmlDeserializeFromString_Test()
        {
            var serializedModel = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Model xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Nested>\r\n    <Number>1</Number>\r\n  </Nested>\r\n  <Number>1</Number>\r\n</Model>";
            var result = serializedModel.XmlDeserializeFromString<Model>();
            Assert.Equal(1, result.Number);
            Assert.Equal("1", result.Nested.Number);
        }
    }
}
