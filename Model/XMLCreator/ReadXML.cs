using PerformanceRecord2.Controler;
using System.Xml.Serialization;
using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;

namespace PerformanceRecord2.Model.XMLCreator
{
    public class ReadXML //dXML
    {

        //public T DeserializeFromXml<T>(XmlDocument xmlDocument)
        //{
        //    T result = default(T);

        //    try
        //    {
        //        using (XmlNodeReader reader = new XmlNodeReader(xmlDocument.DocumentElement))
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(T));
        //            result = (T)serializer.Deserialize(reader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error while deserializing: {ex.Message}");
        //    }

        //    return result;
        //}


        public List<T> ReadListFromXml<T>(string fileName)
        {
            List<T> result = new List<T>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            try
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    if (serializer.CanDeserialize(reader))
                    {
                        result = (List<T>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {fileName} not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading {fileName}: {ex.Message}");
            }

            return result;
        }
    }
}

