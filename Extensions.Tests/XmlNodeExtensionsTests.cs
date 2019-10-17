using System.Xml;
using Xunit;
using Extensions.Xml;

namespace Extensions.Tests
{
    public class XmlNodeExtensionsTests
    {
        private const string defaultAttributeValue = "default";

        [Fact]
        public void GetAttributeWithDefault_No_Attribute_Test()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode newElem = doc.CreateNode("element", "name", string.Empty);
            var result = newElem.GetAttributeWithDefault("attributeName", defaultAttributeValue);
            Assert.Equal(defaultAttributeValue, result);
        }

        [Fact]
        public void GetAttributeWithDefault_Test()
        {
            const string attributeName = "a";
            const string attributeValue = "123";
            XmlDocument doc = new XmlDocument();
            XmlNode newElem = doc.CreateNode("element", "name", string.Empty);
            var attribute = doc.CreateAttribute(attributeName);
            attribute.Value = attributeValue;
            newElem.Attributes.Append(attribute);
            var result = newElem.GetAttributeWithDefault(attributeName, defaultAttributeValue);
            Assert.Equal(attributeValue, result);
        }
    }
}
