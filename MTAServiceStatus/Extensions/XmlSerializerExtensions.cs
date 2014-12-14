using System.Xml;
using System.Xml.Serialization;

namespace MTAServiceStatus.Extensions
{
    public static class XmlSerializerExtensions
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified System.xml.XmlReader.
        /// </summary>
        /// <typeparam name="T">Type of the destination object</typeparam>
        /// <param name="input"></param>
        /// <param name="xmlReader">The System.xml.XmlReader that contains the XML document to deserialize.</param>
        /// <returns>The T object being deserialized or null if the wrong type is requested.</returns>
        /// <exception cref="System.InvalidOperationException"/>
        public static T Deserialize<T>(this XmlSerializer input, XmlReader xmlReader) where T : class
        {
            return input.Deserialize(xmlReader) as T;
        }
    }
}
