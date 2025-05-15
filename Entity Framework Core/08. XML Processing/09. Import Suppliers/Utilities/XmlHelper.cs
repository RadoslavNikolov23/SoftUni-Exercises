namespace CarDealer.Utilities
{
    using System.Xml.Serialization;

    public class XmlHelper
    {
        public static T? Desirialize<T>(string inputXML, string rootName) where T:class
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
    }
}
