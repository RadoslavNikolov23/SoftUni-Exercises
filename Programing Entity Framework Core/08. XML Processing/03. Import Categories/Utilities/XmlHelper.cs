namespace ProductShop.Utilities
{
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
    }
}
