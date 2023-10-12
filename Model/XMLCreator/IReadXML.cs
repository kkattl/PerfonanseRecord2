using System.Collections.Generic;
using System.Xml;

namespace PerformanceRecord2.Model.XMLCreator
{
    public interface IReadXML
    {
        T DeserializeFromXml<T>(XmlDocument xmlDocument);
        //List<T> ReadListFromXml<T>(string fileName);
    }
}
