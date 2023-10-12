using PerformanceRecord2.Controler;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;

namespace PerformanceRecord2.Model.XMLCreator
{
    public class WriteXML : IWriterXML
    {
        IData data;
        public WriteXML(IData data)
        {
            this.data = data;
        }
        public void WriteListToXml<T>(List<T> list, string fileName, string folderPath)
        {
            string fullPath = Path.Combine(folderPath, fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8,
            };

            using (XmlWriter writer = XmlWriter.Create(fullPath, settings))
            {
                serializer.Serialize(writer, list);
            }
        }
    }
}
