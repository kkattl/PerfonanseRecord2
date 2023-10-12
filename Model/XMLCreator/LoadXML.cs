using System.IO;
using System.Xml;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace PerformanceRecord2.Model.XMLCreator
{
    public class LoadXML// : ILoadXML
    {
        public List<T> LoadFromXml<T>(string directoryPath, string fileName)
        {
            try
            {
                string xmlFilePath = Path.Combine(directoryPath, fileName);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNodeList objectNodes = xmlDoc.GetElementsByTagName(typeof(T).Name);
                List<T> objects = new List<T>();

                foreach (XmlNode objectNode in objectNodes)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlReader reader = new XmlNodeReader(objectNode))
                    {
                        objects.Add((T)serializer.Deserialize(reader));
                    }
                }

                return objects;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading: " + e.Message);
                return null;
            }
        }
        //public T LoadFromXml<T>(string directoryPath, string fileName)
        //{
        //    try
        //    {
        //        string xmlFilePath = Path.Combine(directoryPath, fileName);

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(xmlFilePath);

        //        XmlNode root = xmlDoc.DocumentElement;
        //        XmlNode objectNode = root.SelectSingleNode(typeof(T).Name);

        //        if (objectNode != null)
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(T));
        //            using (XmlReader reader = new XmlNodeReader(objectNode))
        //            {
        //                return (T)serializer.Deserialize(reader);
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Object don`t found {typeof(T).Name} ");
        //            return default(T);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error while reading: " + e.Message);
        //        return default(T);
        //    }
        //}




        //public XmlDocument LoadXmlDocument(string folderPath, string fileName)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    string filePath = Path.Combine(folderPath, fileName);

        //    try
        //    {
        //        xmlDoc.Load(filePath);
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine($"File {filePath} not found.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error while loading {filePath}: {ex.Message}");
        //    }

        //    return xmlDoc;
        //}
    }
}
