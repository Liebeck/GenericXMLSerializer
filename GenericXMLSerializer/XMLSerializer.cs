using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace GenericXMLSerializer
{
    public class XMLSerializer
    {
        public static void Serialize<T>(T data, String path) where T : class
        {
            Serialize<T>(data, path, "root");
        }

        public static void Serialize<T>(T data, String path, String xmlRootAttributeName) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));
                xmlSerializer.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>(String path, String xmlRootAttributeName) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));
                return xmlSerializer.Deserialize(stream) as T;
            }
        }

        public static T Deserialize<T>(String path) where T : class
        {
            return Deserialize<T>(path, "root");
        }
    }
}
