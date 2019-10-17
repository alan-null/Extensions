using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Extensions.Xml
{
    public static class XmlSerializerExtensions
    {
        //<?xml version="1.0" encoding="utf-16"?>
        // <MyClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        // <S>sa</S>
        // </MyClass>
        public static string XmlSerializeToString(this object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }

        public static T XmlDeserializeFromString<T>(this string str)
        {
            return (T)XmlDeserializeFromString(str, typeof(T));
        }

        public static object XmlDeserializeFromString(this string str, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(str))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
