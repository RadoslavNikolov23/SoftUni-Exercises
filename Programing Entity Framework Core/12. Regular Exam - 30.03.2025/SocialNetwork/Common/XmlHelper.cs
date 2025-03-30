namespace SocialNetwork.Common
{
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    public class XmlHelper
    {
        public static T? Desirialize<T>(string inputXML, string rootName) where T : class
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader strReader = new StringReader(inputXML);

            object? deserializedObject = xmlSerializer.Deserialize(strReader);

            if (deserializedObject == null)
            {
                return null;
            }

            return (T)deserializedObject;
        }

        public static string Serialize<T>(T obj, string rootName, Dictionary<string, string>? namespaces = null)
        {
            StringBuilder result = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializier = new XmlSerializer(typeof(T), xmlRoot);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

            if (namespaces == null)
            {
                xmlNamespaces.Add(string.Empty, string.Empty);
            }
            else
            {

                foreach (var ns in namespaces)
                {
                    xmlNamespaces.Add(ns.Key, ns.Value);
                }
            }

            using StringWriter strWriter = new StringWriter(result);

            xmlSerializier.Serialize(strWriter, obj, xmlNamespaces);

            return result.ToString().Trim();
        }
    }
}
