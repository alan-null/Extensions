using System.Xml;

namespace Extensions.Xml
{
    public static class XmlNodeExtensions
    {
        public static string GetAttributeWithDefault(this XmlNode configNode, string attributeName, string @default)
        {
            return configNode.Attributes[attributeName] == null ? @default : configNode.Attributes[attributeName].Value.IsNullOrEmpty() ? @default : configNode.Attributes[attributeName].Value;
        }
    }
}
