namespace ProductShop.Utilities
{
    using System.Text;
    using System.Xml.Serialization;

    public class XmlHelper
    {
        public static T? Desirialize<T>(string inputXML, string rootName) where T : class
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T),rootAttribute);

            using StringReader stringReader = new StringReader(inputXML);

            object? desirializedObj=serializer.Deserialize(stringReader);

            if (desirializedObj == null)
                return null;

            return (T)desirializedObj;
        }

        public static string Serialize<T>(T obj, string rootName, Dictionary<string,string>? nameSpaces = null)
        {
            StringBuilder sbResult = new StringBuilder();

            XmlRootAttribute xmlRoot=new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer (typeof(T),xmlRoot);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

            if(nameSpaces == null)
            {
                xmlNamespaces.Add(string.Empty, string.Empty);
            }
            else
            {
                foreach (var ns in nameSpaces)
                {
                    xmlNamespaces.Add(ns.Key, ns.Value);
                }
            }

            using StringWriter stringWriter = new StringWriter(sbResult);

            serializer.Serialize(stringWriter, obj,xmlNamespaces);

                return sbResult.ToString().Trim();
        }
    }
}
